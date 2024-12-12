// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class Application : NativeObject
    {
        static Application()
        {
            SetEventCallback();
        }
        
        public Application()
        {
            SetNativePointer(NativeApi.Application_Create_());
        }
        
        public Application(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public string EventArgString
        {
            get
            {
                CheckDisposed();
                return NativeApi.Application_GetEventArgString_(NativePointer);
            }
            
        }
        
        public string Name
        {
            get
            {
                CheckDisposed();
                return NativeApi.Application_GetName_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Application_SetName_(NativePointer, value);
            }
        }
        
        public Keyboard Keyboard
        {
            get
            {
                CheckDisposed();
                var _nnn = NativeApi.Application_GetKeyboard_(NativePointer);
                var _mmm = NativeObject.GetFromNativePointer<Keyboard>(_nnn, p => new Keyboard(p))!;
                ReleaseNativeObjectPointer(_nnn);
                return _mmm;
            }
            
        }
        
        public Mouse Mouse
        {
            get
            {
                CheckDisposed();
                var _nnn = NativeApi.Application_GetMouse_(NativePointer);
                var _mmm = NativeObject.GetFromNativePointer<Mouse>(_nnn, p => new Mouse(p))!;
                ReleaseNativeObjectPointer(_nnn);
                return _mmm;
            }
            
        }
        
        public Clipboard Clipboard
        {
            get
            {
                CheckDisposed();
                var _nnn = NativeApi.Application_GetClipboard_(NativePointer);
                var _mmm = NativeObject.GetFromNativePointer<Clipboard>(_nnn, p => new Clipboard(p))!;
                ReleaseNativeObjectPointer(_nnn);
                return _mmm;
            }
            
        }
        
        public string DisplayName
        {
            get
            {
                CheckDisposed();
                return NativeApi.Application_GetDisplayName_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Application_SetDisplayName_(NativePointer, value);
            }
        }
        
        public string AppClassName
        {
            get
            {
                CheckDisposed();
                return NativeApi.Application_GetAppClassName_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Application_SetAppClassName_(NativePointer, value);
            }
        }
        
        public string VendorName
        {
            get
            {
                CheckDisposed();
                return NativeApi.Application_GetVendorName_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Application_SetVendorName_(NativePointer, value);
            }
        }
        
        public string VendorDisplayName
        {
            get
            {
                CheckDisposed();
                return NativeApi.Application_GetVendorDisplayName_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Application_SetVendorDisplayName_(NativePointer, value);
            }
        }
        
        public bool InUixmlPreviewerMode
        {
            get
            {
                CheckDisposed();
                return NativeApi.Application_GetInUixmlPreviewerMode_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Application_SetInUixmlPreviewerMode_(NativePointer, value);
            }
        }
        
        public bool InvokeRequired
        {
            get
            {
                CheckDisposed();
                return NativeApi.Application_GetInvokeRequired_(NativePointer);
            }
            
        }
        
        public static void GetEventIdentifiers(System.Int32[] eventIdentifiers)
        {
            NativeApi.Application_GetEventIdentifiers_(eventIdentifiers, eventIdentifiers.Length);
        }
        
        public static void ThrowError(int value)
        {
            NativeApi.Application_ThrowError_(value);
        }
        
        public static void SetSystemOptionInt(string name, int value)
        {
            NativeApi.Application_SetSystemOptionInt_(name, value);
        }
        
        public void Run(Window window)
        {
            CheckDisposed();
            NativeApi.Application_Run_(NativePointer, window.NativePointer);
        }
        
        public System.IntPtr GetTopWindow()
        {
            CheckDisposed();
            return NativeApi.Application_GetTopWindow_(NativePointer);
        }
        
        public void ExitMainLoop()
        {
            CheckDisposed();
            NativeApi.Application_ExitMainLoop_(NativePointer);
        }
        
        public static void WakeUpIdle()
        {
            NativeApi.Application_WakeUpIdle_();
        }
        
        public void Exit()
        {
            CheckDisposed();
            NativeApi.Application_Exit_(NativePointer);
        }
        
        public static void SuppressDiagnostics(int flags)
        {
            NativeApi.Application_SuppressDiagnostics_(flags);
        }
        
        public void BeginInvoke(System.Action action)
        {
            CheckDisposed();
            var actionCallbackHandle = new GCHandle();
            var actionSink = new NativeApi.PInvokeCallbackActionType(
                () =>
                {
                    action();
                    actionCallbackHandle.Free();
                });
            actionCallbackHandle = GCHandle.Alloc(actionSink);
            NativeApi.Application_BeginInvoke_(NativePointer, actionSink);
        }
        
        public void ProcessPendingEvents()
        {
            CheckDisposed();
            NativeApi.Application_ProcessPendingEvents_(NativePointer);
        }
        
        public bool HasPendingEvents()
        {
            CheckDisposed();
            return NativeApi.Application_HasPendingEvents_(NativePointer);
        }
        
        public System.IntPtr GetDisplayMode()
        {
            CheckDisposed();
            return NativeApi.Application_GetDisplayMode_(NativePointer);
        }
        
        public bool GetExitOnFrameDelete()
        {
            CheckDisposed();
            return NativeApi.Application_GetExitOnFrameDelete_(NativePointer);
        }
        
        public int GetLayoutDirection()
        {
            CheckDisposed();
            return NativeApi.Application_GetLayoutDirection_(NativePointer);
        }
        
        public bool GetUseBestVisual()
        {
            CheckDisposed();
            return NativeApi.Application_GetUseBestVisual_(NativePointer);
        }
        
        public bool IsActive()
        {
            CheckDisposed();
            return NativeApi.Application_IsActive_(NativePointer);
        }
        
        public bool SafeYield(System.IntPtr window, bool onlyIfNeeded)
        {
            CheckDisposed();
            return NativeApi.Application_SafeYield_(NativePointer, window, onlyIfNeeded);
        }
        
        public bool SafeYieldFor(System.IntPtr window, long eventsToProcess)
        {
            CheckDisposed();
            return NativeApi.Application_SafeYieldFor_(NativePointer, window, eventsToProcess);
        }
        
        public bool SetDisplayMode(System.IntPtr videoMode)
        {
            CheckDisposed();
            return NativeApi.Application_SetDisplayMode_(NativePointer, videoMode);
        }
        
        public void SetExitOnFrameDelete(bool flag)
        {
            CheckDisposed();
            NativeApi.Application_SetExitOnFrameDelete_(NativePointer, flag);
        }
        
        public bool SetNativeTheme(string theme)
        {
            CheckDisposed();
            return NativeApi.Application_SetNativeTheme_(NativePointer, theme);
        }
        
        public void SetTopWindow(System.IntPtr window)
        {
            CheckDisposed();
            NativeApi.Application_SetTopWindow_(NativePointer, window);
        }
        
        public void SetUseBestVisual(bool flag, bool forceTrueColour)
        {
            CheckDisposed();
            NativeApi.Application_SetUseBestVisual_(NativePointer, flag, forceTrueColour);
        }
        
        static GCHandle eventCallbackGCHandle;
        public static Application? GlobalObject;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.ApplicationEventCallbackType((obj, e, parameter) =>
                    UI.Application.HandleThreadExceptions(() =>
                    {
                        var w = NativeObject.GetFromNativePointer<Application>(obj, p => new Application(p));
                        w ??= GlobalObject;
                        if (w == null) return IntPtr.Zero;
                        return w.OnEvent(e, parameter);
                    }
                    )
                );
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.Application_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.ApplicationEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.ApplicationEvent.Idle:
                {
                    Idle?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.ApplicationEvent.LogMessage:
                {
                    LogMessage?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.ApplicationEvent.QueryEndSession:
                {
                    QueryEndSession?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.ApplicationEvent.EndSession:
                {
                    EndSession?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.ApplicationEvent.ActivateApp:
                {
                    ActivateApp?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.ApplicationEvent.Hibernate:
                {
                    Hibernate?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.ApplicationEvent.DialupConnected:
                {
                    DialupConnected?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.ApplicationEvent.DialupDisconnected:
                {
                    DialupDisconnected?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.ApplicationEvent.ExceptionInMainLoop:
                {
                    ExceptionInMainLoop?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.ApplicationEvent.UnhandledException:
                {
                    UnhandledException?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.ApplicationEvent.FatalException:
                {
                    FatalException?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.ApplicationEvent.AssertFailure:
                {
                    AssertFailure?.Invoke(); return IntPtr.Zero;
                }
                default: throw new Exception("Unexpected ApplicationEvent value: " + e);
            }
        }
        
        public Action? Idle;
        public Action? LogMessage;
        public Action? QueryEndSession;
        public Action? EndSession;
        public Action? ActivateApp;
        public Action? Hibernate;
        public Action? DialupConnected;
        public Action? DialupDisconnected;
        public Action? ExceptionInMainLoop;
        public Action? UnhandledException;
        public Action? FatalException;
        public Action? AssertFailure;
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr ApplicationEventCallbackType(IntPtr obj, ApplicationEvent e, IntPtr param);
            
            public enum ApplicationEvent
            {
                Idle,
                LogMessage,
                QueryEndSession,
                EndSession,
                ActivateApp,
                Hibernate,
                DialupConnected,
                DialupDisconnected,
                ExceptionInMainLoop,
                UnhandledException,
                FatalException,
                AssertFailure,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SetEventCallback_(ApplicationEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Application_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Application_GetEventArgString_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Application_GetName_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SetName_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Application_GetKeyboard_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Application_GetMouse_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Application_GetClipboard_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Application_GetDisplayName_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SetDisplayName_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Application_GetAppClassName_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SetAppClassName_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Application_GetVendorName_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SetVendorName_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Application_GetVendorDisplayName_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SetVendorDisplayName_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Application_GetInUixmlPreviewerMode_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SetInUixmlPreviewerMode_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Application_GetInvokeRequired_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_GetEventIdentifiers_(System.Int32[] eventIdentifiers, int eventIdentifiersCount);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_ThrowError_(int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SetSystemOptionInt_(string name, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_Run_(IntPtr obj, IntPtr window);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr Application_GetTopWindow_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_ExitMainLoop_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_WakeUpIdle_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_Exit_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SuppressDiagnostics_(int flags);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_BeginInvoke_(IntPtr obj, PInvokeCallbackActionType action);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_ProcessPendingEvents_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Application_HasPendingEvents_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr Application_GetDisplayMode_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Application_GetExitOnFrameDelete_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int Application_GetLayoutDirection_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Application_GetUseBestVisual_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Application_IsActive_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Application_SafeYield_(IntPtr obj, System.IntPtr window, bool onlyIfNeeded);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Application_SafeYieldFor_(IntPtr obj, System.IntPtr window, long eventsToProcess);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Application_SetDisplayMode_(IntPtr obj, System.IntPtr videoMode);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SetExitOnFrameDelete_(IntPtr obj, bool flag);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Application_SetNativeTheme_(IntPtr obj, string theme);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SetTopWindow_(IntPtr obj, System.IntPtr window);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Application_SetUseBestVisual_(IntPtr obj, bool flag, bool forceTrueColour);
            
        }
    }
}
