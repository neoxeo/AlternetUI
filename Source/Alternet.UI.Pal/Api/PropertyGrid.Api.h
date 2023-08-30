// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>

#pragma once

#include "PropertyGrid.h"
#include "ImageSet.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API PropertyGrid* PropertyGrid_Create_()
{
    return MarshalExceptions<PropertyGrid*>([&](){
            return new PropertyGrid();
        });
}

ALTERNET_UI_API int PropertyGrid_GetEventValidationFailureBehavior_(PropertyGrid* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetEventValidationFailureBehavior();
        });
}

ALTERNET_UI_API void PropertyGrid_SetEventValidationFailureBehavior_(PropertyGrid* obj, int value)
{
    MarshalExceptions<void>([&](){
            obj->SetEventValidationFailureBehavior(value);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetEventPropValue_(PropertyGrid* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetEventPropValue();
        });
}

ALTERNET_UI_API int PropertyGrid_GetEventColumn_(PropertyGrid* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetEventColumn();
        });
}

ALTERNET_UI_API void* PropertyGrid_GetEventProperty_(PropertyGrid* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetEventProperty();
        });
}

ALTERNET_UI_API char16_t* PropertyGrid_GetEventPropertyName_(PropertyGrid* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetEventPropertyName());
        });
}

ALTERNET_UI_API char16_t* PropertyGrid_GetEventValidationFailureMessage_(PropertyGrid* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetEventValidationFailureMessage());
        });
}

ALTERNET_UI_API void PropertyGrid_SetEventValidationFailureMessage_(PropertyGrid* obj, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetEventValidationFailureMessage(value);
        });
}

ALTERNET_UI_API char16_t* PropertyGrid_GetNameAsLabel_()
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(PropertyGrid::GetNameAsLabel());
        });
}

ALTERNET_UI_API c_bool PropertyGrid_GetHasBorder_(PropertyGrid* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetHasBorder();
        });
}

ALTERNET_UI_API void PropertyGrid_SetHasBorder_(PropertyGrid* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetHasBorder(value);
        });
}

ALTERNET_UI_API int64_t PropertyGrid_GetCreateStyle_(PropertyGrid* obj)
{
    return MarshalExceptions<int64_t>([&](){
            return obj->GetCreateStyle();
        });
}

ALTERNET_UI_API void PropertyGrid_SetCreateStyle_(PropertyGrid* obj, int64_t value)
{
    MarshalExceptions<void>([&](){
            obj->SetCreateStyle(value);
        });
}

ALTERNET_UI_API int64_t PropertyGrid_GetCreateStyleEx_(PropertyGrid* obj)
{
    return MarshalExceptions<int64_t>([&](){
            return obj->GetCreateStyleEx();
        });
}

ALTERNET_UI_API void PropertyGrid_SetCreateStyleEx_(PropertyGrid* obj, int64_t value)
{
    MarshalExceptions<void>([&](){
            obj->SetCreateStyleEx(value);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetPropertyImage_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetPropertyImage(id);
        });
}

ALTERNET_UI_API char16_t* PropertyGrid_GetPropertyLabel_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetPropertyLabel(id));
        });
}

ALTERNET_UI_API void* PropertyGrid_GetPropertyParent_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetPropertyParent(id);
        });
}

ALTERNET_UI_API char16_t* PropertyGrid_GetPropertyValueAsString_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetPropertyValueAsString(id));
        });
}

ALTERNET_UI_API int64_t PropertyGrid_GetPropertyValueAsLong_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<int64_t>([&](){
            return obj->GetPropertyValueAsLong(id);
        });
}

ALTERNET_UI_API uint64_t PropertyGrid_GetPropertyValueAsULong_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<uint64_t>([&](){
            return obj->GetPropertyValueAsULong(id);
        });
}

ALTERNET_UI_API int PropertyGrid_GetPropertyValueAsInt_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<int>([&](){
            return obj->GetPropertyValueAsInt(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_GetPropertyValueAsBool_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetPropertyValueAsBool(id);
        });
}

ALTERNET_UI_API double PropertyGrid_GetPropertyValueAsDouble_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<double>([&](){
            return obj->GetPropertyValueAsDouble(id);
        });
}

ALTERNET_UI_API DateTime_C PropertyGrid_GetPropertyValueAsDateTime_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<DateTime_C>([&](){
            return obj->GetPropertyValueAsDateTime(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_HideProperty_(PropertyGrid* obj, void* id, c_bool hide, int flags)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->HideProperty(id, hide, flags);
        });
}

ALTERNET_UI_API void* PropertyGrid_Insert_(PropertyGrid* obj, void* priorThis, void* newproperty)
{
    return MarshalExceptions<void*>([&](){
            return obj->Insert(priorThis, newproperty);
        });
}

ALTERNET_UI_API void* PropertyGrid_InsertByIndex_(PropertyGrid* obj, void* parent, int index, void* newproperty)
{
    return MarshalExceptions<void*>([&](){
            return obj->InsertByIndex(parent, index, newproperty);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_IsPropertyCategory_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->IsPropertyCategory(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_IsPropertyEnabled_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->IsPropertyEnabled(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_IsPropertyExpanded_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->IsPropertyExpanded(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_IsPropertyModified_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->IsPropertyModified(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_IsPropertySelected_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->IsPropertySelected(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_IsPropertyShown_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->IsPropertyShown(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_IsPropertyValueUnspecified_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->IsPropertyValueUnspecified(id);
        });
}

ALTERNET_UI_API void PropertyGrid_LimitPropertyEditing_(PropertyGrid* obj, void* id, c_bool limit)
{
    MarshalExceptions<void>([&](){
            obj->LimitPropertyEditing(id, limit);
        });
}

ALTERNET_UI_API void* PropertyGrid_ReplaceProperty_(PropertyGrid* obj, void* id, void* property)
{
    return MarshalExceptions<void*>([&](){
            return obj->ReplaceProperty(id, property);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyBackgroundColor_(PropertyGrid* obj, void* id, Color color, int flags)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyBackgroundColor(id, color, flags);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyColorsToDefault_(PropertyGrid* obj, void* id, int flags)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyColorsToDefault(id, flags);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyTextColor_(PropertyGrid* obj, void* id, Color col, int flags)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyTextColor(id, col, flags);
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetPropertyBackgroundColor_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetPropertyBackgroundColor(id);
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetPropertyTextColor_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetPropertyTextColor(id);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyClientData_(PropertyGrid* obj, void* id, void* clientData)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyClientData(id, clientData);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyEditor_(PropertyGrid* obj, void* id, void* editor)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyEditor(id, editor);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyEditorByName_(PropertyGrid* obj, void* id, const char16_t* editorName)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyEditorByName(id, editorName);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyLabel_(PropertyGrid* obj, void* id, const char16_t* newproplabel)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyLabel(id, newproplabel);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyName_(PropertyGrid* obj, void* id, const char16_t* newName)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyName(id, newName);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyHelpString_(PropertyGrid* obj, void* id, const char16_t* helpString)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyHelpString(id, helpString);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_SetPropertyMaxLength_(PropertyGrid* obj, void* id, int maxLen)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->SetPropertyMaxLength(id, maxLen);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyValueAsLong_(PropertyGrid* obj, void* id, int64_t value)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyValueAsLong(id, value);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyValueAsInt_(PropertyGrid* obj, void* id, int value)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyValueAsInt(id, value);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyValueAsDouble_(PropertyGrid* obj, void* id, double value)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyValueAsDouble(id, value);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyValueAsBool_(PropertyGrid* obj, void* id, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyValueAsBool(id, value);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyValueAsStr_(PropertyGrid* obj, void* id, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyValueAsStr(id, value);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyValueAsVariant_(PropertyGrid* obj, void* id, void* variant)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyValueAsVariant(id, variant);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyValueAsDateTime_(PropertyGrid* obj, void* id, DateTime value)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyValueAsDateTime(id, value);
        });
}

ALTERNET_UI_API void PropertyGrid_SetValidationFailureBehavior_(PropertyGrid* obj, int vfbFlags)
{
    MarshalExceptions<void>([&](){
            obj->SetValidationFailureBehavior(vfbFlags);
        });
}

ALTERNET_UI_API void PropertyGrid_SortChildren_(PropertyGrid* obj, void* id, int flags)
{
    MarshalExceptions<void>([&](){
            obj->SortChildren(id, flags);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetEditorByName_(const char16_t* editorName)
{
    return MarshalExceptions<void*>([&](){
            return PropertyGrid::GetEditorByName(editorName);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_ChangePropertyValue_(PropertyGrid* obj, void* id, void* variant)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->ChangePropertyValue(id, variant);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyImage_(PropertyGrid* obj, void* id, ImageSet* bmp)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyImage(id, bmp);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyAttribute_(PropertyGrid* obj, void* id, const char16_t* attrName, void* variant, int64_t argFlags)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyAttribute(id, attrName, variant, argFlags);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyAttributeAll_(PropertyGrid* obj, const char16_t* attrName, void* variant)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyAttributeAll(attrName, variant);
        });
}

ALTERNET_UI_API void PropertyGrid_SetLineColor_(PropertyGrid* obj, Color col)
{
    MarshalExceptions<void>([&](){
            obj->SetLineColor(col);
        });
}

ALTERNET_UI_API void PropertyGrid_SetMarginColor_(PropertyGrid* obj, Color col)
{
    MarshalExceptions<void>([&](){
            obj->SetMarginColor(col);
        });
}

ALTERNET_UI_API void PropertyGrid_SetSelectionBackgroundColor_(PropertyGrid* obj, Color col)
{
    MarshalExceptions<void>([&](){
            obj->SetSelectionBackgroundColor(col);
        });
}

ALTERNET_UI_API void PropertyGrid_SetSelectionTextColor_(PropertyGrid* obj, Color col)
{
    MarshalExceptions<void>([&](){
            obj->SetSelectionTextColor(col);
        });
}

ALTERNET_UI_API void PropertyGrid_SetSplitterPosition_(PropertyGrid* obj, int newXPos, int col)
{
    MarshalExceptions<void>([&](){
            obj->SetSplitterPosition(newXPos, col);
        });
}

ALTERNET_UI_API char16_t* PropertyGrid_GetUnspecifiedValueText_(PropertyGrid* obj, int argFlags)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetUnspecifiedValueText(argFlags));
        });
}

ALTERNET_UI_API void PropertyGrid_SetVirtualWidth_(PropertyGrid* obj, int width)
{
    MarshalExceptions<void>([&](){
            obj->SetVirtualWidth(width);
        });
}

ALTERNET_UI_API void PropertyGrid_SetSplitterLeft_(PropertyGrid* obj, c_bool privateChildrenToo)
{
    MarshalExceptions<void>([&](){
            obj->SetSplitterLeft(privateChildrenToo);
        });
}

ALTERNET_UI_API void PropertyGrid_SetVerticalSpacing_(PropertyGrid* obj, int vspacing)
{
    MarshalExceptions<void>([&](){
            obj->SetVerticalSpacing(vspacing);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_HasVirtualWidth_(PropertyGrid* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->HasVirtualWidth();
        });
}

ALTERNET_UI_API uint32_t PropertyGrid_GetCommonValueCount_(PropertyGrid* obj)
{
    return MarshalExceptions<uint32_t>([&](){
            return obj->GetCommonValueCount();
        });
}

ALTERNET_UI_API char16_t* PropertyGrid_GetCommonValueLabel_(PropertyGrid* obj, uint32_t i)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetCommonValueLabel(i));
        });
}

ALTERNET_UI_API int PropertyGrid_GetUnspecifiedCommonValue_(PropertyGrid* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetUnspecifiedCommonValue();
        });
}

ALTERNET_UI_API void PropertyGrid_SetUnspecifiedCommonValue_(PropertyGrid* obj, int index)
{
    MarshalExceptions<void>([&](){
            obj->SetUnspecifiedCommonValue(index);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_IsSmallScreen_()
{
    return MarshalExceptions<c_bool>([&](){
            return PropertyGrid::IsSmallScreen();
        });
}

ALTERNET_UI_API void PropertyGrid_RefreshEditor_(PropertyGrid* obj)
{
    MarshalExceptions<void>([&](){
            obj->RefreshEditor();
        });
}

ALTERNET_UI_API c_bool PropertyGrid_WasValueChangedInEvent_(PropertyGrid* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->WasValueChangedInEvent();
        });
}

ALTERNET_UI_API int PropertyGrid_GetSpacingY_(PropertyGrid* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetSpacingY();
        });
}

ALTERNET_UI_API void PropertyGrid_SetupTextCtrlValue_(PropertyGrid* obj, const char16_t* text)
{
    MarshalExceptions<void>([&](){
            obj->SetupTextCtrlValue(text);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_UnfocusEditor_(PropertyGrid* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->UnfocusEditor();
        });
}

ALTERNET_UI_API void* PropertyGrid_GetLastItem_(PropertyGrid* obj, int flags)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetLastItem(flags);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetRoot_(PropertyGrid* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetRoot();
        });
}

ALTERNET_UI_API void* PropertyGrid_GetSelectedProperty_(PropertyGrid* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetSelectedProperty();
        });
}

ALTERNET_UI_API c_bool PropertyGrid_EnsureVisible_(PropertyGrid* obj, void* propArg)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->EnsureVisible(propArg);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_SelectProperty_(PropertyGrid* obj, void* propArg, c_bool focus)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->SelectProperty(propArg, focus);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_AddToSelection_(PropertyGrid* obj, void* propArg)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->AddToSelection(propArg);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_RemoveFromSelection_(PropertyGrid* obj, void* propArg)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->RemoveFromSelection(propArg);
        });
}

ALTERNET_UI_API void PropertyGrid_SetCurrentCategory_(PropertyGrid* obj, void* propArg)
{
    MarshalExceptions<void>([&](){
            obj->SetCurrentCategory(propArg);
        });
}

ALTERNET_UI_API Int32Rect_C PropertyGrid_GetImageRect_(PropertyGrid* obj, void* p, int item)
{
    return MarshalExceptions<Int32Rect_C>([&](){
            return obj->GetImageRect(p, item);
        });
}

ALTERNET_UI_API Int32Size_C PropertyGrid_GetImageSize_(PropertyGrid* obj, void* p, int item)
{
    return MarshalExceptions<Int32Size_C>([&](){
            return obj->GetImageSize(p, item);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateStringProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, const char16_t* value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateStringProperty(label, name, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateFilenameProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, const char16_t* value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateFilenameProperty(label, name, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateDirProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, const char16_t* value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateDirProperty(label, name, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateImageFilenameProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, const char16_t* value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateImageFilenameProperty(label, name, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateSystemColorProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, Color value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateSystemColorProperty(label, name, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateCursorProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, int value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateCursorProperty(label, name, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateBoolProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, c_bool value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateBoolProperty(label, name, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateIntProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, int64_t value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateIntProperty(label, name, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateFloatProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, double value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateFloatProperty(label, name, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateUIntProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, uint64_t value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateUIntProperty(label, name, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateLongStringProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, const char16_t* value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateLongStringProperty(label, name, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateDateProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, DateTime value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateDateProperty(label, name, value);
        });
}

ALTERNET_UI_API void PropertyGrid_Clear_(PropertyGrid* obj)
{
    MarshalExceptions<void>([&](){
            obj->Clear();
        });
}

ALTERNET_UI_API void* PropertyGrid_Append_(PropertyGrid* obj, void* property)
{
    return MarshalExceptions<void*>([&](){
            return obj->Append(property);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateEditEnumProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, void* choices, const char16_t* value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateEditEnumProperty(label, name, choices, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateEnumProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, void* choices, int value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateEnumProperty(label, name, choices, value);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateFlagsProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, void* choices, int value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateFlagsProperty(label, name, choices, value);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_ClearSelection_(PropertyGrid* obj, c_bool validation)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->ClearSelection(validation);
        });
}

ALTERNET_UI_API void PropertyGrid_ClearModifiedStatus_(PropertyGrid* obj)
{
    MarshalExceptions<void>([&](){
            obj->ClearModifiedStatus();
        });
}

ALTERNET_UI_API c_bool PropertyGrid_CollapseAll_(PropertyGrid* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->CollapseAll();
        });
}

ALTERNET_UI_API c_bool PropertyGrid_EditorValidate_(PropertyGrid* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->EditorValidate();
        });
}

ALTERNET_UI_API c_bool PropertyGrid_ExpandAll_(PropertyGrid* obj, c_bool expand)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->ExpandAll(expand);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreatePropCategory_(PropertyGrid* obj, const char16_t* label, const char16_t* name)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreatePropCategory(label, name);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetFirst_(PropertyGrid* obj, int flags)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetFirst(flags);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetProperty_(PropertyGrid* obj, const char16_t* name)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetProperty(name);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetPropertyByLabel_(PropertyGrid* obj, const char16_t* label)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetPropertyByLabel(label);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetPropertyByName_(PropertyGrid* obj, const char16_t* name)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetPropertyByName(name);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetPropertyByNameAndSubName_(PropertyGrid* obj, const char16_t* name, const char16_t* subname)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetPropertyByNameAndSubName(name, subname);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetSelection_(PropertyGrid* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetSelection();
        });
}

ALTERNET_UI_API char16_t* PropertyGrid_GetPropertyName_(PropertyGrid* obj, void* property)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetPropertyName(property));
        });
}

ALTERNET_UI_API void PropertyGrid_InitAllTypeHandlers_()
{
    MarshalExceptions<void>([&](){
            PropertyGrid::InitAllTypeHandlers();
        });
}

ALTERNET_UI_API void PropertyGrid_RegisterAdditionalEditors_()
{
    MarshalExceptions<void>([&](){
            PropertyGrid::RegisterAdditionalEditors();
        });
}

ALTERNET_UI_API c_bool PropertyGrid_RestoreEditableState_(PropertyGrid* obj, const char16_t* src, int restoreStates)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->RestoreEditableState(src, restoreStates);
        });
}

ALTERNET_UI_API char16_t* PropertyGrid_SaveEditableState_(PropertyGrid* obj, int includedStates)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->SaveEditableState(includedStates));
        });
}

ALTERNET_UI_API void PropertyGrid_SetBoolChoices_(const char16_t* trueChoice, const char16_t* falseChoice)
{
    MarshalExceptions<void>([&](){
            PropertyGrid::SetBoolChoices(trueChoice, falseChoice);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_SetColumnProportion_(PropertyGrid* obj, uint32_t column, int proportion)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->SetColumnProportion(column, proportion);
        });
}

ALTERNET_UI_API int PropertyGrid_GetColumnProportion_(PropertyGrid* obj, uint32_t column)
{
    return MarshalExceptions<int>([&](){
            return obj->GetColumnProportion(column);
        });
}

ALTERNET_UI_API void PropertyGrid_Sort_(PropertyGrid* obj, int flags)
{
    MarshalExceptions<void>([&](){
            obj->Sort(flags);
        });
}

ALTERNET_UI_API void PropertyGrid_RefreshProperty_(PropertyGrid* obj, void* p)
{
    MarshalExceptions<void>([&](){
            obj->RefreshProperty(p);
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateColorProperty_(PropertyGrid* obj, const char16_t* label, const char16_t* name, Color value)
{
    return MarshalExceptions<void*>([&](){
            return obj->CreateColorProperty(label, name, value);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyReadOnly_(PropertyGrid* obj, void* id, c_bool set, int flags)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyReadOnly(id, set, flags);
        });
}

ALTERNET_UI_API void PropertyGrid_SetPropertyValueUnspecified_(PropertyGrid* obj, void* id)
{
    MarshalExceptions<void>([&](){
            obj->SetPropertyValueUnspecified(id);
        });
}

ALTERNET_UI_API void* PropertyGrid_AppendIn_(PropertyGrid* obj, void* id, void* newproperty)
{
    return MarshalExceptions<void*>([&](){
            return obj->AppendIn(id, newproperty);
        });
}

ALTERNET_UI_API void PropertyGrid_BeginAddChildren_(PropertyGrid* obj, void* id)
{
    MarshalExceptions<void>([&](){
            obj->BeginAddChildren(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_Collapse_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->Collapse(id);
        });
}

ALTERNET_UI_API void PropertyGrid_DeleteProperty_(PropertyGrid* obj, void* id)
{
    MarshalExceptions<void>([&](){
            obj->DeleteProperty(id);
        });
}

ALTERNET_UI_API void* PropertyGrid_RemoveProperty_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<void*>([&](){
            return obj->RemoveProperty(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_DisableProperty_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->DisableProperty(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_EnableProperty_(PropertyGrid* obj, void* id, c_bool enable)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->EnableProperty(id, enable);
        });
}

ALTERNET_UI_API void PropertyGrid_EndAddChildren_(PropertyGrid* obj, void* id)
{
    MarshalExceptions<void>([&](){
            obj->EndAddChildren(id);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_Expand_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->Expand(id);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetFirstChild_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetFirstChild(id);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetPropertyCategory_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetPropertyCategory(id);
        });
}

ALTERNET_UI_API void* PropertyGrid_GetPropertyClientData_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetPropertyClientData(id);
        });
}

ALTERNET_UI_API char16_t* PropertyGrid_GetPropertyHelpString_(PropertyGrid* obj, void* id)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetPropertyHelpString(id));
        });
}

ALTERNET_UI_API void* PropertyGrid_CreateEx_(int64_t styles)
{
    return MarshalExceptions<void*>([&](){
            return PropertyGrid::CreateEx(styles);
        });
}

ALTERNET_UI_API void PropertyGrid_AddActionTrigger_(PropertyGrid* obj, int action, int keycode, int modifiers)
{
    MarshalExceptions<void>([&](){
            obj->AddActionTrigger(action, keycode, modifiers);
        });
}

ALTERNET_UI_API void PropertyGrid_DedicateKey_(PropertyGrid* obj, int keycode)
{
    MarshalExceptions<void>([&](){
            obj->DedicateKey(keycode);
        });
}

ALTERNET_UI_API void PropertyGrid_AutoGetTranslation_(c_bool enable)
{
    MarshalExceptions<void>([&](){
            PropertyGrid::AutoGetTranslation(enable);
        });
}

ALTERNET_UI_API void PropertyGrid_CenterSplitter_(PropertyGrid* obj, c_bool enableAutoResizing)
{
    MarshalExceptions<void>([&](){
            obj->CenterSplitter(enableAutoResizing);
        });
}

ALTERNET_UI_API void PropertyGrid_ClearActionTriggers_(PropertyGrid* obj, int action)
{
    MarshalExceptions<void>([&](){
            obj->ClearActionTriggers(action);
        });
}

ALTERNET_UI_API c_bool PropertyGrid_CommitChangesFromEditor_(PropertyGrid* obj, uint32_t flags)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->CommitChangesFromEditor(flags);
        });
}

ALTERNET_UI_API void PropertyGrid_EditorsValueWasModified_(PropertyGrid* obj)
{
    MarshalExceptions<void>([&](){
            obj->EditorsValueWasModified();
        });
}

ALTERNET_UI_API void PropertyGrid_EditorsValueWasNotModified_(PropertyGrid* obj)
{
    MarshalExceptions<void>([&](){
            obj->EditorsValueWasNotModified();
        });
}

ALTERNET_UI_API c_bool PropertyGrid_EnableCategories_(PropertyGrid* obj, c_bool enable)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->EnableCategories(enable);
        });
}

ALTERNET_UI_API Size_C PropertyGrid_FitColumns_(PropertyGrid* obj)
{
    return MarshalExceptions<Size_C>([&](){
            return obj->FitColumns();
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetCaptionBackgroundColor_(PropertyGrid* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetCaptionBackgroundColor();
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetCaptionForegroundColor_(PropertyGrid* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetCaptionForegroundColor();
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetCellBackgroundColor_(PropertyGrid* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetCellBackgroundColor();
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetCellDisabledTextColor_(PropertyGrid* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetCellDisabledTextColor();
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetCellTextColor_(PropertyGrid* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetCellTextColor();
        });
}

ALTERNET_UI_API uint32_t PropertyGrid_GetColumnCount_(PropertyGrid* obj)
{
    return MarshalExceptions<uint32_t>([&](){
            return obj->GetColumnCount();
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetEmptySpaceColor_(PropertyGrid* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetEmptySpaceColor();
        });
}

ALTERNET_UI_API int PropertyGrid_GetFontHeight_(PropertyGrid* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetFontHeight();
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetLineColor_(PropertyGrid* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetLineColor();
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetMarginColor_(PropertyGrid* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetMarginColor();
        });
}

ALTERNET_UI_API int PropertyGrid_GetMarginWidth_(PropertyGrid* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetMarginWidth();
        });
}

ALTERNET_UI_API int PropertyGrid_GetRowHeight_(PropertyGrid* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetRowHeight();
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetSelectionBackgroundColor_(PropertyGrid* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetSelectionBackgroundColor();
        });
}

ALTERNET_UI_API Color_C PropertyGrid_GetSelectionForegroundColor_(PropertyGrid* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetSelectionForegroundColor();
        });
}

ALTERNET_UI_API int PropertyGrid_GetSplitterPosition_(PropertyGrid* obj, uint32_t splitterIndex)
{
    return MarshalExceptions<int>([&](){
            return obj->GetSplitterPosition(splitterIndex);
        });
}

ALTERNET_UI_API int PropertyGrid_GetVerticalSpacing_(PropertyGrid* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetVerticalSpacing();
        });
}

ALTERNET_UI_API c_bool PropertyGrid_IsEditorFocused_(PropertyGrid* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->IsEditorFocused();
        });
}

ALTERNET_UI_API c_bool PropertyGrid_IsEditorsValueModified_(PropertyGrid* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->IsEditorsValueModified();
        });
}

ALTERNET_UI_API c_bool PropertyGrid_IsAnyModified_(PropertyGrid* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->IsAnyModified();
        });
}

ALTERNET_UI_API void PropertyGrid_ResetColors_(PropertyGrid* obj)
{
    MarshalExceptions<void>([&](){
            obj->ResetColors();
        });
}

ALTERNET_UI_API void PropertyGrid_ResetColumnSizes_(PropertyGrid* obj, c_bool enableAutoResizing)
{
    MarshalExceptions<void>([&](){
            obj->ResetColumnSizes(enableAutoResizing);
        });
}

ALTERNET_UI_API void PropertyGrid_MakeColumnEditable_(PropertyGrid* obj, uint32_t column, c_bool editable)
{
    MarshalExceptions<void>([&](){
            obj->MakeColumnEditable(column, editable);
        });
}

ALTERNET_UI_API void PropertyGrid_BeginLabelEdit_(PropertyGrid* obj, uint32_t column)
{
    MarshalExceptions<void>([&](){
            obj->BeginLabelEdit(column);
        });
}

ALTERNET_UI_API void PropertyGrid_EndLabelEdit_(PropertyGrid* obj, c_bool commit)
{
    MarshalExceptions<void>([&](){
            obj->EndLabelEdit(commit);
        });
}

ALTERNET_UI_API void PropertyGrid_SetCaptionBackgroundColor_(PropertyGrid* obj, Color col)
{
    MarshalExceptions<void>([&](){
            obj->SetCaptionBackgroundColor(col);
        });
}

ALTERNET_UI_API void PropertyGrid_SetCaptionTextColor_(PropertyGrid* obj, Color col)
{
    MarshalExceptions<void>([&](){
            obj->SetCaptionTextColor(col);
        });
}

ALTERNET_UI_API void PropertyGrid_SetCellBackgroundColor_(PropertyGrid* obj, Color col)
{
    MarshalExceptions<void>([&](){
            obj->SetCellBackgroundColor(col);
        });
}

ALTERNET_UI_API void PropertyGrid_SetCellDisabledTextColor_(PropertyGrid* obj, Color col)
{
    MarshalExceptions<void>([&](){
            obj->SetCellDisabledTextColor(col);
        });
}

ALTERNET_UI_API void PropertyGrid_SetCellTextColor_(PropertyGrid* obj, Color col)
{
    MarshalExceptions<void>([&](){
            obj->SetCellTextColor(col);
        });
}

ALTERNET_UI_API void PropertyGrid_SetColumnCount_(PropertyGrid* obj, int colCount)
{
    MarshalExceptions<void>([&](){
            obj->SetColumnCount(colCount);
        });
}

ALTERNET_UI_API void PropertyGrid_SetEmptySpaceColor_(PropertyGrid* obj, Color col)
{
    MarshalExceptions<void>([&](){
            obj->SetEmptySpaceColor(col);
        });
}

ALTERNET_UI_API void PropertyGrid_SetEventCallback_(PropertyGrid::PropertyGridEventCallbackType callback)
{
    PropertyGrid::SetEventCallback(callback);
}

