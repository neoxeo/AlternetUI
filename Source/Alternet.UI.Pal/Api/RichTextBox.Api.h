// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2023 AlterNET Software.</auto-generated>

#pragma once

#include "RichTextBox.h"
#include "Image.h"
#include "Font.h"
#include "InputStream.h"
#include "OutputStream.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API RichTextBox* RichTextBox_Create_()
{
    return new RichTextBox();
}

ALTERNET_UI_API c_bool RichTextBox_GetHasBorder_(RichTextBox* obj)
{
    return obj->GetHasBorder();
}

ALTERNET_UI_API void RichTextBox_SetHasBorder_(RichTextBox* obj, c_bool value)
{
    obj->SetHasBorder(value);
}

ALTERNET_UI_API char16_t* RichTextBox_GetReportedUrl_(RichTextBox* obj)
{
    return AllocPInvokeReturnString(obj->GetReportedUrl());
}

ALTERNET_UI_API void* RichTextBox_WriteField_(RichTextBox* obj, const char16_t* fieldType, void* properties, void* textAttr)
{
    return obj->WriteField(fieldType, properties, textAttr);
}

ALTERNET_UI_API c_bool RichTextBox_CanDeleteRange_(RichTextBox* obj, void* container, int64_t startRange, int64_t endRange)
{
    return obj->CanDeleteRange(container, startRange, endRange);
}

ALTERNET_UI_API c_bool RichTextBox_CanInsertContent_(RichTextBox* obj, void* container, int64_t pos)
{
    return obj->CanInsertContent(container, pos);
}

ALTERNET_UI_API void* RichTextBox_GetBuffer_(RichTextBox* obj)
{
    return obj->GetBuffer();
}

ALTERNET_UI_API int64_t RichTextBox_DeleteSelectedContent_(RichTextBox* obj)
{
    return obj->DeleteSelectedContent();
}

ALTERNET_UI_API void RichTextBox_EnableVirtualAttributes_(RichTextBox* obj, c_bool b)
{
    obj->EnableVirtualAttributes(b);
}

ALTERNET_UI_API void RichTextBox_DoWriteText_(RichTextBox* obj, const char16_t* value, int flags)
{
    obj->DoWriteText(value, flags);
}

ALTERNET_UI_API c_bool RichTextBox_ExtendSelection_(RichTextBox* obj, int64_t oldPosition, int64_t newPosition, int flags)
{
    return obj->ExtendSelection(oldPosition, newPosition, flags);
}

ALTERNET_UI_API c_bool RichTextBox_ExtendCellSelection_(RichTextBox* obj, void* table, int noRowSteps, int noColSteps)
{
    return obj->ExtendCellSelection(table, noRowSteps, noColSteps);
}

ALTERNET_UI_API c_bool RichTextBox_StartCellSelection_(RichTextBox* obj, void* table, void* newCell)
{
    return obj->StartCellSelection(table, newCell);
}

ALTERNET_UI_API c_bool RichTextBox_ScrollIntoView_(RichTextBox* obj, int64_t position, int keyCode)
{
    return obj->ScrollIntoView(position, keyCode);
}

ALTERNET_UI_API void RichTextBox_SetCaretPosition_(RichTextBox* obj, int64_t position, c_bool showAtLineStart)
{
    obj->SetCaretPosition(position, showAtLineStart);
}

ALTERNET_UI_API int64_t RichTextBox_GetCaretPosition_(RichTextBox* obj)
{
    return obj->GetCaretPosition();
}

ALTERNET_UI_API int64_t RichTextBox_GetAdjustedCaretPosition_(RichTextBox* obj, int64_t caretPos)
{
    return obj->GetAdjustedCaretPosition(caretPos);
}

ALTERNET_UI_API void RichTextBox_MoveCaretForward_(RichTextBox* obj, int64_t oldPosition)
{
    obj->MoveCaretForward(oldPosition);
}

ALTERNET_UI_API Int32Point_C RichTextBox_GetPhysicalPoint_(RichTextBox* obj, Int32Point ptLogical)
{
    return obj->GetPhysicalPoint(ptLogical);
}

ALTERNET_UI_API Int32Point_C RichTextBox_GetLogicalPoint_(RichTextBox* obj, Int32Point ptPhysical)
{
    return obj->GetLogicalPoint(ptPhysical);
}

ALTERNET_UI_API int64_t RichTextBox_FindNextWordPosition_(RichTextBox* obj, int direction)
{
    return obj->FindNextWordPosition(direction);
}

ALTERNET_UI_API c_bool RichTextBox_IsPositionVisible_(RichTextBox* obj, int64_t pos)
{
    return obj->IsPositionVisible(pos);
}

ALTERNET_UI_API int64_t RichTextBox_GetFirstVisiblePosition_(RichTextBox* obj)
{
    return obj->GetFirstVisiblePosition();
}

ALTERNET_UI_API int64_t RichTextBox_GetCaretPositionForDefaultStyle_(RichTextBox* obj)
{
    return obj->GetCaretPositionForDefaultStyle();
}

ALTERNET_UI_API void RichTextBox_SetCaretPositionForDefaultStyle_(RichTextBox* obj, int64_t pos)
{
    obj->SetCaretPositionForDefaultStyle(pos);
}

ALTERNET_UI_API void RichTextBox_MoveCaretBack_(RichTextBox* obj, int64_t oldPosition)
{
    obj->MoveCaretBack(oldPosition);
}

ALTERNET_UI_API c_bool RichTextBox_GetCaretPositionForIndex_(RichTextBox* obj, int64_t position, Int32Rect rect, void* container)
{
    return obj->GetCaretPositionForIndex(position, rect, container);
}

ALTERNET_UI_API void* RichTextBox_GetVisibleLineForCaretPosition_(RichTextBox* obj, int64_t caretPosition)
{
    return obj->GetVisibleLineForCaretPosition(caretPosition);
}

ALTERNET_UI_API void* RichTextBox_GetCommandProcessor_(RichTextBox* obj)
{
    return obj->GetCommandProcessor();
}

ALTERNET_UI_API c_bool RichTextBox_IsDefaultStyleShowing_(RichTextBox* obj)
{
    return obj->IsDefaultStyleShowing();
}

ALTERNET_UI_API Int32Point_C RichTextBox_GetFirstVisiblePoint_(RichTextBox* obj)
{
    return obj->GetFirstVisiblePoint();
}

ALTERNET_UI_API void RichTextBox_EnableImages_(RichTextBox* obj, c_bool b)
{
    obj->EnableImages(b);
}

ALTERNET_UI_API c_bool RichTextBox_GetImagesEnabled_(RichTextBox* obj)
{
    return obj->GetImagesEnabled();
}

ALTERNET_UI_API void RichTextBox_EnableDelayedImageLoading_(RichTextBox* obj, c_bool b)
{
    obj->EnableDelayedImageLoading(b);
}

ALTERNET_UI_API c_bool RichTextBox_GetDelayedImageLoading_(RichTextBox* obj)
{
    return obj->GetDelayedImageLoading();
}

ALTERNET_UI_API c_bool RichTextBox_GetDelayedImageProcessingRequired_(RichTextBox* obj)
{
    return obj->GetDelayedImageProcessingRequired();
}

ALTERNET_UI_API void RichTextBox_SetDelayedImageProcessingRequired_(RichTextBox* obj, c_bool b)
{
    obj->SetDelayedImageProcessingRequired(b);
}

ALTERNET_UI_API int64_t RichTextBox_GetDelayedImageProcessingTime_(RichTextBox* obj)
{
    return obj->GetDelayedImageProcessingTime();
}

ALTERNET_UI_API void RichTextBox_SetDelayedImageProcessingTime_(RichTextBox* obj, int64_t t)
{
    obj->SetDelayedImageProcessingTime(t);
}

ALTERNET_UI_API char16_t* RichTextBox_GetValue_(RichTextBox* obj)
{
    return AllocPInvokeReturnString(obj->GetValue());
}

ALTERNET_UI_API void RichTextBox_SetValue_(RichTextBox* obj, const char16_t* value)
{
    obj->SetValue(value);
}

ALTERNET_UI_API void RichTextBox_SetLineHeight_(RichTextBox* obj, int height)
{
    obj->SetLineHeight(height);
}

ALTERNET_UI_API int RichTextBox_GetLineHeight_(RichTextBox* obj)
{
    return obj->GetLineHeight();
}

ALTERNET_UI_API c_bool RichTextBox_SetCaretPositionAfterClick_(RichTextBox* obj, void* container, int64_t position, int hitTestFlags, c_bool extendSelection)
{
    return obj->SetCaretPositionAfterClick(container, position, hitTestFlags, extendSelection);
}

ALTERNET_UI_API void RichTextBox_ClearAvailableFontNames_()
{
    RichTextBox::ClearAvailableFontNames();
}

ALTERNET_UI_API c_bool RichTextBox_ProcessDelayedImageLoading_(RichTextBox* obj, c_bool refresh)
{
    return obj->ProcessDelayedImageLoading(refresh);
}

ALTERNET_UI_API void RichTextBox_RequestDelayedImageProcessing_(RichTextBox* obj)
{
    obj->RequestDelayedImageProcessing();
}

ALTERNET_UI_API c_bool RichTextBox_GetUncombinedStyle_(RichTextBox* obj, int64_t position, void* style)
{
    return obj->GetUncombinedStyle(position, style);
}

ALTERNET_UI_API c_bool RichTextBox_GetUncombinedStyle2_(RichTextBox* obj, int64_t position, void* style, void* container)
{
    return obj->GetUncombinedStyle2(position, style, container);
}

ALTERNET_UI_API c_bool RichTextBox_SetDefaultStyle_(RichTextBox* obj, void* style)
{
    return obj->SetDefaultStyle(style);
}

ALTERNET_UI_API c_bool RichTextBox_SetDefaultRichStyle_(RichTextBox* obj, void* style)
{
    return obj->SetDefaultRichStyle(style);
}

ALTERNET_UI_API void* RichTextBox_GetDefaultStyleEx_(RichTextBox* obj)
{
    return obj->GetDefaultStyleEx();
}

ALTERNET_UI_API int64_t RichTextBox_GetLastPosition_(RichTextBox* obj)
{
    return obj->GetLastPosition();
}

ALTERNET_UI_API void* RichTextBox_GetStyle_(RichTextBox* obj, int64_t position)
{
    return obj->GetStyle(position);
}

ALTERNET_UI_API void* RichTextBox_GetRichStyle_(RichTextBox* obj, int64_t position)
{
    return obj->GetRichStyle(position);
}

ALTERNET_UI_API void* RichTextBox_GetStyleInContainer_(RichTextBox* obj, int64_t position, void* container)
{
    return obj->GetStyleInContainer(position, container);
}

ALTERNET_UI_API c_bool RichTextBox_SetStyle_(RichTextBox* obj, int64_t start, int64_t end, void* style)
{
    return obj->SetStyle(start, end, style);
}

ALTERNET_UI_API c_bool RichTextBox_SetRichStyle_(RichTextBox* obj, int64_t start, int64_t end, void* style)
{
    return obj->SetRichStyle(start, end, style);
}

ALTERNET_UI_API void RichTextBox_SetStyle2_(RichTextBox* obj, void* richObj, void* textAttr, int flags)
{
    obj->SetStyle2(richObj, textAttr, flags);
}

ALTERNET_UI_API void* RichTextBox_GetStyleForRange_(RichTextBox* obj, int64_t startRange, int64_t endRange)
{
    return obj->GetStyleForRange(startRange, endRange);
}

ALTERNET_UI_API void* RichTextBox_GetStyleForRange2_(RichTextBox* obj, int64_t startRange, int64_t endRange)
{
    return obj->GetStyleForRange2(startRange, endRange);
}

ALTERNET_UI_API void* RichTextBox_GetStyleForRange3_(RichTextBox* obj, int64_t startRange, int64_t endRange, void* container)
{
    return obj->GetStyleForRange3(startRange, endRange, container);
}

ALTERNET_UI_API c_bool RichTextBox_SetStyleEx_(RichTextBox* obj, int64_t startRange, int64_t endRange, void* style, int flags)
{
    return obj->SetStyleEx(startRange, endRange, style, flags);
}

ALTERNET_UI_API c_bool RichTextBox_SetListStyle_(RichTextBox* obj, int64_t startRange, int64_t endRange, void* def, int flags, int startFrom, int specifiedLevel)
{
    return obj->SetListStyle(startRange, endRange, def, flags, startFrom, specifiedLevel);
}

ALTERNET_UI_API c_bool RichTextBox_SetListStyle2_(RichTextBox* obj, int64_t startRange, int64_t endRange, const char16_t* defName, int flags, int startFrom, int specifiedLevel)
{
    return obj->SetListStyle2(startRange, endRange, defName, flags, startFrom, specifiedLevel);
}

ALTERNET_UI_API c_bool RichTextBox_ClearListStyle_(RichTextBox* obj, int64_t startRange, int64_t endRange, int flags)
{
    return obj->ClearListStyle(startRange, endRange, flags);
}

ALTERNET_UI_API c_bool RichTextBox_NumberList_(RichTextBox* obj, int64_t startRange, int64_t endRange, void* def, int flags, int startFrom, int specifiedLevel)
{
    return obj->NumberList(startRange, endRange, def, flags, startFrom, specifiedLevel);
}

ALTERNET_UI_API c_bool RichTextBox_NumberList2_(RichTextBox* obj, int64_t startRange, int64_t endRange, const char16_t* defName, int flags, int startFrom, int specifiedLevel)
{
    return obj->NumberList2(startRange, endRange, defName, flags, startFrom, specifiedLevel);
}

ALTERNET_UI_API c_bool RichTextBox_PromoteList_(RichTextBox* obj, int promoteBy, int64_t startRange, int64_t endRange, void* def, int flags, int specifiedLevel)
{
    return obj->PromoteList(promoteBy, startRange, endRange, def, flags, specifiedLevel);
}

ALTERNET_UI_API c_bool RichTextBox_PromoteList2_(RichTextBox* obj, int promoteBy, int64_t startRange, int64_t endRange, const char16_t* defName, int flags, int specifiedLevel)
{
    return obj->PromoteList2(promoteBy, startRange, endRange, defName, flags, specifiedLevel);
}

ALTERNET_UI_API c_bool RichTextBox_Delete_(RichTextBox* obj, int64_t startRange, int64_t endRange)
{
    return obj->Delete(startRange, endRange);
}

ALTERNET_UI_API void* RichTextBox_WriteTable_(RichTextBox* obj, int rows, int cols, void* tableAttr, void* cellAttr)
{
    return obj->WriteTable(rows, cols, tableAttr, cellAttr);
}

ALTERNET_UI_API void RichTextBox_SetBasicStyle_(RichTextBox* obj, void* style)
{
    obj->SetBasicStyle(style);
}

ALTERNET_UI_API void* RichTextBox_GetBasicStyle_(RichTextBox* obj)
{
    return obj->GetBasicStyle();
}

ALTERNET_UI_API c_bool RichTextBox_BeginStyle_(RichTextBox* obj, void* style)
{
    return obj->BeginStyle(style);
}

ALTERNET_UI_API c_bool RichTextBox_HasCharacterAttributes_(RichTextBox* obj, int64_t startRange, int64_t endRange, void* style)
{
    return obj->HasCharacterAttributes(startRange, endRange, style);
}

ALTERNET_UI_API void* RichTextBox_GetStyleSheet_(RichTextBox* obj)
{
    return obj->GetStyleSheet();
}

ALTERNET_UI_API void RichTextBox_SetAndShowDefaultStyle_(RichTextBox* obj, void* attr)
{
    obj->SetAndShowDefaultStyle(attr);
}

ALTERNET_UI_API void RichTextBox_SetSelectionRange_(RichTextBox* obj, int64_t startRange, int64_t endRange)
{
    obj->SetSelectionRange(startRange, endRange);
}

ALTERNET_UI_API Int32Point_C RichTextBox_PositionToXY_(RichTextBox* obj, int64_t pos)
{
    return obj->PositionToXY(pos);
}

ALTERNET_UI_API void* RichTextBox_WriteTextBox_(RichTextBox* obj, void* textAttr)
{
    return obj->WriteTextBox(textAttr);
}

ALTERNET_UI_API c_bool RichTextBox_HasParagraphAttributes_(RichTextBox* obj, int64_t startRange, int64_t endRange, void* style)
{
    return obj->HasParagraphAttributes(startRange, endRange, style);
}

ALTERNET_UI_API c_bool RichTextBox_SetProperties_(RichTextBox* obj, int64_t startRange, int64_t endRange, void* properties, int flags)
{
    return obj->SetProperties(startRange, endRange, properties, flags);
}

ALTERNET_UI_API void RichTextBox_SetTextCursor_(RichTextBox* obj, void* cursor)
{
    obj->SetTextCursor(cursor);
}

ALTERNET_UI_API void* RichTextBox_GetTextCursor_(RichTextBox* obj)
{
    return obj->GetTextCursor();
}

ALTERNET_UI_API void RichTextBox_SetURLCursor_(RichTextBox* obj, void* cursor)
{
    obj->SetURLCursor(cursor);
}

ALTERNET_UI_API void* RichTextBox_GetURLCursor_(RichTextBox* obj)
{
    return obj->GetURLCursor();
}

ALTERNET_UI_API void* RichTextBox_GetSelection_(RichTextBox* obj)
{
    return obj->GetSelection();
}

ALTERNET_UI_API void* RichTextBox_GetContextMenuPropertiesInfo_(RichTextBox* obj)
{
    return obj->GetContextMenuPropertiesInfo();
}

ALTERNET_UI_API void RichTextBox_SetSelection2_(RichTextBox* obj, void* sel)
{
    obj->SetSelection2(sel);
}

ALTERNET_UI_API c_bool RichTextBox_WriteImage_(RichTextBox* obj, Image* bitmap, int bitmapType, void* textAttr)
{
    return obj->WriteImage(bitmap, bitmapType, textAttr);
}

ALTERNET_UI_API c_bool RichTextBox_WriteImage2_(RichTextBox* obj, const char16_t* filename, int bitmapType, void* textAttr)
{
    return obj->WriteImage2(filename, bitmapType, textAttr);
}

ALTERNET_UI_API c_bool RichTextBox_WriteImage3_(RichTextBox* obj, void* imageBlock, void* textAttr)
{
    return obj->WriteImage3(imageBlock, textAttr);
}

ALTERNET_UI_API c_bool RichTextBox_EndBold_(RichTextBox* obj)
{
    return obj->EndBold();
}

ALTERNET_UI_API c_bool RichTextBox_BeginItalic_(RichTextBox* obj)
{
    return obj->BeginItalic();
}

ALTERNET_UI_API c_bool RichTextBox_EndItalic_(RichTextBox* obj)
{
    return obj->EndItalic();
}

ALTERNET_UI_API c_bool RichTextBox_BeginUnderline_(RichTextBox* obj)
{
    return obj->BeginUnderline();
}

ALTERNET_UI_API c_bool RichTextBox_EndUnderline_(RichTextBox* obj)
{
    return obj->EndUnderline();
}

ALTERNET_UI_API c_bool RichTextBox_BeginFontSize_(RichTextBox* obj, int pointSize)
{
    return obj->BeginFontSize(pointSize);
}

ALTERNET_UI_API c_bool RichTextBox_EndFontSize_(RichTextBox* obj)
{
    return obj->EndFontSize();
}

ALTERNET_UI_API c_bool RichTextBox_BeginFont_(RichTextBox* obj, Font* font)
{
    return obj->BeginFont(font);
}

ALTERNET_UI_API c_bool RichTextBox_EndFont_(RichTextBox* obj)
{
    return obj->EndFont();
}

ALTERNET_UI_API c_bool RichTextBox_BeginTextColour_(RichTextBox* obj, Color colour)
{
    return obj->BeginTextColour(colour);
}

ALTERNET_UI_API c_bool RichTextBox_EndTextColour_(RichTextBox* obj)
{
    return obj->EndTextColour();
}

ALTERNET_UI_API c_bool RichTextBox_BeginAlignment_(RichTextBox* obj, int alignment)
{
    return obj->BeginAlignment(alignment);
}

ALTERNET_UI_API c_bool RichTextBox_EndAlignment_(RichTextBox* obj)
{
    return obj->EndAlignment();
}

ALTERNET_UI_API c_bool RichTextBox_BeginLeftIndent_(RichTextBox* obj, int leftIndent, int leftSubIndent)
{
    return obj->BeginLeftIndent(leftIndent, leftSubIndent);
}

ALTERNET_UI_API c_bool RichTextBox_EndLeftIndent_(RichTextBox* obj)
{
    return obj->EndLeftIndent();
}

ALTERNET_UI_API c_bool RichTextBox_BeginRightIndent_(RichTextBox* obj, int rightIndent)
{
    return obj->BeginRightIndent(rightIndent);
}

ALTERNET_UI_API c_bool RichTextBox_EndRightIndent_(RichTextBox* obj)
{
    return obj->EndRightIndent();
}

ALTERNET_UI_API c_bool RichTextBox_BeginParagraphSpacing_(RichTextBox* obj, int before, int after)
{
    return obj->BeginParagraphSpacing(before, after);
}

ALTERNET_UI_API c_bool RichTextBox_EndParagraphSpacing_(RichTextBox* obj)
{
    return obj->EndParagraphSpacing();
}

ALTERNET_UI_API c_bool RichTextBox_BeginLineSpacing_(RichTextBox* obj, int lineSpacing)
{
    return obj->BeginLineSpacing(lineSpacing);
}

ALTERNET_UI_API c_bool RichTextBox_EndLineSpacing_(RichTextBox* obj)
{
    return obj->EndLineSpacing();
}

ALTERNET_UI_API c_bool RichTextBox_BeginNumberedBullet_(RichTextBox* obj, int bulletNumber, int leftIndent, int leftSubIndent, int bulletStyle)
{
    return obj->BeginNumberedBullet(bulletNumber, leftIndent, leftSubIndent, bulletStyle);
}

ALTERNET_UI_API c_bool RichTextBox_EndNumberedBullet_(RichTextBox* obj)
{
    return obj->EndNumberedBullet();
}

ALTERNET_UI_API c_bool RichTextBox_BeginSymbolBullet_(RichTextBox* obj, const char16_t* symbol, int leftIndent, int leftSubIndent, int bulletStyle)
{
    return obj->BeginSymbolBullet(symbol, leftIndent, leftSubIndent, bulletStyle);
}

ALTERNET_UI_API c_bool RichTextBox_EndSymbolBullet_(RichTextBox* obj)
{
    return obj->EndSymbolBullet();
}

ALTERNET_UI_API c_bool RichTextBox_BeginStandardBullet_(RichTextBox* obj, const char16_t* bulletName, int leftIndent, int leftSubIndent, int bulletStyle)
{
    return obj->BeginStandardBullet(bulletName, leftIndent, leftSubIndent, bulletStyle);
}

ALTERNET_UI_API c_bool RichTextBox_EndStandardBullet_(RichTextBox* obj)
{
    return obj->EndStandardBullet();
}

ALTERNET_UI_API c_bool RichTextBox_BeginCharacterStyle_(RichTextBox* obj, const char16_t* characterStyle)
{
    return obj->BeginCharacterStyle(characterStyle);
}

ALTERNET_UI_API c_bool RichTextBox_EndCharacterStyle_(RichTextBox* obj)
{
    return obj->EndCharacterStyle();
}

ALTERNET_UI_API c_bool RichTextBox_BeginParagraphStyle_(RichTextBox* obj, const char16_t* paragraphStyle)
{
    return obj->BeginParagraphStyle(paragraphStyle);
}

ALTERNET_UI_API c_bool RichTextBox_EndParagraphStyle_(RichTextBox* obj)
{
    return obj->EndParagraphStyle();
}

ALTERNET_UI_API c_bool RichTextBox_BeginListStyle_(RichTextBox* obj, const char16_t* listStyle, int level, int number)
{
    return obj->BeginListStyle(listStyle, level, number);
}

ALTERNET_UI_API c_bool RichTextBox_EndListStyle_(RichTextBox* obj)
{
    return obj->EndListStyle();
}

ALTERNET_UI_API c_bool RichTextBox_BeginURL_(RichTextBox* obj, const char16_t* url, const char16_t* characterStyle)
{
    return obj->BeginURL(url, characterStyle);
}

ALTERNET_UI_API c_bool RichTextBox_EndURL_(RichTextBox* obj)
{
    return obj->EndURL();
}

ALTERNET_UI_API c_bool RichTextBox_IsSelectionBold_(RichTextBox* obj)
{
    return obj->IsSelectionBold();
}

ALTERNET_UI_API c_bool RichTextBox_IsSelectionItalics_(RichTextBox* obj)
{
    return obj->IsSelectionItalics();
}

ALTERNET_UI_API c_bool RichTextBox_IsSelectionUnderlined_(RichTextBox* obj)
{
    return obj->IsSelectionUnderlined();
}

ALTERNET_UI_API c_bool RichTextBox_DoesSelectionHaveTextEffectFlag_(RichTextBox* obj, int flag)
{
    return obj->DoesSelectionHaveTextEffectFlag(flag);
}

ALTERNET_UI_API c_bool RichTextBox_IsSelectionAligned_(RichTextBox* obj, int alignment)
{
    return obj->IsSelectionAligned(alignment);
}

ALTERNET_UI_API c_bool RichTextBox_ApplyBoldToSelection_(RichTextBox* obj)
{
    return obj->ApplyBoldToSelection();
}

ALTERNET_UI_API c_bool RichTextBox_ApplyItalicToSelection_(RichTextBox* obj)
{
    return obj->ApplyItalicToSelection();
}

ALTERNET_UI_API c_bool RichTextBox_ApplyUnderlineToSelection_(RichTextBox* obj)
{
    return obj->ApplyUnderlineToSelection();
}

ALTERNET_UI_API c_bool RichTextBox_ApplyTextEffectToSelection_(RichTextBox* obj, int flags)
{
    return obj->ApplyTextEffectToSelection(flags);
}

ALTERNET_UI_API c_bool RichTextBox_ApplyAlignmentToSelection_(RichTextBox* obj, int alignment)
{
    return obj->ApplyAlignmentToSelection(alignment);
}

ALTERNET_UI_API c_bool RichTextBox_ApplyStyle_(RichTextBox* obj, void* def)
{
    return obj->ApplyStyle(def);
}

ALTERNET_UI_API void RichTextBox_SetStyleSheet_(RichTextBox* obj, void* styleSheet)
{
    obj->SetStyleSheet(styleSheet);
}

ALTERNET_UI_API c_bool RichTextBox_SetDefaultStyleToCursorStyle_(RichTextBox* obj)
{
    return obj->SetDefaultStyleToCursorStyle();
}

ALTERNET_UI_API void RichTextBox_SelectNone_(RichTextBox* obj)
{
    obj->SelectNone();
}

ALTERNET_UI_API c_bool RichTextBox_SelectWord_(RichTextBox* obj, int64_t position)
{
    return obj->SelectWord(position);
}

ALTERNET_UI_API c_bool RichTextBox_LayoutContent_(RichTextBox* obj, c_bool onlyVisibleRect)
{
    return obj->LayoutContent(onlyVisibleRect);
}

ALTERNET_UI_API c_bool RichTextBox_MoveCaret_(RichTextBox* obj, int64_t pos, c_bool showAtLineStart, void* container)
{
    return obj->MoveCaret(pos, showAtLineStart, container);
}

ALTERNET_UI_API c_bool RichTextBox_MoveRight_(RichTextBox* obj, int noPositions, int flags)
{
    return obj->MoveRight(noPositions, flags);
}

ALTERNET_UI_API c_bool RichTextBox_MoveLeft_(RichTextBox* obj, int noPositions, int flags)
{
    return obj->MoveLeft(noPositions, flags);
}

ALTERNET_UI_API c_bool RichTextBox_MoveUp_(RichTextBox* obj, int noLines, int flags)
{
    return obj->MoveUp(noLines, flags);
}

ALTERNET_UI_API c_bool RichTextBox_MoveDown_(RichTextBox* obj, int noLines, int flags)
{
    return obj->MoveDown(noLines, flags);
}

ALTERNET_UI_API c_bool RichTextBox_MoveToLineEnd_(RichTextBox* obj, int flags)
{
    return obj->MoveToLineEnd(flags);
}

ALTERNET_UI_API c_bool RichTextBox_MoveToLineStart_(RichTextBox* obj, int flags)
{
    return obj->MoveToLineStart(flags);
}

ALTERNET_UI_API c_bool RichTextBox_MoveToParagraphEnd_(RichTextBox* obj, int flags)
{
    return obj->MoveToParagraphEnd(flags);
}

ALTERNET_UI_API c_bool RichTextBox_MoveToParagraphStart_(RichTextBox* obj, int flags)
{
    return obj->MoveToParagraphStart(flags);
}

ALTERNET_UI_API c_bool RichTextBox_MoveHome_(RichTextBox* obj, int flags)
{
    return obj->MoveHome(flags);
}

ALTERNET_UI_API c_bool RichTextBox_MoveEnd_(RichTextBox* obj, int flags)
{
    return obj->MoveEnd(flags);
}

ALTERNET_UI_API c_bool RichTextBox_PageUp_(RichTextBox* obj, int noPages, int flags)
{
    return obj->PageUp(noPages, flags);
}

ALTERNET_UI_API c_bool RichTextBox_PageDown_(RichTextBox* obj, int noPages, int flags)
{
    return obj->PageDown(noPages, flags);
}

ALTERNET_UI_API c_bool RichTextBox_WordLeft_(RichTextBox* obj, int noPages, int flags)
{
    return obj->WordLeft(noPages, flags);
}

ALTERNET_UI_API c_bool RichTextBox_WordRight_(RichTextBox* obj, int noPages, int flags)
{
    return obj->WordRight(noPages, flags);
}

ALTERNET_UI_API c_bool RichTextBox_PushStyleSheet_(RichTextBox* obj, void* styleSheet)
{
    return obj->PushStyleSheet(styleSheet);
}

ALTERNET_UI_API void* RichTextBox_PopStyleSheet_(RichTextBox* obj)
{
    return obj->PopStyleSheet();
}

ALTERNET_UI_API c_bool RichTextBox_ApplyStyleSheet_(RichTextBox* obj, void* styleSheet)
{
    return obj->ApplyStyleSheet(styleSheet);
}

ALTERNET_UI_API c_bool RichTextBox_ShowContextMenu_(RichTextBox* obj, void* menu, Int32Point pt, c_bool addPropertyCommands)
{
    return obj->ShowContextMenu(menu, pt, addPropertyCommands);
}

ALTERNET_UI_API int RichTextBox_PrepareContextMenu_(RichTextBox* obj, void* menu, Int32Point pt, c_bool addPropertyCommands)
{
    return obj->PrepareContextMenu(menu, pt, addPropertyCommands);
}

ALTERNET_UI_API c_bool RichTextBox_CanEditProperties_(RichTextBox* obj, void* richObj)
{
    return obj->CanEditProperties(richObj);
}

ALTERNET_UI_API c_bool RichTextBox_EditProperties_(RichTextBox* obj, void* richObj, void* parentWindow)
{
    return obj->EditProperties(richObj, parentWindow);
}

ALTERNET_UI_API char16_t* RichTextBox_GetPropertiesMenuLabel_(RichTextBox* obj, void* richObj)
{
    return AllocPInvokeReturnString(obj->GetPropertiesMenuLabel(richObj));
}

ALTERNET_UI_API c_bool RichTextBox_BeginBatchUndo_(RichTextBox* obj, const char16_t* cmdName)
{
    return obj->BeginBatchUndo(cmdName);
}

ALTERNET_UI_API c_bool RichTextBox_EndBatchUndo_(RichTextBox* obj)
{
    return obj->EndBatchUndo();
}

ALTERNET_UI_API c_bool RichTextBox_BatchingUndo_(RichTextBox* obj)
{
    return obj->BatchingUndo();
}

ALTERNET_UI_API c_bool RichTextBox_BeginSuppressUndo_(RichTextBox* obj)
{
    return obj->BeginSuppressUndo();
}

ALTERNET_UI_API c_bool RichTextBox_EndSuppressUndo_(RichTextBox* obj)
{
    return obj->EndSuppressUndo();
}

ALTERNET_UI_API c_bool RichTextBox_SuppressingUndo_(RichTextBox* obj)
{
    return obj->SuppressingUndo();
}

ALTERNET_UI_API void RichTextBox_EnableVerticalScrollbar_(RichTextBox* obj, c_bool enable)
{
    obj->EnableVerticalScrollbar(enable);
}

ALTERNET_UI_API c_bool RichTextBox_GetVerticalScrollbarEnabled_(RichTextBox* obj)
{
    return obj->GetVerticalScrollbarEnabled();
}

ALTERNET_UI_API void RichTextBox_SetFontScale_(RichTextBox* obj, double fontScale, c_bool refresh)
{
    obj->SetFontScale(fontScale, refresh);
}

ALTERNET_UI_API double RichTextBox_GetFontScale_(RichTextBox* obj)
{
    return obj->GetFontScale();
}

ALTERNET_UI_API c_bool RichTextBox_GetVirtualAttributesEnabled_(RichTextBox* obj)
{
    return obj->GetVirtualAttributesEnabled();
}

ALTERNET_UI_API c_bool RichTextBox_LoadFromStream_(RichTextBox* obj, void* stream, int type)
{
    return obj->LoadFromStream(stream, type);
}

ALTERNET_UI_API c_bool RichTextBox_SaveToStream_(RichTextBox* obj, void* stream, int type)
{
    return obj->SaveToStream(stream, type);
}

ALTERNET_UI_API c_bool RichTextBox_ApplyStyleToSelection_(RichTextBox* obj, void* style, int flags)
{
    return obj->ApplyStyleToSelection(style, flags);
}

ALTERNET_UI_API void RichTextBox_InitFileHandlers_()
{
    RichTextBox::InitFileHandlers();
}

ALTERNET_UI_API char16_t* RichTextBox_GetRange_(RichTextBox* obj, int64_t from, int64_t to)
{
    return AllocPInvokeReturnString(obj->GetRange(from, to));
}

ALTERNET_UI_API int RichTextBox_GetLineLength_(RichTextBox* obj, int64_t lineNo)
{
    return obj->GetLineLength(lineNo);
}

ALTERNET_UI_API char16_t* RichTextBox_GetLineText_(RichTextBox* obj, int64_t lineNo)
{
    return AllocPInvokeReturnString(obj->GetLineText(lineNo));
}

ALTERNET_UI_API int RichTextBox_GetNumberOfLines_(RichTextBox* obj)
{
    return obj->GetNumberOfLines();
}

ALTERNET_UI_API c_bool RichTextBox_IsModified_(RichTextBox* obj)
{
    return obj->IsModified();
}

ALTERNET_UI_API c_bool RichTextBox_IsEditable_(RichTextBox* obj)
{
    return obj->IsEditable();
}

ALTERNET_UI_API c_bool RichTextBox_IsSingleLine_(RichTextBox* obj)
{
    return obj->IsSingleLine();
}

ALTERNET_UI_API c_bool RichTextBox_IsMultiLine_(RichTextBox* obj)
{
    return obj->IsMultiLine();
}

ALTERNET_UI_API char16_t* RichTextBox_GetStringSelection_(RichTextBox* obj)
{
    return AllocPInvokeReturnString(obj->GetStringSelection());
}

ALTERNET_UI_API char16_t* RichTextBox_GetFilename_(RichTextBox* obj)
{
    return AllocPInvokeReturnString(obj->GetFilename());
}

ALTERNET_UI_API void RichTextBox_SetFilename_(RichTextBox* obj, const char16_t* filename)
{
    obj->SetFilename(filename);
}

ALTERNET_UI_API void RichTextBox_SetDelayedLayoutThreshold_(RichTextBox* obj, int64_t threshold)
{
    obj->SetDelayedLayoutThreshold(threshold);
}

ALTERNET_UI_API int64_t RichTextBox_GetDelayedLayoutThreshold_(RichTextBox* obj)
{
    return obj->GetDelayedLayoutThreshold();
}

ALTERNET_UI_API c_bool RichTextBox_GetFullLayoutRequired_(RichTextBox* obj)
{
    return obj->GetFullLayoutRequired();
}

ALTERNET_UI_API void RichTextBox_SetFullLayoutRequired_(RichTextBox* obj, c_bool b)
{
    obj->SetFullLayoutRequired(b);
}

ALTERNET_UI_API int64_t RichTextBox_GetFullLayoutTime_(RichTextBox* obj)
{
    return obj->GetFullLayoutTime();
}

ALTERNET_UI_API void RichTextBox_SetFullLayoutTime_(RichTextBox* obj, int64_t t)
{
    obj->SetFullLayoutTime(t);
}

ALTERNET_UI_API int64_t RichTextBox_GetFullLayoutSavedPosition_(RichTextBox* obj)
{
    return obj->GetFullLayoutSavedPosition();
}

ALTERNET_UI_API void RichTextBox_SetFullLayoutSavedPosition_(RichTextBox* obj, int64_t p)
{
    obj->SetFullLayoutSavedPosition(p);
}

ALTERNET_UI_API void RichTextBox_ForceDelayedLayout_(RichTextBox* obj)
{
    obj->ForceDelayedLayout();
}

ALTERNET_UI_API c_bool RichTextBox_GetCaretAtLineStart_(RichTextBox* obj)
{
    return obj->GetCaretAtLineStart();
}

ALTERNET_UI_API void RichTextBox_SetCaretAtLineStart_(RichTextBox* obj, c_bool atStart)
{
    obj->SetCaretAtLineStart(atStart);
}

ALTERNET_UI_API c_bool RichTextBox_GetDragging_(RichTextBox* obj)
{
    return obj->GetDragging();
}

ALTERNET_UI_API void RichTextBox_SetDragging_(RichTextBox* obj, c_bool dragging)
{
    obj->SetDragging(dragging);
}

ALTERNET_UI_API void* RichTextBox_GetContextMenu_(RichTextBox* obj)
{
    return obj->GetContextMenu();
}

ALTERNET_UI_API void RichTextBox_SetContextMenu_(RichTextBox* obj, void* menu)
{
    obj->SetContextMenu(menu);
}

ALTERNET_UI_API int64_t RichTextBox_GetSelectionAnchor_(RichTextBox* obj)
{
    return obj->GetSelectionAnchor();
}

ALTERNET_UI_API void RichTextBox_SetSelectionAnchor_(RichTextBox* obj, int64_t anchor)
{
    obj->SetSelectionAnchor(anchor);
}

ALTERNET_UI_API void* RichTextBox_GetSelectionAnchorObject_(RichTextBox* obj)
{
    return obj->GetSelectionAnchorObject();
}

ALTERNET_UI_API void RichTextBox_SetSelectionAnchorObject_(RichTextBox* obj, void* anchor)
{
    obj->SetSelectionAnchorObject(anchor);
}

ALTERNET_UI_API void* RichTextBox_GetFocusObject_(RichTextBox* obj)
{
    return obj->GetFocusObject();
}

ALTERNET_UI_API void RichTextBox_StoreFocusObject_(RichTextBox* obj, void* richObj)
{
    obj->StoreFocusObject(richObj);
}

ALTERNET_UI_API c_bool RichTextBox_SetFocusObject_(RichTextBox* obj, void* richObj, c_bool setCaretPosition)
{
    return obj->SetFocusObject(richObj, setCaretPosition);
}

ALTERNET_UI_API void RichTextBox_Invalidate_(RichTextBox* obj)
{
    obj->Invalidate();
}

ALTERNET_UI_API void RichTextBox_Clear_(RichTextBox* obj)
{
    obj->Clear();
}

ALTERNET_UI_API void RichTextBox_Replace_(RichTextBox* obj, int64_t from, int64_t to, const char16_t* value)
{
    obj->Replace(from, to, value);
}

ALTERNET_UI_API void RichTextBox_Remove_(RichTextBox* obj, int64_t from, int64_t to)
{
    obj->Remove(from, to);
}

ALTERNET_UI_API c_bool RichTextBox_LoadFile_(RichTextBox* obj, const char16_t* file, int type)
{
    return obj->LoadFile(file, type);
}

ALTERNET_UI_API c_bool RichTextBox_SaveFile_(RichTextBox* obj, const char16_t* file, int type)
{
    return obj->SaveFile(file, type);
}

ALTERNET_UI_API void RichTextBox_SetHandlerFlags_(RichTextBox* obj, int flags)
{
    obj->SetHandlerFlags(flags);
}

ALTERNET_UI_API int RichTextBox_GetHandlerFlags_(RichTextBox* obj)
{
    return obj->GetHandlerFlags();
}

ALTERNET_UI_API void RichTextBox_MarkDirty_(RichTextBox* obj)
{
    obj->MarkDirty();
}

ALTERNET_UI_API void RichTextBox_DiscardEdits_(RichTextBox* obj)
{
    obj->DiscardEdits();
}

ALTERNET_UI_API void RichTextBox_SetMaxLength_(RichTextBox* obj, uint64_t len)
{
    obj->SetMaxLength(len);
}

ALTERNET_UI_API void RichTextBox_WriteText_(RichTextBox* obj, const char16_t* text)
{
    obj->WriteText(text);
}

ALTERNET_UI_API void RichTextBox_AppendText_(RichTextBox* obj, const char16_t* text)
{
    obj->AppendText(text);
}

ALTERNET_UI_API int64_t RichTextBox_XYToPosition_(RichTextBox* obj, int64_t x, int64_t y)
{
    return obj->XYToPosition(x, y);
}

ALTERNET_UI_API void RichTextBox_ShowPosition_(RichTextBox* obj, int64_t pos)
{
    obj->ShowPosition(pos);
}

ALTERNET_UI_API void RichTextBox_Copy_(RichTextBox* obj)
{
    obj->Copy();
}

ALTERNET_UI_API void RichTextBox_Cut_(RichTextBox* obj)
{
    obj->Cut();
}

ALTERNET_UI_API void RichTextBox_Paste_(RichTextBox* obj)
{
    obj->Paste();
}

ALTERNET_UI_API void RichTextBox_DeleteSelection_(RichTextBox* obj)
{
    obj->DeleteSelection();
}

ALTERNET_UI_API c_bool RichTextBox_CanCopy_(RichTextBox* obj)
{
    return obj->CanCopy();
}

ALTERNET_UI_API c_bool RichTextBox_CanCut_(RichTextBox* obj)
{
    return obj->CanCut();
}

ALTERNET_UI_API c_bool RichTextBox_CanPaste_(RichTextBox* obj)
{
    return obj->CanPaste();
}

ALTERNET_UI_API c_bool RichTextBox_CanDeleteSelection_(RichTextBox* obj)
{
    return obj->CanDeleteSelection();
}

ALTERNET_UI_API void RichTextBox_Undo_(RichTextBox* obj)
{
    obj->Undo();
}

ALTERNET_UI_API void RichTextBox_Redo_(RichTextBox* obj)
{
    obj->Redo();
}

ALTERNET_UI_API c_bool RichTextBox_CanUndo_(RichTextBox* obj)
{
    return obj->CanUndo();
}

ALTERNET_UI_API c_bool RichTextBox_CanRedo_(RichTextBox* obj)
{
    return obj->CanRedo();
}

ALTERNET_UI_API void RichTextBox_SetInsertionPoint_(RichTextBox* obj, int64_t pos)
{
    obj->SetInsertionPoint(pos);
}

ALTERNET_UI_API void RichTextBox_SetInsertionPointEnd_(RichTextBox* obj)
{
    obj->SetInsertionPointEnd();
}

ALTERNET_UI_API int64_t RichTextBox_GetInsertionPoint_(RichTextBox* obj)
{
    return obj->GetInsertionPoint();
}

ALTERNET_UI_API void RichTextBox_SetSelection_(RichTextBox* obj, int64_t from, int64_t to)
{
    obj->SetSelection(from, to);
}

ALTERNET_UI_API void RichTextBox_SetEditable_(RichTextBox* obj, c_bool editable)
{
    obj->SetEditable(editable);
}

ALTERNET_UI_API c_bool RichTextBox_HasSelection_(RichTextBox* obj)
{
    return obj->HasSelection();
}

ALTERNET_UI_API c_bool RichTextBox_HasUnfocusedSelection_(RichTextBox* obj)
{
    return obj->HasUnfocusedSelection();
}

ALTERNET_UI_API c_bool RichTextBox_Newline_(RichTextBox* obj)
{
    return obj->Newline();
}

ALTERNET_UI_API c_bool RichTextBox_LineBreak_(RichTextBox* obj)
{
    return obj->LineBreak();
}

ALTERNET_UI_API c_bool RichTextBox_EndStyle_(RichTextBox* obj)
{
    return obj->EndStyle();
}

ALTERNET_UI_API c_bool RichTextBox_EndAllStyles_(RichTextBox* obj)
{
    return obj->EndAllStyles();
}

ALTERNET_UI_API c_bool RichTextBox_BeginBold_(RichTextBox* obj)
{
    return obj->BeginBold();
}

ALTERNET_UI_API void RichTextBox_SetEventCallback_(RichTextBox::RichTextBoxEventCallbackType callback)
{
    RichTextBox::SetEventCallback(callback);
}

