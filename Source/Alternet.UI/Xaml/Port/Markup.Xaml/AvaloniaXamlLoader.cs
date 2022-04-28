#nullable disable
using System;
using System.IO;
using System.Reflection;
using Alternet.UI.Platform;

namespace Alternet.UI.Markup.Xaml
{
    /// <summary>
    /// Loads XAML for a uixmlPort application.
    /// </summary>
    internal static class UixmlPortXamlLoader
    {
        internal interface IRuntimeXamlLoader
        {
            object Load(Stream stream, Assembly localAsm, object o, Uri baseUri, bool designMode);
        }
        
        /// <summary>
        /// Loads the XAML into a UixmlPort component.
        /// </summary>
        /// <param name="obj">The object to load the XAML into.</param>
        public static void Load(object obj)
        {
            throw new XamlLoadException(
                $"No precompiled XAML found for {obj.GetType()}, make sure to specify x:Class and include your XAML file as UixmlPortResource");
        }

        /// <summary>
        /// Loads XAML from a URI.
        /// </summary>
        /// <param name="uri">The URI of the XAML file.</param>
        /// <param name="baseUri">
        /// A base URI to use if <paramref name="uri"/> is relative.
        /// </param>
        /// <returns>The loaded object.</returns>
        public static object Load(Uri uri, Uri baseUri = null)
        {
            Contract.Requires<ArgumentNullException>(uri != null);

            var assetLocator = UixmlPortLocator.Current.GetService<IAssetLoader>();

            if (assetLocator == null)
            {
                throw new InvalidOperationException(
                    "Could not create IAssetLoader : maybe Application.RegisterServices() wasn't called?");
            }

            var compiledLoader = assetLocator.GetAssembly(uri, baseUri)
                ?.GetType("CompiledUixmlPortXaml.!XamlLoader")
                ?.GetMethod("TryLoad", new[] {typeof(string)});
            if (compiledLoader != null)
            {
                var uriString = (!uri.IsAbsoluteUri && baseUri != null ? new Uri(baseUri, uri) : uri)
                    .ToString();
                var compiledResult = compiledLoader.Invoke(null, new object[] {uriString});
                if (compiledResult != null)
                    return compiledResult;
            }

            // This is intended for unit-tests only
            var runtimeLoader = UixmlPortLocator.Current.GetService<IRuntimeXamlLoader>();
            if (runtimeLoader != null)
            {
                var asset = assetLocator.OpenAndGetAssembly(uri, baseUri);
                using (var stream = asset.stream)
                {
                    var absoluteUri = uri.IsAbsoluteUri ? uri : new Uri(baseUri, uri);
                    return runtimeLoader.Load(stream, asset.assembly, null, absoluteUri, false);
                }
            }

            throw new XamlLoadException(
                $"No precompiled XAML found for {uri} (baseUri: {baseUri}), make sure to specify x:Class and include your XAML file as UixmlPortResource");
        }
        
    }
}
