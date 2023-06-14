#pragma once



#include "Common.h"
#include "ApiTypes.h"
#include "Object.h"
#include "Control.h"
#include "Exceptions.h"

#include "wx/webview.h"

namespace Alternet::UI
{
    enum WebBrowserBackend
    {
        WEBBROWSER_BACKEND_DEFAULT = 0,
        WEBBROWSER_BACKEND_IE = 1,
        WEBBROWSER_BACKEND_IELATEST = 2,
        WEBBROWSER_BACKEND_EDGE = 3,
        WEBBROWSER_BACKEND_WEBKIT = 4,
    };
    enum WebBrowserBackendOS
    {
        WEBBROWSER_BACKEND_OS_UNKNOWN = 0,
        WEBBROWSER_BACKEND_OS_OSX = 1,
        WEBBROWSER_BACKEND_OS_GTK = 2,
        WEBBROWSER_BACKEND_OS_MSW = 3,
    };

    class WebBrowser : public Control
    {
#include "Api/WebBrowser.inc"
    private:
        static wxString DefaultUserAgent;
        static wxString DefaultScriptMesageName;
        static wxString DefaultFSNameMemory;
        static wxString DefaultFSNameArchive;
        static wxString DefaultFSNameCustom;
        static WebBrowserBackend DefaultBackend;
        static wxString DefaultPage;
        static bool IELatest;
        static wxString WebViewBackendNameFromId(WebBrowserBackend id);

        WebBrowserBackend Backend;
        int preferredColorScheme = 0;
        wxWebView* webView;
        wxWindow* webViewParent;
        bool DefaultUserAgentDone = false;
        bool DefaultScriptMesageNameDone = false;
        bool DefaultFSNameMemoryDone = false;
        bool DefaultFSNameArchiveDone = false;
        bool DefaultFSNameCustomDone = false;

        bool IsBackendIE();
        void RaiseEventEx(WebBrowserEvent eventID, wxWebViewEvent& event,bool canVeto=FALSE);
        void RaiseSimpleEvent(WebBrowserEvent eventId, bool canVeto = FALSE);
        
#if defined(__WXMSW__)
       bool IERunScript(const wxString& javascript, wxString* output);
       int IEGetScriptErrorsSuppressed();
       void IEShowPrintPreviewDialog();
       void IESetScriptErrorsSuppressed(bool value);
#endif

        void ProcessDefaultsOnCreate(bool before);
    public:
        WebBrowserBackend GetBackend();

        wxWindow* CreateWxWindowCore(wxWindow* parent) override;
        wxWebView* GetWebViewCtrl();

        void RegisterHandlerZip(const string& schemeName);
        void RegisterHandlerMemory(const string& schemeName);

        static void SetDefaultPage(const string& value);
        static bool IsBackendAvailable(const string& value);
        static bool IsBackendIEAvailable();
        static bool IsBackendEdgeAvailable();
        static bool IsBackendWebKitAvailable();
        static void SetBackend(WebBrowserBackend value);
        static string GetBackendVersionString(WebBrowserBackend id);
        static string GetLibraryVersionString();

        bool CanSetZoomType(wxWebViewZoomType type);
        wxWebViewZoomType GetZoomType();
        void SetZoomType(wxWebViewZoomType zoomType);

        int Find(const string& text, int flags);
    protected:
        void OnWxWindowCreated() override;

    private:
        void OnBeforeBrowserCreate(wxWebViewEvent& event);
        void OnNavigating(wxWebViewEvent& event);
        void OnNavigated(wxWebViewEvent& event);
        void OnLoaded(wxWebViewEvent& event);
        void OnError(wxWebViewEvent& event);
        void OnNewWindow(wxWebViewEvent& event);
        void OnTitleChanged(wxWebViewEvent& event);
        void OnFullScreenChanged(wxWebViewEvent& event);
        void OnScriptMessageReceived(wxWebViewEvent& event);
        void OnScriptResult(wxWebViewEvent& event);

    };
}


