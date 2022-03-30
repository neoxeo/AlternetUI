#nullable disable
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Alternet.Base.Reflection
{
    /// <summary>
    /// Represents an object that provides a custom type.
    /// </summary>
    public interface ICustomTypeProvider
    {
        /// <summary>
        /// Gets the custom type provided by this object.
        /// </summary>
        /// <returns>The custom type.</returns>
        Type GetCustomType();
    }

}
