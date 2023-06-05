// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>

#pragma once

#include "WebBrowser.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API WebBrowser* WebBrowser_Create_()
{
    return MarshalExceptions<WebBrowser*>([&](){
            return new WebBrowser();
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetCanGoBack_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetCanGoBack();
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetCanGoForward_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetCanGoForward();
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetCanCut_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetCanCut();
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetCanCopy_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetCanCopy();
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetCanUndo_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetCanUndo();
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetCanRedo_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetCanRedo();
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetIsBusy_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetIsBusy();
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetCanPaste_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetCanPaste();
        });
}

ALTERNET_UI_API float WebBrowser_GetZoomFactor_(WebBrowser* obj)
{
    return MarshalExceptions<float>([&](){
            return obj->GetZoomFactor();
        });
}

ALTERNET_UI_API void WebBrowser_SetZoomFactor_(WebBrowser* obj, float value)
{
    MarshalExceptions<void>([&](){
            obj->SetZoomFactor(value);
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetHasSelection_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetHasSelection();
        });
}

ALTERNET_UI_API char16_t* WebBrowser_GetSelectedSource_(WebBrowser* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetSelectedSource());
        });
}

ALTERNET_UI_API char16_t* WebBrowser_GetSelectedText_(WebBrowser* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetSelectedText());
        });
}

ALTERNET_UI_API char16_t* WebBrowser_GetPageSource_(WebBrowser* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetPageSource());
        });
}

ALTERNET_UI_API char16_t* WebBrowser_GetPageText_(WebBrowser* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetPageText());
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetAccessToDevToolsEnabled_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetAccessToDevToolsEnabled();
        });
}

ALTERNET_UI_API void WebBrowser_SetAccessToDevToolsEnabled_(WebBrowser* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetAccessToDevToolsEnabled(value);
        });
}

ALTERNET_UI_API char16_t* WebBrowser_GetUserAgent_(WebBrowser* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetUserAgent());
        });
}

ALTERNET_UI_API void WebBrowser_SetUserAgent_(WebBrowser* obj, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetUserAgent(value);
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetContextMenuEnabled_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetContextMenuEnabled();
        });
}

ALTERNET_UI_API void WebBrowser_SetContextMenuEnabled_(WebBrowser* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetContextMenuEnabled(value);
        });
}

ALTERNET_UI_API c_bool WebBrowser_GetEditable_(WebBrowser* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetEditable();
        });
}

ALTERNET_UI_API void WebBrowser_SetEditable_(WebBrowser* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetEditable(value);
        });
}

ALTERNET_UI_API int WebBrowser_GetZoom_(WebBrowser* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetZoom();
        });
}

ALTERNET_UI_API void WebBrowser_SetZoom_(WebBrowser* obj, int value)
{
    MarshalExceptions<void>([&](){
            obj->SetZoom(value);
        });
}

ALTERNET_UI_API void WebBrowser_SetDefaultUserAgent_(const char16_t* value)
{
    MarshalExceptions<void>([&](){
            WebBrowser::SetDefaultUserAgent(value);
        });
}

ALTERNET_UI_API void WebBrowser_SetDefaultScriptMesageName_(const char16_t* value)
{
    MarshalExceptions<void>([&](){
            WebBrowser::SetDefaultScriptMesageName(value);
        });
}

ALTERNET_UI_API void WebBrowser_SetDefaultFSNameMemory_(const char16_t* value)
{
    MarshalExceptions<void>([&](){
            WebBrowser::SetDefaultFSNameMemory(value);
        });
}

ALTERNET_UI_API void WebBrowser_SetDefaultFSNameArchive_(const char16_t* value)
{
    MarshalExceptions<void>([&](){
            WebBrowser::SetDefaultFSNameArchive(value);
        });
}

ALTERNET_UI_API char16_t* WebBrowser_DoCommand_(WebBrowser* obj, const char16_t* cmdName, const char16_t* cmdParam1, const char16_t* cmdParam2)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->DoCommand(cmdName, cmdParam1, cmdParam2));
        });
}

ALTERNET_UI_API char16_t* WebBrowser_DoCommandGlobal_(const char16_t* cmdName, const char16_t* cmdParam1, const char16_t* cmdParam2)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(WebBrowser::DoCommandGlobal(cmdName, cmdParam1, cmdParam2));
        });
}

ALTERNET_UI_API void* WebBrowser_GetNativeBackend_(WebBrowser* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetNativeBackend();
        });
}

ALTERNET_UI_API void WebBrowser_GoBack_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->GoBack();
        });
}

ALTERNET_UI_API void WebBrowser_GoForward_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->GoForward();
        });
}

ALTERNET_UI_API void WebBrowser_Stop_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->Stop();
        });
}

ALTERNET_UI_API void WebBrowser_ClearSelection_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->ClearSelection();
        });
}

ALTERNET_UI_API void WebBrowser_Copy_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->Copy();
        });
}

ALTERNET_UI_API void WebBrowser_Paste_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->Paste();
        });
}

ALTERNET_UI_API void WebBrowser_Cut_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->Cut();
        });
}

ALTERNET_UI_API void WebBrowser_ClearHistory_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->ClearHistory();
        });
}

ALTERNET_UI_API void WebBrowser_EnableHistory_(WebBrowser* obj, c_bool enable)
{
    MarshalExceptions<void>([&](){
            obj->EnableHistory(enable);
        });
}

ALTERNET_UI_API void WebBrowser_ReloadDefault_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->ReloadDefault();
        });
}

ALTERNET_UI_API void WebBrowser_Reload_(WebBrowser* obj, c_bool noCache)
{
    MarshalExceptions<void>([&](){
            obj->Reload(noCache);
        });
}

ALTERNET_UI_API void WebBrowser_SelectAll_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->SelectAll();
        });
}

ALTERNET_UI_API void WebBrowser_DeleteSelection_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->DeleteSelection();
        });
}

ALTERNET_UI_API void WebBrowser_Undo_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->Undo();
        });
}

ALTERNET_UI_API void WebBrowser_Redo_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->Redo();
        });
}

ALTERNET_UI_API void WebBrowser_Print_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->Print();
        });
}

ALTERNET_UI_API void WebBrowser_RemoveAllUserScripts_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->RemoveAllUserScripts();
        });
}

ALTERNET_UI_API c_bool WebBrowser_AddScriptMessageHandler_(WebBrowser* obj, const char16_t* name)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->AddScriptMessageHandler(name);
        });
}

ALTERNET_UI_API c_bool WebBrowser_RemoveScriptMessageHandler_(WebBrowser* obj, const char16_t* name)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->RemoveScriptMessageHandler(name);
        });
}

ALTERNET_UI_API void WebBrowser_RunScriptAsync_(WebBrowser* obj, const char16_t* javascript, void* clientData)
{
    MarshalExceptions<void>([&](){
            obj->RunScriptAsync(javascript, clientData);
        });
}

ALTERNET_UI_API void WebBrowser_CreateBackend_(WebBrowser* obj)
{
    MarshalExceptions<void>([&](){
            obj->CreateBackend();
        });
}

ALTERNET_UI_API int WebBrowser_GetBackendOS_()
{
    return MarshalExceptions<int>([&](){
            return WebBrowser::GetBackendOS();
        });
}

ALTERNET_UI_API void WebBrowser_SetEdgePath_(const char16_t* path)
{
    MarshalExceptions<void>([&](){
            WebBrowser::SetEdgePath(path);
        });
}

ALTERNET_UI_API char16_t* WebBrowser_GetCurrentTitle_(WebBrowser* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetCurrentTitle());
        });
}

ALTERNET_UI_API char16_t* WebBrowser_GetCurrentURL_(WebBrowser* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetCurrentURL());
        });
}

ALTERNET_UI_API void WebBrowser_LoadURL_(WebBrowser* obj, const char16_t* url)
{
    MarshalExceptions<void>([&](){
            obj->LoadURL(url);
        });
}

ALTERNET_UI_API char16_t* WebBrowser_RunScript_(WebBrowser* obj, const char16_t* javascript)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->RunScript(javascript));
        });
}

ALTERNET_UI_API void WebBrowser_SetPage_(WebBrowser* obj, const char16_t* text, const char16_t* baseUrl)
{
    MarshalExceptions<void>([&](){
            obj->SetPage(text, baseUrl);
        });
}

ALTERNET_UI_API c_bool WebBrowser_AddUserScript_(WebBrowser* obj, const char16_t* javascript, int injectionTime)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->AddUserScript(javascript, injectionTime);
        });
}

ALTERNET_UI_API void WebBrowser_SetEventCallback_(WebBrowser::WebBrowserEventCallbackType callback)
{
    WebBrowser::SetEventCallback(callback);
}

