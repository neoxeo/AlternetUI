// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2025 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class WebBrowser : Control
    {
        static WebBrowser()
        {
            SetEventCallback();
        }
        
        public WebBrowser()
        {
            SetNativePointer(NativeApi.WebBrowser_Create_());
        }
        
        public WebBrowser(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public static bool IsEdgeBackendEnabled
        {
            get
            {
                return NativeApi.WebBrowser_GetIsEdgeBackendEnabled_();
            }
            
            set
            {
                NativeApi.WebBrowser_SetIsEdgeBackendEnabled_(value);
            }
        }
        
        public bool HasBorder
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetHasBorder_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.WebBrowser_SetHasBorder_(NativePointer, value);
            }
        }
        
        public bool CanGoBack
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetCanGoBack_(NativePointer);
            }
            
        }
        
        public bool CanGoForward
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetCanGoForward_(NativePointer);
            }
            
        }
        
        public bool CanCut
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetCanCut_(NativePointer);
            }
            
        }
        
        public bool CanCopy
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetCanCopy_(NativePointer);
            }
            
        }
        
        public bool CanUndo
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetCanUndo_(NativePointer);
            }
            
        }
        
        public bool CanRedo
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetCanRedo_(NativePointer);
            }
            
        }
        
        public bool IsBusy
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetIsBusy_(NativePointer);
            }
            
        }
        
        public bool CanPaste
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetCanPaste_(NativePointer);
            }
            
        }
        
        public float ZoomFactor
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetZoomFactor_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.WebBrowser_SetZoomFactor_(NativePointer, value);
            }
        }
        
        public bool HasSelection
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetHasSelection_(NativePointer);
            }
            
        }
        
        public string SelectedSource
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetSelectedSource_(NativePointer);
            }
            
        }
        
        public string SelectedText
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetSelectedText_(NativePointer);
            }
            
        }
        
        public string PageSource
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetPageSource_(NativePointer);
            }
            
        }
        
        public string PageText
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetPageText_(NativePointer);
            }
            
        }
        
        public bool AccessToDevToolsEnabled
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetAccessToDevToolsEnabled_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.WebBrowser_SetAccessToDevToolsEnabled_(NativePointer, value);
            }
        }
        
        public int PreferredColorScheme
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetPreferredColorScheme_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.WebBrowser_SetPreferredColorScheme_(NativePointer, value);
            }
        }
        
        public string UserAgent
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetUserAgent_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.WebBrowser_SetUserAgent_(NativePointer, value);
            }
        }
        
        public bool ContextMenuEnabled
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetContextMenuEnabled_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.WebBrowser_SetContextMenuEnabled_(NativePointer, value);
            }
        }
        
        public bool Editable
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetEditable_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.WebBrowser_SetEditable_(NativePointer, value);
            }
        }
        
        public int Zoom
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetZoom_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.WebBrowser_SetZoom_(NativePointer, value);
            }
        }
        
        public bool IsEdge
        {
            get
            {
                CheckDisposed();
                return NativeApi.WebBrowser_GetIsEdge_(NativePointer);
            }
            
        }
        
        public static System.IntPtr CreateWebBrowser(string url)
        {
            return NativeApi.WebBrowser_CreateWebBrowser_(url);
        }
        
        public static void SetDefaultUserAgent(string value)
        {
            NativeApi.WebBrowser_SetDefaultUserAgent_(value);
        }
        
        public static void SetDefaultScriptMesageName(string value)
        {
            NativeApi.WebBrowser_SetDefaultScriptMesageName_(value);
        }
        
        public static void SetDefaultFSNameMemory(string value)
        {
            NativeApi.WebBrowser_SetDefaultFSNameMemory_(value);
        }
        
        public static void SetDefaultFSNameArchive(string value)
        {
            NativeApi.WebBrowser_SetDefaultFSNameArchive_(value);
        }
        
        public string DoCommand(string cmdName, string cmdParam1, string cmdParam2)
        {
            CheckDisposed();
            return NativeApi.WebBrowser_DoCommand_(NativePointer, cmdName, cmdParam1, cmdParam2);
        }
        
        public static string DoCommandGlobal(string cmdName, string cmdParam1, string cmdParam2)
        {
            return NativeApi.WebBrowser_DoCommandGlobal_(cmdName, cmdParam1, cmdParam2);
        }
        
        public void SetVirtualHostNameToFolderMapping(string hostName, string folderPath, int accessKind)
        {
            CheckDisposed();
            NativeApi.WebBrowser_SetVirtualHostNameToFolderMapping_(NativePointer, hostName, folderPath, accessKind);
        }
        
        public System.IntPtr GetNativeBackend()
        {
            CheckDisposed();
            return NativeApi.WebBrowser_GetNativeBackend_(NativePointer);
        }
        
        public void GoBack()
        {
            CheckDisposed();
            NativeApi.WebBrowser_GoBack_(NativePointer);
        }
        
        public void GoForward()
        {
            CheckDisposed();
            NativeApi.WebBrowser_GoForward_(NativePointer);
        }
        
        public void Stop()
        {
            CheckDisposed();
            NativeApi.WebBrowser_Stop_(NativePointer);
        }
        
        public void ClearSelection()
        {
            CheckDisposed();
            NativeApi.WebBrowser_ClearSelection_(NativePointer);
        }
        
        public void Copy()
        {
            CheckDisposed();
            NativeApi.WebBrowser_Copy_(NativePointer);
        }
        
        public void Paste()
        {
            CheckDisposed();
            NativeApi.WebBrowser_Paste_(NativePointer);
        }
        
        public void Cut()
        {
            CheckDisposed();
            NativeApi.WebBrowser_Cut_(NativePointer);
        }
        
        public void ClearHistory()
        {
            CheckDisposed();
            NativeApi.WebBrowser_ClearHistory_(NativePointer);
        }
        
        public void EnableHistory(bool enable)
        {
            CheckDisposed();
            NativeApi.WebBrowser_EnableHistory_(NativePointer, enable);
        }
        
        public void ReloadDefault()
        {
            CheckDisposed();
            NativeApi.WebBrowser_ReloadDefault_(NativePointer);
        }
        
        public void Reload(bool noCache)
        {
            CheckDisposed();
            NativeApi.WebBrowser_Reload_(NativePointer, noCache);
        }
        
        public void SelectAll()
        {
            CheckDisposed();
            NativeApi.WebBrowser_SelectAll_(NativePointer);
        }
        
        public void DeleteSelection()
        {
            CheckDisposed();
            NativeApi.WebBrowser_DeleteSelection_(NativePointer);
        }
        
        public void Undo()
        {
            CheckDisposed();
            NativeApi.WebBrowser_Undo_(NativePointer);
        }
        
        public void Redo()
        {
            CheckDisposed();
            NativeApi.WebBrowser_Redo_(NativePointer);
        }
        
        public void Print()
        {
            CheckDisposed();
            NativeApi.WebBrowser_Print_(NativePointer);
        }
        
        public void RemoveAllUserScripts()
        {
            CheckDisposed();
            NativeApi.WebBrowser_RemoveAllUserScripts_(NativePointer);
        }
        
        public bool AddScriptMessageHandler(string name)
        {
            CheckDisposed();
            return NativeApi.WebBrowser_AddScriptMessageHandler_(NativePointer, name);
        }
        
        public bool RemoveScriptMessageHandler(string name)
        {
            CheckDisposed();
            return NativeApi.WebBrowser_RemoveScriptMessageHandler_(NativePointer, name);
        }
        
        public void RunScriptAsync(string javascript, System.IntPtr clientData)
        {
            CheckDisposed();
            NativeApi.WebBrowser_RunScriptAsync_(NativePointer, javascript, clientData);
        }
        
        public void CreateBackend()
        {
            CheckDisposed();
            NativeApi.WebBrowser_CreateBackend_(NativePointer);
        }
        
        public static int GetBackendOS()
        {
            return NativeApi.WebBrowser_GetBackendOS_();
        }
        
        public static void SetEdgePath(string path)
        {
            NativeApi.WebBrowser_SetEdgePath_(path);
        }
        
        public string GetCurrentTitle()
        {
            CheckDisposed();
            return NativeApi.WebBrowser_GetCurrentTitle_(NativePointer);
        }
        
        public string GetCurrentURL()
        {
            CheckDisposed();
            return NativeApi.WebBrowser_GetCurrentURL_(NativePointer);
        }
        
        public void LoadURL(string url)
        {
            CheckDisposed();
            NativeApi.WebBrowser_LoadURL_(NativePointer, url);
        }
        
        public string RunScript(string javascript)
        {
            CheckDisposed();
            return NativeApi.WebBrowser_RunScript_(NativePointer, javascript);
        }
        
        public void SetPage(string text, string baseUrl)
        {
            CheckDisposed();
            NativeApi.WebBrowser_SetPage_(NativePointer, text, baseUrl);
        }
        
        public bool AddUserScript(string javascript, int injectionTime)
        {
            CheckDisposed();
            return NativeApi.WebBrowser_AddUserScript_(NativePointer, javascript, injectionTime);
        }
        
        static GCHandle eventCallbackGCHandle;
        public static WebBrowser? GlobalObject;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.WebBrowserEventCallbackType((obj, e, parameter) =>
                    UI.Application.HandleThreadExceptions(() =>
                    {
                        var w = NativeObject.GetFromNativePointer<WebBrowser>(obj, p => new WebBrowser(p));
                        w ??= GlobalObject;
                        if (w == null) return IntPtr.Zero;
                        return w.OnEvent(e, parameter);
                    }
                    )
                );
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.WebBrowser_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.WebBrowserEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.WebBrowserEvent.Navigating:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    OnPlatformEventNavigating(ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.Navigated:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    OnPlatformEventNavigated(ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.Loaded:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    OnPlatformEventLoaded(ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.Error:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    OnPlatformEventError(ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.NewWindow:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    OnPlatformEventNewWindow(ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.TitleChanged:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    OnPlatformEventTitleChanged(ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.FullScreenChanged:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    OnPlatformEventFullScreenChanged(ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.ScriptMessageReceived:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    OnPlatformEventScriptMessageReceived(ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.ScriptResult:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    OnPlatformEventScriptResult(ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.BeforeBrowserCreate:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    OnPlatformEventBeforeBrowserCreate(ea); return ea.Result;
                }
                default: throw new Exception("Unexpected WebBrowserEvent value: " + e);
            }
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr WebBrowserEventCallbackType(IntPtr obj, WebBrowserEvent e, IntPtr param);
            
            public enum WebBrowserEvent
            {
                Navigating,
                Navigated,
                Loaded,
                Error,
                NewWindow,
                TitleChanged,
                FullScreenChanged,
                ScriptMessageReceived,
                ScriptResult,
                BeforeBrowserCreate,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetEventCallback_(WebBrowserEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr WebBrowser_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetIsEdgeBackendEnabled_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetIsEdgeBackendEnabled_(bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetHasBorder_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetHasBorder_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetCanGoBack_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetCanGoForward_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetCanCut_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetCanCopy_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetCanUndo_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetCanRedo_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetIsBusy_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetCanPaste_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern float WebBrowser_GetZoomFactor_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetZoomFactor_(IntPtr obj, float value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetHasSelection_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string WebBrowser_GetSelectedSource_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string WebBrowser_GetSelectedText_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string WebBrowser_GetPageSource_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string WebBrowser_GetPageText_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetAccessToDevToolsEnabled_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetAccessToDevToolsEnabled_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int WebBrowser_GetPreferredColorScheme_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetPreferredColorScheme_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string WebBrowser_GetUserAgent_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetUserAgent_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetContextMenuEnabled_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetContextMenuEnabled_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetEditable_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetEditable_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int WebBrowser_GetZoom_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetZoom_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_GetIsEdge_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr WebBrowser_CreateWebBrowser_(string url);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetDefaultUserAgent_(string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetDefaultScriptMesageName_(string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetDefaultFSNameMemory_(string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetDefaultFSNameArchive_(string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string WebBrowser_DoCommand_(IntPtr obj, string cmdName, string cmdParam1, string cmdParam2);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string WebBrowser_DoCommandGlobal_(string cmdName, string cmdParam1, string cmdParam2);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetVirtualHostNameToFolderMapping_(IntPtr obj, string hostName, string folderPath, int accessKind);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr WebBrowser_GetNativeBackend_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_GoBack_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_GoForward_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_Stop_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_ClearSelection_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_Copy_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_Paste_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_Cut_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_ClearHistory_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_EnableHistory_(IntPtr obj, bool enable);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_ReloadDefault_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_Reload_(IntPtr obj, bool noCache);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SelectAll_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_DeleteSelection_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_Undo_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_Redo_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_Print_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_RemoveAllUserScripts_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_AddScriptMessageHandler_(IntPtr obj, string name);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_RemoveScriptMessageHandler_(IntPtr obj, string name);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_RunScriptAsync_(IntPtr obj, string javascript, System.IntPtr clientData);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_CreateBackend_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int WebBrowser_GetBackendOS_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetEdgePath_(string path);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string WebBrowser_GetCurrentTitle_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string WebBrowser_GetCurrentURL_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_LoadURL_(IntPtr obj, string url);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string WebBrowser_RunScript_(IntPtr obj, string javascript);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WebBrowser_SetPage_(IntPtr obj, string text, string baseUrl);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool WebBrowser_AddUserScript_(IntPtr obj, string javascript, int injectionTime);
            
        }
    }
}
