// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "AuiManager.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API AuiManager* AuiManager_Create_()
{
    return new AuiManager();
}

ALTERNET_UI_API void AuiManager_Delete_(void* handle)
{
    AuiManager::Delete(handle);
}

ALTERNET_UI_API void* AuiManager_CreateAuiManager_()
{
    return AuiManager::CreateAuiManager();
}

ALTERNET_UI_API void* AuiManager_CreateAuiManager2_(void* managedWnd, uint32_t flags)
{
    return AuiManager::CreateAuiManager2(managedWnd, flags);
}

ALTERNET_UI_API void AuiManager_UnInit_(void* handle)
{
    AuiManager::UnInit(handle);
}

ALTERNET_UI_API void AuiManager_SetFlags_(void* handle, uint32_t flags)
{
    AuiManager::SetFlags(handle, flags);
}

ALTERNET_UI_API uint32_t AuiManager_GetFlags_(void* handle)
{
    return AuiManager::GetFlags(handle);
}

ALTERNET_UI_API c_bool AuiManager_AlwaysUsesLiveResize_()
{
    return AuiManager::AlwaysUsesLiveResize();
}

ALTERNET_UI_API c_bool AuiManager_HasLiveResize_(void* handle)
{
    return AuiManager::HasLiveResize(handle);
}

ALTERNET_UI_API void AuiManager_SetManagedWindow_(void* handle, void* managedWnd)
{
    AuiManager::SetManagedWindow(handle, managedWnd);
}

ALTERNET_UI_API void* AuiManager_GetManagedWindow_(void* handle)
{
    return AuiManager::GetManagedWindow(handle);
}

ALTERNET_UI_API void* AuiManager_GetManager_(void* window)
{
    return AuiManager::GetManager(window);
}

ALTERNET_UI_API void AuiManager_SetArtProvider_(void* handle, void* artProvider)
{
    AuiManager::SetArtProvider(handle, artProvider);
}

ALTERNET_UI_API void* AuiManager_GetArtProvider_(void* handle)
{
    return AuiManager::GetArtProvider(handle);
}

ALTERNET_UI_API c_bool AuiManager_DetachPane_(void* handle, void* window)
{
    return AuiManager::DetachPane(handle, window);
}

ALTERNET_UI_API void AuiManager_Update_(void* handle)
{
    AuiManager::Update(handle);
}

ALTERNET_UI_API char16_t* AuiManager_SavePerspective_(void* handle)
{
    return AllocPInvokeReturnString(AuiManager::SavePerspective(handle));
}

ALTERNET_UI_API c_bool AuiManager_LoadPerspective_(void* handle, const char16_t* perspective, c_bool update)
{
    return AuiManager::LoadPerspective(handle, perspective, update);
}

ALTERNET_UI_API void AuiManager_SetDockSizeConstraint_(void* handle, double widthPct, double heightPct)
{
    AuiManager::SetDockSizeConstraint(handle, widthPct, heightPct);
}

ALTERNET_UI_API void AuiManager_RestoreMaximizedPane_(void* handle)
{
    AuiManager::RestoreMaximizedPane(handle);
}

ALTERNET_UI_API void* AuiManager_GetPane_(void* handle, void* window)
{
    return AuiManager::GetPane(handle, window);
}

ALTERNET_UI_API void* AuiManager_GetPaneByName_(void* handle, const char16_t* name)
{
    return AuiManager::GetPaneByName(handle, name);
}

ALTERNET_UI_API c_bool AuiManager_AddPane_(void* handle, void* window, void* paneInfo)
{
    return AuiManager::AddPane(handle, window, paneInfo);
}

ALTERNET_UI_API c_bool AuiManager_AddPane2_(void* handle, void* window, void* paneInfo, double dropPosX, double dropPosY)
{
    return AuiManager::AddPane2(handle, window, paneInfo, dropPosX, dropPosY);
}

ALTERNET_UI_API c_bool AuiManager_AddPane3_(void* handle, void* window, int direction, const char16_t* caption)
{
    return AuiManager::AddPane3(handle, window, direction, caption);
}

ALTERNET_UI_API c_bool AuiManager_InsertPane_(void* handle, void* window, void* insertLocPaneInfo, int insertLevel)
{
    return AuiManager::InsertPane(handle, window, insertLocPaneInfo, insertLevel);
}

ALTERNET_UI_API char16_t* AuiManager_SavePaneInfo_(void* handle, void* paneInfo)
{
    return AllocPInvokeReturnString(AuiManager::SavePaneInfo(handle, paneInfo));
}

ALTERNET_UI_API void AuiManager_LoadPaneInfo_(void* handle, const char16_t* panePart, void* paneInfo)
{
    AuiManager::LoadPaneInfo(handle, panePart, paneInfo);
}

ALTERNET_UI_API SizeD_C AuiManager_GetDockSizeConstraint_(void* handle)
{
    return AuiManager::GetDockSizeConstraint(handle);
}

ALTERNET_UI_API void AuiManager_ClosePane_(void* handle, void* paneInfo)
{
    AuiManager::ClosePane(handle, paneInfo);
}

ALTERNET_UI_API void AuiManager_MaximizePane_(void* handle, void* paneInfo)
{
    AuiManager::MaximizePane(handle, paneInfo);
}

ALTERNET_UI_API void AuiManager_RestorePane_(void* handle, void* paneInfo)
{
    AuiManager::RestorePane(handle, paneInfo);
}

ALTERNET_UI_API void* AuiManager_CreateFloatingFrame_(void* handle, void* parentWindow, void* paneInfo)
{
    return AuiManager::CreateFloatingFrame(handle, parentWindow, paneInfo);
}

ALTERNET_UI_API c_bool AuiManager_CanDockPanel_(void* handle, void* paneInfo)
{
    return AuiManager::CanDockPanel(handle, paneInfo);
}

