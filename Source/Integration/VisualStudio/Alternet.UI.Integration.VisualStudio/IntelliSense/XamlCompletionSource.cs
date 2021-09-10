﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Alternet.UI.Integration.VisualStudio.Models;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text;
using Serilog;
using CompletionEngine = Alternet.UI.Integration.IntelliSense.CompletionEngine;

namespace Alternet.UI.Integration.VisualStudio.IntelliSense
{
    internal class XamlCompletionSource : ICompletionSource
    {
        private readonly ITextBuffer _buffer;
        private readonly IVsImageService2 _imageService;
        private readonly CompletionEngine _engine;

        public XamlCompletionSource(ITextBuffer textBuffer, IVsImageService2 imageService)
        {
            _buffer = textBuffer;
            _imageService = imageService;
            _engine = new CompletionEngine();
        }

        DateTime _lastRequestTime = DateTime.MinValue;

        public void AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            var currentRequestTime = DateTime.Now;
            if ((currentRequestTime - _lastRequestTime).TotalMilliseconds < 500)
                return;
            _lastRequestTime = currentRequestTime;

            if (_buffer.Properties.TryGetProperty<XamlBufferMetadata>(typeof(XamlBufferMetadata), out var metadata) &&
                metadata.CompletionMetadata != null)
            {
                var sw = Stopwatch.StartNew();
                var pos = session.TextView.Caret.Position.BufferPosition;
                var text = pos.Snapshot.GetText();
                _buffer.Properties.TryGetProperty("AssemblyName", out string assemblyName);
                var completions = _engine.GetCompletions(metadata.CompletionMetadata, text, pos, assemblyName);

                if (completions?.Completions.Count > 0)
                {
                    var start = completions.StartPosition;
                    var span = new SnapshotSpan(pos.Snapshot, start, pos.Position - start);
                    var applicableTo = pos.Snapshot.CreateTrackingSpan(span, SpanTrackingMode.EdgeInclusive);

                    completionSets.Insert(0, new CompletionSet(
                        "AlternetUI",
                        "Alternet UI",
                        applicableTo,
                        XamlCompletion.Create(completions.Completions, _imageService),
                        null));

                    string completionHint = completions.Completions.Count == 0 ?
                        "no completions found" :
                        $"{completions.Completions.Count} completions found (First:{completions.Completions.FirstOrDefault()?.DisplayText})";

                    Log.Logger.Verbose("XAML completion took {Time}, {CompletionHint}", sw.Elapsed, completionHint);
                }

                sw.Stop();
            }
        }

        public void Dispose()
        {
        }
    }
}
