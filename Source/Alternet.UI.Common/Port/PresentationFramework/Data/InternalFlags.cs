#pragma warning disable
#nullable disable
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


namespace Alternet.UI.Port
{
    internal enum InternalFlags : uint
    {
        // Does the instance have ResourceReference properties
        HasResourceReferences = 0x00000001,

        HasNumberSubstitutionChanged = 0x00000002,

        // Is the style for this instance obtained from a
        // typed-style declared in the Resources
        HasImplicitStyleFromResources = 0x00000004,
        InheritanceBehavior0 = 0x00000008,
        InheritanceBehavior1 = 0x00000010,
        InheritanceBehavior2 = 0x00000020,

        IsStyleUpdateInProgress = 0x00000040,
        IsThemeStyleUpdateInProgress = 0x00000080,
        StoresParentTemplateValues = 0x00000100,

        // free bit = 0x00000200,
        NeedsClipBounds = 0x00000400,

        HasWidthEverChanged = 0x00000800,
        HasHeightEverChanged = 0x00001000,
        // free bit = 0x00002000,
        // free bit = 0x00004000,

        // Has this instance been initialized
        IsInitialized = 0x00008000,

        // Set on BeginInit and reset on EndInit
        InitPending = 0x00010000,

        IsResourceParentValid = 0x00020000,
        // free bit                     0x00040000,

        // This flag is set to true when this FrameworkElement is in the middle
        //  of an invalidation storm caused by InvalidateTree for ancestor change,
        //  so we know not to trigger another one.
        AncestorChangeInProgress = 0x00080000,

        // This is used when we know that we're in a subtree whose visibility
        //  is collapsed.  A false here does not indicate otherwise.  A false
        //  merely indicates "we don't know".
        InVisibilityCollapsedTree = 0x00100000,

        HasStyleEverBeenFetched = 0x00200000,
        HasThemeStyleEverBeenFetched = 0x00400000,

        HasLocalStyle = 0x00800000,

        // This instance's Visual or logical Tree was generated by a Template
        HasTemplateGeneratedSubTree = 0x01000000,

        // free bit   = 0x02000000,

        HasLogicalChildren = 0x04000000,

        // Are we in the process of iterating the logical children.
        // This flag is set during a descendents walk, for property invalidation.
        IsLogicalChildrenIterationInProgress = 0x08000000,

        //Are we creating a new root after system metrics have changed?
        CreatingRoot = 0x10000000,

        // FlowDirection is set to RightToLeft (0 == LeftToRight, 1 == RightToLeft)
        // This is an optimization to speed reading the FlowDirection property
        IsRightToLeft = 0x20000000,

        ShouldLookupImplicitStyles = 0x40000000,

        // This flag is set to true there are mentees listening to either the
        // InheritedPropertyChanged event or the ResourcesChanged event. Once
        // this flag is set to true it does not get reset after that.

        PotentiallyHasMentees = 0x80000000,
    }
}


