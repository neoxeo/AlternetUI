// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>

#pragma once

#include "AuiToolBar.h"
#include "ImageSet.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API AuiToolBar* AuiToolBar_Create_()
{
    return MarshalExceptions<AuiToolBar*>([&](){
            return new AuiToolBar();
        });
}

ALTERNET_UI_API void AuiToolBar_SetArtProvider_(AuiToolBar* obj, void* art)
{
    MarshalExceptions<void>([&](){
            obj->SetArtProvider(art);
        });
}

ALTERNET_UI_API void* AuiToolBar_GetArtProvider_(AuiToolBar* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetArtProvider();
        });
}

ALTERNET_UI_API void* AuiToolBar_AddTool_(AuiToolBar* obj, int toolId, const char16_t* label, ImageSet* bitmapBundle, const char16_t* shortHelpString, int itemKind)
{
    return MarshalExceptions<void*>([&](){
            return obj->AddTool(toolId, label, bitmapBundle, shortHelpString, itemKind);
        });
}

ALTERNET_UI_API void* AuiToolBar_AddTool2_(AuiToolBar* obj, int toolId, const char16_t* label, ImageSet* bitmapBundle, ImageSet* disabledBitmapBundle, int itemKind, const char16_t* shortHelpString, const char16_t* longHelpString, void* clientData)
{
    return MarshalExceptions<void*>([&](){
            return obj->AddTool2(toolId, label, bitmapBundle, disabledBitmapBundle, itemKind, shortHelpString, longHelpString, clientData);
        });
}

ALTERNET_UI_API void* AuiToolBar_AddTool3_(AuiToolBar* obj, int toolId, ImageSet* bitmapBundle, ImageSet* disabledBitmapBundle, c_bool toggle, void* clientData, const char16_t* shortHelpString, const char16_t* longHelpString)
{
    return MarshalExceptions<void*>([&](){
            return obj->AddTool3(toolId, bitmapBundle, disabledBitmapBundle, toggle, clientData, shortHelpString, longHelpString);
        });
}

ALTERNET_UI_API void* AuiToolBar_AddLabel_(AuiToolBar* obj, int toolId, const char16_t* label, int width)
{
    return MarshalExceptions<void*>([&](){
            return obj->AddLabel(toolId, label, width);
        });
}

ALTERNET_UI_API void* AuiToolBar_AddControl_(AuiToolBar* obj, void* control, const char16_t* label)
{
    return MarshalExceptions<void*>([&](){
            return obj->AddControl(control, label);
        });
}

ALTERNET_UI_API void* AuiToolBar_AddSeparator_(AuiToolBar* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->AddSeparator();
        });
}

ALTERNET_UI_API void* AuiToolBar_AddSpacer_(AuiToolBar* obj, int pixels)
{
    return MarshalExceptions<void*>([&](){
            return obj->AddSpacer(pixels);
        });
}

ALTERNET_UI_API void* AuiToolBar_AddStretchSpacer_(AuiToolBar* obj, int proportion)
{
    return MarshalExceptions<void*>([&](){
            return obj->AddStretchSpacer(proportion);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_Realize_(AuiToolBar* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->Realize();
        });
}

ALTERNET_UI_API void* AuiToolBar_FindControl_(AuiToolBar* obj, int windowId)
{
    return MarshalExceptions<void*>([&](){
            return obj->FindControl(windowId);
        });
}

ALTERNET_UI_API void* AuiToolBar_FindToolByPosition_(AuiToolBar* obj, int x, int y)
{
    return MarshalExceptions<void*>([&](){
            return obj->FindToolByPosition(x, y);
        });
}

ALTERNET_UI_API void* AuiToolBar_FindToolByIndex_(AuiToolBar* obj, int idx)
{
    return MarshalExceptions<void*>([&](){
            return obj->FindToolByIndex(idx);
        });
}

ALTERNET_UI_API void* AuiToolBar_FindTool_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<void*>([&](){
            return obj->FindTool(toolId);
        });
}

ALTERNET_UI_API void AuiToolBar_Clear_(AuiToolBar* obj)
{
    MarshalExceptions<void>([&](){
            obj->Clear();
        });
}

ALTERNET_UI_API c_bool AuiToolBar_DestroyTool_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->DestroyTool(toolId);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_DestroyToolByIndex_(AuiToolBar* obj, int idx)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->DestroyToolByIndex(idx);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_DeleteTool_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->DeleteTool(toolId);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_DeleteByIndex_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->DeleteByIndex(toolId);
        });
}

ALTERNET_UI_API int AuiToolBar_GetToolIndex_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<int>([&](){
            return obj->GetToolIndex(toolId);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_GetToolFits_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetToolFits(toolId);
        });
}

ALTERNET_UI_API Rect_C AuiToolBar_GetToolRect_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<Rect_C>([&](){
            return obj->GetToolRect(toolId);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_GetToolFitsByIndex_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetToolFitsByIndex(toolId);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_GetToolBarFits_(AuiToolBar* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetToolBarFits();
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolBitmapSize_(AuiToolBar* obj, Size size)
{
    MarshalExceptions<void>([&](){
            obj->SetToolBitmapSize(size);
        });
}

ALTERNET_UI_API Size_C AuiToolBar_GetToolBitmapSize_(AuiToolBar* obj)
{
    return MarshalExceptions<Size_C>([&](){
            return obj->GetToolBitmapSize();
        });
}

ALTERNET_UI_API c_bool AuiToolBar_GetOverflowVisible_(AuiToolBar* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetOverflowVisible();
        });
}

ALTERNET_UI_API void AuiToolBar_SetOverflowVisible_(AuiToolBar* obj, c_bool visible)
{
    MarshalExceptions<void>([&](){
            obj->SetOverflowVisible(visible);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_GetGripperVisible_(AuiToolBar* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetGripperVisible();
        });
}

ALTERNET_UI_API void AuiToolBar_SetGripperVisible_(AuiToolBar* obj, c_bool visible)
{
    MarshalExceptions<void>([&](){
            obj->SetGripperVisible(visible);
        });
}

ALTERNET_UI_API void AuiToolBar_ToggleTool_(AuiToolBar* obj, int toolId, c_bool state)
{
    MarshalExceptions<void>([&](){
            obj->ToggleTool(toolId, state);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_GetToolToggled_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetToolToggled(toolId);
        });
}

ALTERNET_UI_API void AuiToolBar_SetMargins_(AuiToolBar* obj, int left, int right, int top, int bottom)
{
    MarshalExceptions<void>([&](){
            obj->SetMargins(left, right, top, bottom);
        });
}

ALTERNET_UI_API void AuiToolBar_EnableTool_(AuiToolBar* obj, int toolId, c_bool state)
{
    MarshalExceptions<void>([&](){
            obj->EnableTool(toolId, state);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_GetToolEnabled_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetToolEnabled(toolId);
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolDropDown_(AuiToolBar* obj, int toolId, c_bool dropdown)
{
    MarshalExceptions<void>([&](){
            obj->SetToolDropDown(toolId, dropdown);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_GetToolDropDown_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetToolDropDown(toolId);
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolBorderPadding_(AuiToolBar* obj, int padding)
{
    MarshalExceptions<void>([&](){
            obj->SetToolBorderPadding(padding);
        });
}

ALTERNET_UI_API int AuiToolBar_GetToolBorderPadding_(AuiToolBar* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetToolBorderPadding();
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolTextOrientation_(AuiToolBar* obj, int orientation)
{
    MarshalExceptions<void>([&](){
            obj->SetToolTextOrientation(orientation);
        });
}

ALTERNET_UI_API int AuiToolBar_GetToolTextOrientation_(AuiToolBar* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetToolTextOrientation();
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolPacking_(AuiToolBar* obj, int packing)
{
    MarshalExceptions<void>([&](){
            obj->SetToolPacking(packing);
        });
}

ALTERNET_UI_API int AuiToolBar_GetToolPacking_(AuiToolBar* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetToolPacking();
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolProportion_(AuiToolBar* obj, int toolId, int proportion)
{
    MarshalExceptions<void>([&](){
            obj->SetToolProportion(toolId, proportion);
        });
}

ALTERNET_UI_API int AuiToolBar_GetToolProportion_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<int>([&](){
            return obj->GetToolProportion(toolId);
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolSeparation_(AuiToolBar* obj, int separation)
{
    MarshalExceptions<void>([&](){
            obj->SetToolSeparation(separation);
        });
}

ALTERNET_UI_API int AuiToolBar_GetToolSeparation_(AuiToolBar* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetToolSeparation();
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolSticky_(AuiToolBar* obj, int toolId, c_bool sticky)
{
    MarshalExceptions<void>([&](){
            obj->SetToolSticky(toolId, sticky);
        });
}

ALTERNET_UI_API c_bool AuiToolBar_GetToolSticky_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetToolSticky(toolId);
        });
}

ALTERNET_UI_API char16_t* AuiToolBar_GetToolLabel_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetToolLabel(toolId));
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolLabel_(AuiToolBar* obj, int toolId, const char16_t* label)
{
    MarshalExceptions<void>([&](){
            obj->SetToolLabel(toolId, label);
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolBitmap_(AuiToolBar* obj, int toolId, ImageSet* bitmapBundle)
{
    MarshalExceptions<void>([&](){
            obj->SetToolBitmap(toolId, bitmapBundle);
        });
}

ALTERNET_UI_API char16_t* AuiToolBar_GetToolShortHelp_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetToolShortHelp(toolId));
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolShortHelp_(AuiToolBar* obj, int toolId, const char16_t* helpString)
{
    MarshalExceptions<void>([&](){
            obj->SetToolShortHelp(toolId, helpString);
        });
}

ALTERNET_UI_API char16_t* AuiToolBar_GetToolLongHelp_(AuiToolBar* obj, int toolId)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetToolLongHelp(toolId));
        });
}

ALTERNET_UI_API void AuiToolBar_SetToolLongHelp_(AuiToolBar* obj, int toolId, const char16_t* helpString)
{
    MarshalExceptions<void>([&](){
            obj->SetToolLongHelp(toolId, helpString);
        });
}

ALTERNET_UI_API uint64_t AuiToolBar_GetToolCount_(AuiToolBar* obj)
{
    return MarshalExceptions<uint64_t>([&](){
            return obj->GetToolCount();
        });
}

