// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2023 AlterNET Software.</auto-generated>

#pragma once

#include "AuiPaneInfo.h"
#include "ImageSet.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API AuiPaneInfo* AuiPaneInfo_Create_()
{
    return new AuiPaneInfo();
}

ALTERNET_UI_API SizeI_C AuiPaneInfo_GetBestSize_(void* handle)
{
    return AuiPaneInfo::GetBestSize(handle);
}

ALTERNET_UI_API SizeI_C AuiPaneInfo_GetMinSize_(void* handle)
{
    return AuiPaneInfo::GetMinSize(handle);
}

ALTERNET_UI_API SizeI_C AuiPaneInfo_GetMaxSize_(void* handle)
{
    return AuiPaneInfo::GetMaxSize(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Delete_(void* handle)
{
    AuiPaneInfo::Delete(handle);
}

ALTERNET_UI_API void* AuiPaneInfo_CreateAuiPaneInfo_()
{
    return AuiPaneInfo::CreateAuiPaneInfo();
}

ALTERNET_UI_API void AuiPaneInfo_SafeSet_(void* handle, void* source)
{
    AuiPaneInfo::SafeSet(handle, source);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsOk_(void* handle)
{
    return AuiPaneInfo::IsOk(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsFixed_(void* handle)
{
    return AuiPaneInfo::IsFixed(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsResizable_(void* handle)
{
    return AuiPaneInfo::IsResizable(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsShown_(void* handle)
{
    return AuiPaneInfo::IsShown(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsFloating_(void* handle)
{
    return AuiPaneInfo::IsFloating(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsDocked_(void* handle)
{
    return AuiPaneInfo::IsDocked(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsToolbar_(void* handle)
{
    return AuiPaneInfo::IsToolbar(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsTopDockable_(void* handle)
{
    return AuiPaneInfo::IsTopDockable(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsBottomDockable_(void* handle)
{
    return AuiPaneInfo::IsBottomDockable(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsLeftDockable_(void* handle)
{
    return AuiPaneInfo::IsLeftDockable(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsRightDockable_(void* handle)
{
    return AuiPaneInfo::IsRightDockable(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsDockable_(void* handle)
{
    return AuiPaneInfo::IsDockable(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsFloatable_(void* handle)
{
    return AuiPaneInfo::IsFloatable(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsMovable_(void* handle)
{
    return AuiPaneInfo::IsMovable(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsDestroyOnClose_(void* handle)
{
    return AuiPaneInfo::IsDestroyOnClose(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsMaximized_(void* handle)
{
    return AuiPaneInfo::IsMaximized(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_HasCaption_(void* handle)
{
    return AuiPaneInfo::HasCaption(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_HasGripper_(void* handle)
{
    return AuiPaneInfo::HasGripper(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_HasBorder_(void* handle)
{
    return AuiPaneInfo::HasBorder(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_HasCloseButton_(void* handle)
{
    return AuiPaneInfo::HasCloseButton(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_HasMaximizeButton_(void* handle)
{
    return AuiPaneInfo::HasMaximizeButton(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_HasMinimizeButton_(void* handle)
{
    return AuiPaneInfo::HasMinimizeButton(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_HasPinButton_(void* handle)
{
    return AuiPaneInfo::HasPinButton(handle);
}

ALTERNET_UI_API c_bool AuiPaneInfo_HasGripperTop_(void* handle)
{
    return AuiPaneInfo::HasGripperTop(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Window_(void* handle, void* window)
{
    AuiPaneInfo::Window(handle, window);
}

ALTERNET_UI_API void AuiPaneInfo_Name_(void* handle, const char16_t* value)
{
    AuiPaneInfo::Name(handle, value);
}

ALTERNET_UI_API void AuiPaneInfo_Caption_(void* handle, const char16_t* value)
{
    AuiPaneInfo::Caption(handle, value);
}

ALTERNET_UI_API void AuiPaneInfo_Image_(void* handle, ImageSet* bitmap)
{
    AuiPaneInfo::Image(handle, bitmap);
}

ALTERNET_UI_API void AuiPaneInfo_Left_(void* handle)
{
    AuiPaneInfo::Left(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Right_(void* handle)
{
    AuiPaneInfo::Right(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Top_(void* handle)
{
    AuiPaneInfo::Top(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Bottom_(void* handle)
{
    AuiPaneInfo::Bottom(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Center_(void* handle)
{
    AuiPaneInfo::Center(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Direction_(void* handle, int direction)
{
    AuiPaneInfo::Direction(handle, direction);
}

ALTERNET_UI_API void AuiPaneInfo_Layer_(void* handle, int layer)
{
    AuiPaneInfo::Layer(handle, layer);
}

ALTERNET_UI_API void AuiPaneInfo_Row_(void* handle, int row)
{
    AuiPaneInfo::Row(handle, row);
}

ALTERNET_UI_API void AuiPaneInfo_Position_(void* handle, int pos)
{
    AuiPaneInfo::Position(handle, pos);
}

ALTERNET_UI_API void AuiPaneInfo_BestSize_(void* handle, int x, int y)
{
    AuiPaneInfo::BestSize(handle, x, y);
}

ALTERNET_UI_API void AuiPaneInfo_MinSize_(void* handle, int x, int y)
{
    AuiPaneInfo::MinSize(handle, x, y);
}

ALTERNET_UI_API void AuiPaneInfo_MaxSize_(void* handle, int x, int y)
{
    AuiPaneInfo::MaxSize(handle, x, y);
}

ALTERNET_UI_API void AuiPaneInfo_FloatingPosition_(void* handle, int x, int y)
{
    AuiPaneInfo::FloatingPosition(handle, x, y);
}

ALTERNET_UI_API void AuiPaneInfo_FloatingSize_(void* handle, int x, int y)
{
    AuiPaneInfo::FloatingSize(handle, x, y);
}

ALTERNET_UI_API void AuiPaneInfo_Fixed_(void* handle)
{
    AuiPaneInfo::Fixed(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Resizable_(void* handle, c_bool resizable)
{
    AuiPaneInfo::Resizable(handle, resizable);
}

ALTERNET_UI_API void AuiPaneInfo_Dock_(void* handle)
{
    AuiPaneInfo::Dock(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Float_(void* handle)
{
    AuiPaneInfo::Float(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Hide_(void* handle)
{
    AuiPaneInfo::Hide(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Show_(void* handle, c_bool show)
{
    AuiPaneInfo::Show(handle, show);
}

ALTERNET_UI_API void AuiPaneInfo_CaptionVisible_(void* handle, c_bool visible)
{
    AuiPaneInfo::CaptionVisible(handle, visible);
}

ALTERNET_UI_API void AuiPaneInfo_Maximize_(void* handle)
{
    AuiPaneInfo::Maximize(handle);
}

ALTERNET_UI_API void AuiPaneInfo_Restore_(void* handle)
{
    AuiPaneInfo::Restore(handle);
}

ALTERNET_UI_API void AuiPaneInfo_PaneBorder_(void* handle, c_bool visible)
{
    AuiPaneInfo::PaneBorder(handle, visible);
}

ALTERNET_UI_API void AuiPaneInfo_Gripper_(void* handle, c_bool visible)
{
    AuiPaneInfo::Gripper(handle, visible);
}

ALTERNET_UI_API void AuiPaneInfo_GripperTop_(void* handle, c_bool attop)
{
    AuiPaneInfo::GripperTop(handle, attop);
}

ALTERNET_UI_API void AuiPaneInfo_CloseButton_(void* handle, c_bool visible)
{
    AuiPaneInfo::CloseButton(handle, visible);
}

ALTERNET_UI_API void AuiPaneInfo_MaximizeButton_(void* handle, c_bool visible)
{
    AuiPaneInfo::MaximizeButton(handle, visible);
}

ALTERNET_UI_API void AuiPaneInfo_MinimizeButton_(void* handle, c_bool visible)
{
    AuiPaneInfo::MinimizeButton(handle, visible);
}

ALTERNET_UI_API void AuiPaneInfo_PinButton_(void* handle, c_bool visible)
{
    AuiPaneInfo::PinButton(handle, visible);
}

ALTERNET_UI_API void AuiPaneInfo_DestroyOnClose_(void* handle, c_bool b)
{
    AuiPaneInfo::DestroyOnClose(handle, b);
}

ALTERNET_UI_API void AuiPaneInfo_TopDockable_(void* handle, c_bool b)
{
    AuiPaneInfo::TopDockable(handle, b);
}

ALTERNET_UI_API void AuiPaneInfo_BottomDockable_(void* handle, c_bool b)
{
    AuiPaneInfo::BottomDockable(handle, b);
}

ALTERNET_UI_API void AuiPaneInfo_LeftDockable_(void* handle, c_bool b)
{
    AuiPaneInfo::LeftDockable(handle, b);
}

ALTERNET_UI_API void AuiPaneInfo_RightDockable_(void* handle, c_bool b)
{
    AuiPaneInfo::RightDockable(handle, b);
}

ALTERNET_UI_API void AuiPaneInfo_Floatable_(void* handle, c_bool b)
{
    AuiPaneInfo::Floatable(handle, b);
}

ALTERNET_UI_API void AuiPaneInfo_Movable_(void* handle, c_bool b)
{
    AuiPaneInfo::Movable(handle, b);
}

ALTERNET_UI_API void AuiPaneInfo_DockFixed_(void* handle, c_bool b)
{
    AuiPaneInfo::DockFixed(handle, b);
}

ALTERNET_UI_API void AuiPaneInfo_Dockable_(void* handle, c_bool b)
{
    AuiPaneInfo::Dockable(handle, b);
}

ALTERNET_UI_API c_bool AuiPaneInfo_IsValid_(void* handle)
{
    return AuiPaneInfo::IsValid(handle);
}

ALTERNET_UI_API void AuiPaneInfo_DefaultPane_(void* handle)
{
    AuiPaneInfo::DefaultPane(handle);
}

ALTERNET_UI_API void AuiPaneInfo_CenterPane_(void* handle)
{
    AuiPaneInfo::CenterPane(handle);
}

ALTERNET_UI_API void AuiPaneInfo_ToolbarPane_(void* handle)
{
    AuiPaneInfo::ToolbarPane(handle);
}

ALTERNET_UI_API void AuiPaneInfo_SetFlag_(void* handle, int flag, c_bool option_state)
{
    AuiPaneInfo::SetFlag(handle, flag, option_state);
}

ALTERNET_UI_API c_bool AuiPaneInfo_HasFlag_(void* handle, int flag)
{
    return AuiPaneInfo::HasFlag(handle, flag);
}

