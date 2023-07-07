// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class WebBrowser : Control
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
        
        public bool CanGoBack
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetCanGoBack_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool CanGoForward
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetCanGoForward_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool CanCut
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetCanCut_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool CanCopy
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetCanCopy_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool CanUndo
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetCanUndo_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool CanRedo
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetCanRedo_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool IsBusy
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetIsBusy_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool CanPaste
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetCanPaste_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public float ZoomFactor
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetZoomFactor_(NativePointer);
                var m = n;
                return m;
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
                var n = NativeApi.WebBrowser_GetHasSelection_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public string SelectedSource
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetSelectedSource_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public string SelectedText
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetSelectedText_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public string PageSource
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetPageSource_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public string PageText
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetPageText_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool AccessToDevToolsEnabled
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.WebBrowser_GetAccessToDevToolsEnabled_(NativePointer);
                var m = n;
                return m;
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
                var n = NativeApi.WebBrowser_GetPreferredColorScheme_(NativePointer);
                var m = n;
                return m;
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
                var n = NativeApi.WebBrowser_GetUserAgent_(NativePointer);
                var m = n;
                return m;
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
                var n = NativeApi.WebBrowser_GetContextMenuEnabled_(NativePointer);
                var m = n;
                return m;
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
                var n = NativeApi.WebBrowser_GetEditable_(NativePointer);
                var m = n;
                return m;
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
                var n = NativeApi.WebBrowser_GetZoom_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.WebBrowser_SetZoom_(NativePointer, value);
            }
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
            var n = NativeApi.WebBrowser_DoCommand_(NativePointer, cmdName, cmdParam1, cmdParam2);
            var m = n;
            return m;
        }
        
        public static string DoCommandGlobal(string cmdName, string cmdParam1, string cmdParam2)
        {
            var n = NativeApi.WebBrowser_DoCommandGlobal_(cmdName, cmdParam1, cmdParam2);
            var m = n;
            return m;
        }
        
        public void SetVirtualHostNameToFolderMapping(string hostName, string folderPath, int accessKind)
        {
            CheckDisposed();
            NativeApi.WebBrowser_SetVirtualHostNameToFolderMapping_(NativePointer, hostName, folderPath, accessKind);
        }
        
        public System.IntPtr GetNativeBackend()
        {
            CheckDisposed();
            var n = NativeApi.WebBrowser_GetNativeBackend_(NativePointer);
            var m = n;
            return m;
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
            var n = NativeApi.WebBrowser_AddScriptMessageHandler_(NativePointer, name);
            var m = n;
            return m;
        }
        
        public bool RemoveScriptMessageHandler(string name)
        {
            CheckDisposed();
            var n = NativeApi.WebBrowser_RemoveScriptMessageHandler_(NativePointer, name);
            var m = n;
            return m;
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
            var n = NativeApi.WebBrowser_GetBackendOS_();
            var m = n;
            return m;
        }
        
        public static void SetEdgePath(string path)
        {
            NativeApi.WebBrowser_SetEdgePath_(path);
        }
        
        public string GetCurrentTitle()
        {
            CheckDisposed();
            var n = NativeApi.WebBrowser_GetCurrentTitle_(NativePointer);
            var m = n;
            return m;
        }
        
        public string GetCurrentURL()
        {
            CheckDisposed();
            var n = NativeApi.WebBrowser_GetCurrentURL_(NativePointer);
            var m = n;
            return m;
        }
        
        public void LoadURL(string url)
        {
            CheckDisposed();
            NativeApi.WebBrowser_LoadURL_(NativePointer, url);
        }
        
        public string RunScript(string javascript)
        {
            CheckDisposed();
            var n = NativeApi.WebBrowser_RunScript_(NativePointer, javascript);
            var m = n;
            return m;
        }
        
        public void SetPage(string text, string baseUrl)
        {
            CheckDisposed();
            NativeApi.WebBrowser_SetPage_(NativePointer, text, baseUrl);
        }
        
        public bool AddUserScript(string javascript, int injectionTime)
        {
            CheckDisposed();
            var n = NativeApi.WebBrowser_AddUserScript_(NativePointer, javascript, injectionTime);
            var m = n;
            return m;
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.WebBrowserEventCallbackType((obj, e, parameter) =>
                UI.Application.HandleThreadExceptions(() =>
                {
                    var w = NativeObject.GetFromNativePointer<WebBrowser>(obj, p => new WebBrowser(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                ));
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
                    Navigating?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.Navigated:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    Navigated?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.Loaded:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    Loaded?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.Error:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    Error?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.NewWindow:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    NewWindow?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.TitleChanged:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    TitleChanged?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.FullScreenChanged:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    FullScreenChanged?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.ScriptMessageReceived:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    ScriptMessageReceived?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.ScriptResult:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    ScriptResult?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.WebBrowserEvent.BeforeBrowserCreate:
                {
                    var ea = new NativeEventArgs<WebBrowserEventData>(MarshalEx.PtrToStructure<WebBrowserEventData>(parameter));
                    BeforeBrowserCreate?.Invoke(this, ea); return ea.Result;
                }
                default: throw new Exception("Unexpected WebBrowserEvent value: " + e);
            }
        }
        
        public event NativeEventHandler<WebBrowserEventData>? Navigating;
        public event NativeEventHandler<WebBrowserEventData>? Navigated;
        public event NativeEventHandler<WebBrowserEventData>? Loaded;
        public event NativeEventHandler<WebBrowserEventData>? Error;
        public event NativeEventHandler<WebBrowserEventData>? NewWindow;
        public event NativeEventHandler<WebBrowserEventData>? TitleChanged;
        public event NativeEventHandler<WebBrowserEventData>? FullScreenChanged;
        public event NativeEventHandler<WebBrowserEventData>? ScriptMessageReceived;
        public event NativeEventHandler<WebBrowserEventData>? ScriptResult;
        public event NativeEventHandler<WebBrowserEventData>? BeforeBrowserCreate;
        
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
