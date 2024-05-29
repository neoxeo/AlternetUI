#pragma warning disable
#nullable disable
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

//
//



namespace Alternet.UI.Port
{
    internal interface IFreezeFreezables
    {
        bool FreezeFreezables
        {
            get;
        }
        
        bool TryFreeze(string value, Freezable freezable);

        Freezable TryGetFreezable(string value);
    }
}
