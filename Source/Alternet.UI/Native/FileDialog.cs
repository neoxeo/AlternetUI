// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class FileDialog : NativeObject
    {
        static FileDialog()
        {
        }
        
        public FileDialog()
        {
            SetNativePointer(NativeApi.FileDialog_Create_());
        }
        
        public FileDialog(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public FileDialogMode Mode
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FileDialog_GetMode_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FileDialog_SetMode_(NativePointer, value);
            }
        }
        
        public string InitialDirectory
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FileDialog_GetInitialDirectory_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FileDialog_SetInitialDirectory_(NativePointer, value);
            }
        }
        
        public string Title
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FileDialog_GetTitle_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FileDialog_SetTitle_(NativePointer, value);
            }
        }
        
        public string Filter
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FileDialog_GetFilter_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FileDialog_SetFilter_(NativePointer, value);
            }
        }
        
        public int SelectedFilterIndex
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FileDialog_GetSelectedFilterIndex_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FileDialog_SetSelectedFilterIndex_(NativePointer, value);
            }
        }
        
        public string FileName
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FileDialog_GetFileName_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FileDialog_SetFileName_(NativePointer, value);
            }
        }
        
        public bool AllowMultipleSelection
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FileDialog_GetAllowMultipleSelection_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FileDialog_SetAllowMultipleSelection_(NativePointer, value);
            }
        }
        
        public System.String[] FileNames
        {
            get
            {
                CheckDisposed();
                var array = NativeApi.FileDialog_OpenFileNamesArray_(NativePointer);
                try
                {
                    var count = NativeApi.FileDialog_GetFileNamesItemCount_(NativePointer, array);
                    var result = new System.Collections.Generic.List<string>(count);
                    for (int i = 0; i < count; i++)
                    {
                        var n = NativeApi.FileDialog_GetFileNamesItemAt_(NativePointer, array, i);
                        var item = n;
                        result.Add(item);
                    }
                    return result.ToArray();
                }
                finally
                {
                    NativeApi.FileDialog_CloseFileNamesArray_(NativePointer, array);
                }
            }
            
        }
        
        public ModalResult ShowModal()
        {
            CheckDisposed();
            var n = NativeApi.FileDialog_ShowModal_(NativePointer);
            var m = n;
            return m;
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr FileDialog_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern FileDialogMode FileDialog_GetMode_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FileDialog_SetMode_(IntPtr obj, FileDialogMode value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string FileDialog_GetInitialDirectory_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FileDialog_SetInitialDirectory_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string FileDialog_GetTitle_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FileDialog_SetTitle_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string FileDialog_GetFilter_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FileDialog_SetFilter_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int FileDialog_GetSelectedFilterIndex_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FileDialog_SetSelectedFilterIndex_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string FileDialog_GetFileName_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FileDialog_SetFileName_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool FileDialog_GetAllowMultipleSelection_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FileDialog_SetAllowMultipleSelection_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr FileDialog_OpenFileNamesArray_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int FileDialog_GetFileNamesItemCount_(IntPtr obj, System.IntPtr array);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string FileDialog_GetFileNamesItemAt_(IntPtr obj, System.IntPtr array, int index);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FileDialog_CloseFileNamesArray_(IntPtr obj, System.IntPtr array);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern ModalResult FileDialog_ShowModal_(IntPtr obj);
            
        }
    }
}
