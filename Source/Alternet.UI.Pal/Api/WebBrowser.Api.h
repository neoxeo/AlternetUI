// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "WebBrowser.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API WebBrowser* WebBrowser_Create_()
{
    return new WebBrowser();
}

ALTERNET_UI_API c_bool WebBrowser_GetHasBorder_(WebBrowser* obj)
{
    return obj->GetHasBorder();
}

ALTERNET_UI_API void WebBrowser_SetHasBorder_(WebBrowser* obj, c_bool value)
{
    obj->SetHasBorder(value);
}

ALTERNET_UI_API c_bool WebBrowser_GetCanGoBack_(WebBrowser* obj)
{
    return obj->GetCanGoBack();
}

ALTERNET_UI_API c_bool WebBrowser_GetCanGoForward_(WebBrowser* obj)
{
    return obj->GetCanGoForward();
}

ALTERNET_UI_API c_bool WebBrowser_GetCanCut_(WebBrowser* obj)
{
    return obj->GetCanCut();
}

ALTERNET_UI_API c_bool WebBrowser_GetCanCopy_(WebBrowser* obj)
{
    return obj->GetCanCopy();
}

ALTERNET_UI_API c_bool WebBrowser_GetCanUndo_(WebBrowser* obj)
{
    return obj->GetCanUndo();
}

ALTERNET_UI_API c_bool WebBrowser_GetCanRedo_(WebBrowser* obj)
{
    return obj->GetCanRedo();
}

ALTERNET_UI_API c_bool WebBrowser_GetIsBusy_(WebBrowser* obj)
{
    return obj->GetIsBusy();
}

ALTERNET_UI_API c_bool WebBrowser_GetCanPaste_(WebBrowser* obj)
{
    return obj->GetCanPaste();
}

ALTERNET_UI_API float WebBrowser_GetZoomFactor_(WebBrowser* obj)
{
    return obj->GetZoomFactor();
}

ALTERNET_UI_API void WebBrowser_SetZoomFactor_(WebBrowser* obj, float value)
{
    obj->SetZoomFactor(value);
}

ALTERNET_UI_API c_bool WebBrowser_GetHasSelection_(WebBrowser* obj)
{
    return obj->GetHasSelection();
}

ALTERNET_UI_API char16_t* WebBrowser_GetSelectedSource_(WebBrowser* obj)
{
    return AllocPInvokeReturnString(obj->GetSelectedSource());
}

ALTERNET_UI_API char16_t* WebBrowser_GetSelectedText_(WebBrowser* obj)
{
    return AllocPInvokeReturnString(obj->GetSelectedText());
}

ALTERNET_UI_API char16_t* WebBrowser_GetPageSource_(WebBrowser* obj)
{
    return AllocPInvokeReturnString(obj->GetPageSource());
}

ALTERNET_UI_API char16_t* WebBrowser_GetPageText_(WebBrowser* obj)
{
    return AllocPInvokeReturnString(obj->GetPageText());
}

ALTERNET_UI_API c_bool WebBrowser_GetAccessToDevToolsEnabled_(WebBrowser* obj)
{
    return obj->GetAccessToDevToolsEnabled();
}

ALTERNET_UI_API void WebBrowser_SetAccessToDevToolsEnabled_(WebBrowser* obj, c_bool value)
{
    obj->SetAccessToDevToolsEnabled(value);
}

ALTERNET_UI_API int WebBrowser_GetPreferredColorScheme_(WebBrowser* obj)
{
    return obj->GetPreferredColorScheme();
}

ALTERNET_UI_API void WebBrowser_SetPreferredColorScheme_(WebBrowser* obj, int value)
{
    obj->SetPreferredColorScheme(value);
}

ALTERNET_UI_API char16_t* WebBrowser_GetUserAgent_(WebBrowser* obj)
{
    return AllocPInvokeReturnString(obj->GetUserAgent());
}

ALTERNET_UI_API void WebBrowser_SetUserAgent_(WebBrowser* obj, const char16_t* value)
{
    obj->SetUserAgent(value);
}

ALTERNET_UI_API c_bool WebBrowser_GetContextMenuEnabled_(WebBrowser* obj)
{
    return obj->GetContextMenuEnabled();
}

ALTERNET_UI_API void WebBrowser_SetContextMenuEnabled_(WebBrowser* obj, c_bool value)
{
    obj->SetContextMenuEnabled(value);
}

ALTERNET_UI_API c_bool WebBrowser_GetEditable_(WebBrowser* obj)
{
    return obj->GetEditable();
}

ALTERNET_UI_API void WebBrowser_SetEditable_(WebBrowser* obj, c_bool value)
{
    obj->SetEditable(value);
}

ALTERNET_UI_API int WebBrowser_GetZoom_(WebBrowser* obj)
{
    return obj->GetZoom();
}

ALTERNET_UI_API void WebBrowser_SetZoom_(WebBrowser* obj, int value)
{
    obj->SetZoom(value);
}

ALTERNET_UI_API void* WebBrowser_CreateWebBrowser_(const char16_t* url)
{
    return WebBrowser::CreateWebBrowser(url);
}

ALTERNET_UI_API void WebBrowser_SetDefaultUserAgent_(const char16_t* value)
{
    WebBrowser::SetDefaultUserAgent(value);
}

ALTERNET_UI_API void WebBrowser_SetDefaultScriptMesageName_(const char16_t* value)
{
    WebBrowser::SetDefaultScriptMesageName(value);
}

ALTERNET_UI_API void WebBrowser_SetDefaultFSNameMemory_(const char16_t* value)
{
    WebBrowser::SetDefaultFSNameMemory(value);
}

ALTERNET_UI_API void WebBrowser_SetDefaultFSNameArchive_(const char16_t* value)
{
    WebBrowser::SetDefaultFSNameArchive(value);
}

ALTERNET_UI_API char16_t* WebBrowser_DoCommand_(WebBrowser* obj, const char16_t* cmdName, const char16_t* cmdParam1, const char16_t* cmdParam2)
{
    return AllocPInvokeReturnString(obj->DoCommand(cmdName, cmdParam1, cmdParam2));
}

ALTERNET_UI_API char16_t* WebBrowser_DoCommandGlobal_(const char16_t* cmdName, const char16_t* cmdParam1, const char16_t* cmdParam2)
{
    return AllocPInvokeReturnString(WebBrowser::DoCommandGlobal(cmdName, cmdParam1, cmdParam2));
}

ALTERNET_UI_API void WebBrowser_SetVirtualHostNameToFolderMapping_(WebBrowser* obj, const char16_t* hostName, const char16_t* folderPath, int accessKind)
{
    obj->SetVirtualHostNameToFolderMapping(hostName, folderPath, accessKind);
}

ALTERNET_UI_API void* WebBrowser_GetNativeBackend_(WebBrowser* obj)
{
    return obj->GetNativeBackend();
}

ALTERNET_UI_API void WebBrowser_GoBack_(WebBrowser* obj)
{
    obj->GoBack();
}

ALTERNET_UI_API void WebBrowser_GoForward_(WebBrowser* obj)
{
    obj->GoForward();
}

ALTERNET_UI_API void WebBrowser_Stop_(WebBrowser* obj)
{
    obj->Stop();
}

ALTERNET_UI_API void WebBrowser_ClearSelection_(WebBrowser* obj)
{
    obj->ClearSelection();
}

ALTERNET_UI_API void WebBrowser_Copy_(WebBrowser* obj)
{
    obj->Copy();
}

ALTERNET_UI_API void WebBrowser_Paste_(WebBrowser* obj)
{
    obj->Paste();
}

ALTERNET_UI_API void WebBrowser_Cut_(WebBrowser* obj)
{
    obj->Cut();
}

ALTERNET_UI_API void WebBrowser_ClearHistory_(WebBrowser* obj)
{
    obj->ClearHistory();
}

ALTERNET_UI_API void WebBrowser_EnableHistory_(WebBrowser* obj, c_bool enable)
{
    obj->EnableHistory(enable);
}

ALTERNET_UI_API void WebBrowser_ReloadDefault_(WebBrowser* obj)
{
    obj->ReloadDefault();
}

ALTERNET_UI_API void WebBrowser_Reload_(WebBrowser* obj, c_bool noCache)
{
    obj->Reload(noCache);
}

ALTERNET_UI_API void WebBrowser_SelectAll_(WebBrowser* obj)
{
    obj->SelectAll();
}

ALTERNET_UI_API void WebBrowser_DeleteSelection_(WebBrowser* obj)
{
    obj->DeleteSelection();
}

ALTERNET_UI_API void WebBrowser_Undo_(WebBrowser* obj)
{
    obj->Undo();
}

ALTERNET_UI_API void WebBrowser_Redo_(WebBrowser* obj)
{
    obj->Redo();
}

ALTERNET_UI_API void WebBrowser_Print_(WebBrowser* obj)
{
    obj->Print();
}

ALTERNET_UI_API void WebBrowser_RemoveAllUserScripts_(WebBrowser* obj)
{
    obj->RemoveAllUserScripts();
}

ALTERNET_UI_API c_bool WebBrowser_AddScriptMessageHandler_(WebBrowser* obj, const char16_t* name)
{
    return obj->AddScriptMessageHandler(name);
}

ALTERNET_UI_API c_bool WebBrowser_RemoveScriptMessageHandler_(WebBrowser* obj, const char16_t* name)
{
    return obj->RemoveScriptMessageHandler(name);
}

ALTERNET_UI_API void WebBrowser_RunScriptAsync_(WebBrowser* obj, const char16_t* javascript, void* clientData)
{
    obj->RunScriptAsync(javascript, clientData);
}

ALTERNET_UI_API void WebBrowser_CreateBackend_(WebBrowser* obj)
{
    obj->CreateBackend();
}

ALTERNET_UI_API int WebBrowser_GetBackendOS_()
{
    return WebBrowser::GetBackendOS();
}

ALTERNET_UI_API void WebBrowser_SetEdgePath_(const char16_t* path)
{
    WebBrowser::SetEdgePath(path);
}

ALTERNET_UI_API char16_t* WebBrowser_GetCurrentTitle_(WebBrowser* obj)
{
    return AllocPInvokeReturnString(obj->GetCurrentTitle());
}

ALTERNET_UI_API char16_t* WebBrowser_GetCurrentURL_(WebBrowser* obj)
{
    return AllocPInvokeReturnString(obj->GetCurrentURL());
}

ALTERNET_UI_API void WebBrowser_LoadURL_(WebBrowser* obj, const char16_t* url)
{
    obj->LoadURL(url);
}

ALTERNET_UI_API char16_t* WebBrowser_RunScript_(WebBrowser* obj, const char16_t* javascript)
{
    return AllocPInvokeReturnString(obj->RunScript(javascript));
}

ALTERNET_UI_API void WebBrowser_SetPage_(WebBrowser* obj, const char16_t* text, const char16_t* baseUrl)
{
    obj->SetPage(text, baseUrl);
}

ALTERNET_UI_API c_bool WebBrowser_AddUserScript_(WebBrowser* obj, const char16_t* javascript, int injectionTime)
{
    return obj->AddUserScript(javascript, injectionTime);
}

ALTERNET_UI_API void WebBrowser_SetEventCallback_(WebBrowser::WebBrowserEventCallbackType callback)
{
    WebBrowser::SetEventCallback(callback);
}

