// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class AuiToolBar : Control
    {
        static AuiToolBar()
        {
            SetEventCallback();
        }
        
        public AuiToolBar()
        {
            SetNativePointer(NativeApi.AuiToolBar_Create_());
        }
        
        public AuiToolBar(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public long CreateStyle
        {
            get
            {
                CheckDisposed();
                return NativeApi.AuiToolBar_GetCreateStyle_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.AuiToolBar_SetCreateStyle_(NativePointer, value);
            }
        }
        
        public int EventToolId
        {
            get
            {
                CheckDisposed();
                return NativeApi.AuiToolBar_GetEventToolId_(NativePointer);
            }
            
        }
        
        public bool EventIsDropDownClicked
        {
            get
            {
                CheckDisposed();
                return NativeApi.AuiToolBar_GetEventIsDropDownClicked_(NativePointer);
            }
            
        }
        
        public Alternet.Drawing.PointI EventClickPoint
        {
            get
            {
                CheckDisposed();
                return NativeApi.AuiToolBar_GetEventClickPoint_(NativePointer);
            }
            
        }
        
        public Alternet.Drawing.RectI EventItemRect
        {
            get
            {
                CheckDisposed();
                return NativeApi.AuiToolBar_GetEventItemRect_(NativePointer);
            }
            
        }
        
        public void DoOnCaptureLost()
        {
            CheckDisposed();
            NativeApi.AuiToolBar_DoOnCaptureLost_(NativePointer);
        }
        
        public void DoOnLeftUp(int x, int y)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_DoOnLeftUp_(NativePointer, x, y);
        }
        
        public void DoOnLeftDown(int x, int y)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_DoOnLeftDown_(NativePointer, x, y);
        }
        
        public static System.IntPtr CreateEx(long styles)
        {
            return NativeApi.AuiToolBar_CreateEx_(styles);
        }
        
        public void SetArtProvider(System.IntPtr art)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetArtProvider_(NativePointer, art);
        }
        
        public System.IntPtr GetArtProvider()
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetArtProvider_(NativePointer);
        }
        
        public int GetToolKind(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolKind_(NativePointer, toolId);
        }
        
        public System.IntPtr AddTool(int toolId, string label, ImageSet? bitmapBundle, string shortHelpString, int itemKind)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_AddTool_(NativePointer, toolId, label, bitmapBundle?.NativePointer ?? IntPtr.Zero, shortHelpString, itemKind);
        }
        
        public System.IntPtr AddTool2(int toolId, string label, ImageSet? bitmapBundle, ImageSet? disabledBitmapBundle, int itemKind, string shortHelpString, string longHelpString, System.IntPtr clientData)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_AddTool2_(NativePointer, toolId, label, bitmapBundle?.NativePointer ?? IntPtr.Zero, disabledBitmapBundle?.NativePointer ?? IntPtr.Zero, itemKind, shortHelpString, longHelpString, clientData);
        }
        
        public System.IntPtr AddTool3(int toolId, ImageSet? bitmapBundle, ImageSet? disabledBitmapBundle, bool toggle, System.IntPtr clientData, string shortHelpString, string longHelpString)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_AddTool3_(NativePointer, toolId, bitmapBundle?.NativePointer ?? IntPtr.Zero, disabledBitmapBundle?.NativePointer ?? IntPtr.Zero, toggle, clientData, shortHelpString, longHelpString);
        }
        
        public System.IntPtr AddLabel(int toolId, string label, int width)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_AddLabel_(NativePointer, toolId, label, width);
        }
        
        public System.IntPtr AddControl(int toolId, System.IntPtr control, string label)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_AddControl_(NativePointer, toolId, control, label);
        }
        
        public System.IntPtr AddSeparator(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_AddSeparator_(NativePointer, toolId);
        }
        
        public System.IntPtr AddSpacer(int toolId, int pixels)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_AddSpacer_(NativePointer, toolId, pixels);
        }
        
        public System.IntPtr AddStretchSpacer(int toolId, int proportion)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_AddStretchSpacer_(NativePointer, toolId, proportion);
        }
        
        public bool Realize()
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_Realize_(NativePointer);
        }
        
        public System.IntPtr FindControl(int windowId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_FindControl_(NativePointer, windowId);
        }
        
        public System.IntPtr FindToolByPosition(int x, int y)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_FindToolByPosition_(NativePointer, x, y);
        }
        
        public System.IntPtr FindToolByIndex(int idx)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_FindToolByIndex_(NativePointer, idx);
        }
        
        public System.IntPtr FindTool(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_FindTool_(NativePointer, toolId);
        }
        
        public void Clear()
        {
            CheckDisposed();
            NativeApi.AuiToolBar_Clear_(NativePointer);
        }
        
        public bool DestroyTool(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_DestroyTool_(NativePointer, toolId);
        }
        
        public bool DestroyToolByIndex(int idx)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_DestroyToolByIndex_(NativePointer, idx);
        }
        
        public bool DeleteTool(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_DeleteTool_(NativePointer, toolId);
        }
        
        public bool DeleteByIndex(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_DeleteByIndex_(NativePointer, toolId);
        }
        
        public int GetToolIndex(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolIndex_(NativePointer, toolId);
        }
        
        public bool GetToolFits(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolFits_(NativePointer, toolId);
        }
        
        public Alternet.Drawing.RectD GetToolRect(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolRect_(NativePointer, toolId);
        }
        
        public bool GetToolFitsByIndex(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolFitsByIndex_(NativePointer, toolId);
        }
        
        public bool GetToolBarFits()
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolBarFits_(NativePointer);
        }
        
        public void SetToolBitmapSizeInPixels(Alternet.Drawing.SizeI size)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolBitmapSizeInPixels_(NativePointer, size);
        }
        
        public Alternet.Drawing.SizeI GetToolBitmapSizeInPixels()
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolBitmapSizeInPixels_(NativePointer);
        }
        
        public bool GetOverflowVisible()
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetOverflowVisible_(NativePointer);
        }
        
        public void SetOverflowVisible(bool visible)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetOverflowVisible_(NativePointer, visible);
        }
        
        public bool GetGripperVisible()
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetGripperVisible_(NativePointer);
        }
        
        public void SetGripperVisible(bool visible)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetGripperVisible_(NativePointer, visible);
        }
        
        public void ToggleTool(int toolId, bool state)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_ToggleTool_(NativePointer, toolId, state);
        }
        
        public bool GetToolToggled(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolToggled_(NativePointer, toolId);
        }
        
        public void SetMargins(int left, int right, int top, int bottom)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetMargins_(NativePointer, left, right, top, bottom);
        }
        
        public void EnableTool(int toolId, bool state)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_EnableTool_(NativePointer, toolId, state);
        }
        
        public bool GetToolEnabled(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolEnabled_(NativePointer, toolId);
        }
        
        public void SetToolDropDown(int toolId, bool dropdown)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolDropDown_(NativePointer, toolId, dropdown);
        }
        
        public bool GetToolDropDown(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolDropDown_(NativePointer, toolId);
        }
        
        public void SetToolBorderPadding(int padding)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolBorderPadding_(NativePointer, padding);
        }
        
        public int GetToolBorderPadding()
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolBorderPadding_(NativePointer);
        }
        
        public void SetToolTextOrientation(int orientation)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolTextOrientation_(NativePointer, orientation);
        }
        
        public int GetToolTextOrientation()
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolTextOrientation_(NativePointer);
        }
        
        public void SetToolPacking(int packing)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolPacking_(NativePointer, packing);
        }
        
        public int GetToolPacking()
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolPacking_(NativePointer);
        }
        
        public void SetToolProportion(int toolId, int proportion)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolProportion_(NativePointer, toolId, proportion);
        }
        
        public int GetToolProportion(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolProportion_(NativePointer, toolId);
        }
        
        public void SetToolSeparation(int separation)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolSeparation_(NativePointer, separation);
        }
        
        public int GetToolSeparation()
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolSeparation_(NativePointer);
        }
        
        public void SetToolSticky(int toolId, bool sticky)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolSticky_(NativePointer, toolId, sticky);
        }
        
        public bool GetToolSticky(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolSticky_(NativePointer, toolId);
        }
        
        public string GetToolLabel(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolLabel_(NativePointer, toolId);
        }
        
        public void SetToolLabel(int toolId, string label)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolLabel_(NativePointer, toolId, label);
        }
        
        public void SetToolBitmap(int toolId, ImageSet? bitmapBundle)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolBitmap_(NativePointer, toolId, bitmapBundle?.NativePointer ?? IntPtr.Zero);
        }
        
        public string GetToolShortHelp(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolShortHelp_(NativePointer, toolId);
        }
        
        public void SetToolShortHelp(int toolId, string helpString)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolShortHelp_(NativePointer, toolId, helpString);
        }
        
        public string GetToolLongHelp(int toolId)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolLongHelp_(NativePointer, toolId);
        }
        
        public void SetToolLongHelp(int toolId, string helpString)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolLongHelp_(NativePointer, toolId, helpString);
        }
        
        public ulong GetToolCount()
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolCount_(NativePointer);
        }
        
        public void SetToolMinSize(int tool_id, int width, int height)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetToolMinSize_(NativePointer, tool_id, width, height);
        }
        
        public Alternet.Drawing.SizeI GetToolMinSize(int tool_id)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetToolMinSize_(NativePointer, tool_id);
        }
        
        public void SetAlignment(int tool_id, int l)
        {
            CheckDisposed();
            NativeApi.AuiToolBar_SetAlignment_(NativePointer, tool_id, l);
        }
        
        public int GetAlignment(int tool_id)
        {
            CheckDisposed();
            return NativeApi.AuiToolBar_GetAlignment_(NativePointer, tool_id);
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.AuiToolBarEventCallbackType((obj, e, parameter) =>
                    UI.Application.HandleThreadExceptions(() =>
                    {
                        var w = NativeObject.GetFromNativePointer<AuiToolBar>(obj, p => new AuiToolBar(p));
                        if (w == null) return IntPtr.Zero;
                        return w.OnEvent(e, parameter);
                    }
                    )
                );
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.AuiToolBar_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.AuiToolBarEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.AuiToolBarEvent.ToolDropDown:
                {
                    ToolDropDown?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.AuiToolBarEvent.BeginDrag:
                {
                    BeginDrag?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.AuiToolBarEvent.ToolMiddleClick:
                {
                    ToolMiddleClick?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.AuiToolBarEvent.OverflowClick:
                {
                    OverflowClick?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.AuiToolBarEvent.ToolRightClick:
                {
                    ToolRightClick?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.AuiToolBarEvent.ToolCommand:
                {
                    ToolCommand?.Invoke(); return IntPtr.Zero;
                }
                default: throw new Exception("Unexpected AuiToolBarEvent value: " + e);
            }
        }
        
        public Action? ToolDropDown;
        public Action? BeginDrag;
        public Action? ToolMiddleClick;
        public Action? OverflowClick;
        public Action? ToolRightClick;
        public Action? ToolCommand;
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr AuiToolBarEventCallbackType(IntPtr obj, AuiToolBarEvent e, IntPtr param);
            
            public enum AuiToolBarEvent
            {
                ToolDropDown,
                BeginDrag,
                ToolMiddleClick,
                OverflowClick,
                ToolRightClick,
                ToolCommand,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetEventCallback_(AuiToolBarEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr AuiToolBar_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern long AuiToolBar_GetCreateStyle_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetCreateStyle_(IntPtr obj, long value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AuiToolBar_GetEventToolId_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_GetEventIsDropDownClicked_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.PointI AuiToolBar_GetEventClickPoint_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.RectI AuiToolBar_GetEventItemRect_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_DoOnCaptureLost_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_DoOnLeftUp_(IntPtr obj, int x, int y);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_DoOnLeftDown_(IntPtr obj, int x, int y);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_CreateEx_(long styles);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetArtProvider_(IntPtr obj, System.IntPtr art);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_GetArtProvider_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AuiToolBar_GetToolKind_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_AddTool_(IntPtr obj, int toolId, string label, IntPtr bitmapBundle, string shortHelpString, int itemKind);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_AddTool2_(IntPtr obj, int toolId, string label, IntPtr bitmapBundle, IntPtr disabledBitmapBundle, int itemKind, string shortHelpString, string longHelpString, System.IntPtr clientData);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_AddTool3_(IntPtr obj, int toolId, IntPtr bitmapBundle, IntPtr disabledBitmapBundle, bool toggle, System.IntPtr clientData, string shortHelpString, string longHelpString);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_AddLabel_(IntPtr obj, int toolId, string label, int width);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_AddControl_(IntPtr obj, int toolId, System.IntPtr control, string label);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_AddSeparator_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_AddSpacer_(IntPtr obj, int toolId, int pixels);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_AddStretchSpacer_(IntPtr obj, int toolId, int proportion);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_Realize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_FindControl_(IntPtr obj, int windowId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_FindToolByPosition_(IntPtr obj, int x, int y);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_FindToolByIndex_(IntPtr obj, int idx);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr AuiToolBar_FindTool_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_Clear_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_DestroyTool_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_DestroyToolByIndex_(IntPtr obj, int idx);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_DeleteTool_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_DeleteByIndex_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AuiToolBar_GetToolIndex_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_GetToolFits_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.RectD AuiToolBar_GetToolRect_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_GetToolFitsByIndex_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_GetToolBarFits_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolBitmapSizeInPixels_(IntPtr obj, Alternet.Drawing.SizeI size);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.SizeI AuiToolBar_GetToolBitmapSizeInPixels_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_GetOverflowVisible_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetOverflowVisible_(IntPtr obj, bool visible);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_GetGripperVisible_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetGripperVisible_(IntPtr obj, bool visible);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_ToggleTool_(IntPtr obj, int toolId, bool state);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_GetToolToggled_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetMargins_(IntPtr obj, int left, int right, int top, int bottom);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_EnableTool_(IntPtr obj, int toolId, bool state);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_GetToolEnabled_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolDropDown_(IntPtr obj, int toolId, bool dropdown);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_GetToolDropDown_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolBorderPadding_(IntPtr obj, int padding);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AuiToolBar_GetToolBorderPadding_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolTextOrientation_(IntPtr obj, int orientation);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AuiToolBar_GetToolTextOrientation_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolPacking_(IntPtr obj, int packing);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AuiToolBar_GetToolPacking_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolProportion_(IntPtr obj, int toolId, int proportion);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AuiToolBar_GetToolProportion_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolSeparation_(IntPtr obj, int separation);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AuiToolBar_GetToolSeparation_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolSticky_(IntPtr obj, int toolId, bool sticky);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool AuiToolBar_GetToolSticky_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string AuiToolBar_GetToolLabel_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolLabel_(IntPtr obj, int toolId, string label);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolBitmap_(IntPtr obj, int toolId, IntPtr bitmapBundle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string AuiToolBar_GetToolShortHelp_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolShortHelp_(IntPtr obj, int toolId, string helpString);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string AuiToolBar_GetToolLongHelp_(IntPtr obj, int toolId);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolLongHelp_(IntPtr obj, int toolId, string helpString);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern ulong AuiToolBar_GetToolCount_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetToolMinSize_(IntPtr obj, int tool_id, int width, int height);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.SizeI AuiToolBar_GetToolMinSize_(IntPtr obj, int tool_id);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void AuiToolBar_SetAlignment_(IntPtr obj, int tool_id, int l);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AuiToolBar_GetAlignment_(IntPtr obj, int tool_id);
            
        }
    }
}
