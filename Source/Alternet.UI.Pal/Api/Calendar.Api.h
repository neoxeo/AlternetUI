// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2023 AlterNET Software.</auto-generated>

#pragma once

#include "Calendar.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Calendar* Calendar_Create_()
{
    return new Calendar();
}

ALTERNET_UI_API c_bool Calendar_GetSundayFirst_(Calendar* obj)
{
    return obj->GetSundayFirst();
}

ALTERNET_UI_API void Calendar_SetSundayFirst_(Calendar* obj, c_bool value)
{
    obj->SetSundayFirst(value);
}

ALTERNET_UI_API c_bool Calendar_GetMondayFirst_(Calendar* obj)
{
    return obj->GetMondayFirst();
}

ALTERNET_UI_API void Calendar_SetMondayFirst_(Calendar* obj, c_bool value)
{
    obj->SetMondayFirst(value);
}

ALTERNET_UI_API c_bool Calendar_GetShowHolidays_(Calendar* obj)
{
    return obj->GetShowHolidays();
}

ALTERNET_UI_API void Calendar_SetShowHolidays_(Calendar* obj, c_bool value)
{
    obj->SetShowHolidays(value);
}

ALTERNET_UI_API c_bool Calendar_GetNoYearChange_(Calendar* obj)
{
    return obj->GetNoYearChange();
}

ALTERNET_UI_API void Calendar_SetNoYearChange_(Calendar* obj, c_bool value)
{
    obj->SetNoYearChange(value);
}

ALTERNET_UI_API c_bool Calendar_GetNoMonthChange_(Calendar* obj)
{
    return obj->GetNoMonthChange();
}

ALTERNET_UI_API void Calendar_SetNoMonthChange_(Calendar* obj, c_bool value)
{
    obj->SetNoMonthChange(value);
}

ALTERNET_UI_API c_bool Calendar_GetSequentalMonthSelect_(Calendar* obj)
{
    return obj->GetSequentalMonthSelect();
}

ALTERNET_UI_API void Calendar_SetSequentalMonthSelect_(Calendar* obj, c_bool value)
{
    obj->SetSequentalMonthSelect(value);
}

ALTERNET_UI_API c_bool Calendar_GetShowSurroundWeeks_(Calendar* obj)
{
    return obj->GetShowSurroundWeeks();
}

ALTERNET_UI_API void Calendar_SetShowSurroundWeeks_(Calendar* obj, c_bool value)
{
    obj->SetShowSurroundWeeks(value);
}

ALTERNET_UI_API c_bool Calendar_GetShowWeekNumbers_(Calendar* obj)
{
    return obj->GetShowWeekNumbers();
}

ALTERNET_UI_API void Calendar_SetShowWeekNumbers_(Calendar* obj, c_bool value)
{
    obj->SetShowWeekNumbers(value);
}

ALTERNET_UI_API c_bool Calendar_GetUseGeneric_(Calendar* obj)
{
    return obj->GetUseGeneric();
}

ALTERNET_UI_API void Calendar_SetUseGeneric_(Calendar* obj, c_bool value)
{
    obj->SetUseGeneric(value);
}

ALTERNET_UI_API c_bool Calendar_GetHasBorder_(Calendar* obj)
{
    return obj->GetHasBorder();
}

ALTERNET_UI_API void Calendar_SetHasBorder_(Calendar* obj, c_bool value)
{
    obj->SetHasBorder(value);
}

ALTERNET_UI_API DateTime_C Calendar_GetValue_(Calendar* obj)
{
    return obj->GetValue();
}

ALTERNET_UI_API void Calendar_SetValue_(Calendar* obj, DateTime value)
{
    obj->SetValue(value);
}

ALTERNET_UI_API DateTime_C Calendar_GetMinValue_(Calendar* obj)
{
    return obj->GetMinValue();
}

ALTERNET_UI_API void Calendar_SetMinValue_(Calendar* obj, DateTime value)
{
    obj->SetMinValue(value);
}

ALTERNET_UI_API DateTime_C Calendar_GetMaxValue_(Calendar* obj)
{
    return obj->GetMaxValue();
}

ALTERNET_UI_API void Calendar_SetMaxValue_(Calendar* obj, DateTime value)
{
    obj->SetMaxValue(value);
}

ALTERNET_UI_API c_bool Calendar_SetRange_(Calendar* obj, c_bool useMinValue, c_bool useMaxValue)
{
    return obj->SetRange(useMinValue, useMaxValue);
}

ALTERNET_UI_API void Calendar_SetHolidayColors_(Calendar* obj, Color colorFg, Color colorBg)
{
    obj->SetHolidayColors(colorFg, colorBg);
}

ALTERNET_UI_API Color_C Calendar_GetHolidayColorFg_(Calendar* obj)
{
    return obj->GetHolidayColorFg();
}

ALTERNET_UI_API Color_C Calendar_GetHolidayColorBg_(Calendar* obj)
{
    return obj->GetHolidayColorBg();
}

ALTERNET_UI_API void Calendar_SetHeaderColors_(Calendar* obj, Color colorFg, Color colorBg)
{
    obj->SetHeaderColors(colorFg, colorBg);
}

ALTERNET_UI_API Color_C Calendar_GetHeaderColorFg_(Calendar* obj)
{
    return obj->GetHeaderColorFg();
}

ALTERNET_UI_API Color_C Calendar_GetHeaderColorBg_(Calendar* obj)
{
    return obj->GetHeaderColorBg();
}

ALTERNET_UI_API void Calendar_SetHighlightColors_(Calendar* obj, Color colorFg, Color colorBg)
{
    obj->SetHighlightColors(colorFg, colorBg);
}

ALTERNET_UI_API Color_C Calendar_GetHighlightColorFg_(Calendar* obj)
{
    return obj->GetHighlightColorFg();
}

ALTERNET_UI_API Color_C Calendar_GetHighlightColorBg_(Calendar* obj)
{
    return obj->GetHighlightColorBg();
}

ALTERNET_UI_API c_bool Calendar_AllowMonthChange_(Calendar* obj)
{
    return obj->AllowMonthChange();
}

ALTERNET_UI_API c_bool Calendar_EnableMonthChange_(Calendar* obj, c_bool enable)
{
    return obj->EnableMonthChange(enable);
}

ALTERNET_UI_API void Calendar_Mark_(Calendar* obj, int day, c_bool mark)
{
    obj->Mark(day, mark);
}

ALTERNET_UI_API void* Calendar_GetAttr_(Calendar* obj, int day)
{
    return obj->GetAttr(day);
}

ALTERNET_UI_API void Calendar_SetAttr_(Calendar* obj, int day, void* calendarDateAttr)
{
    obj->SetAttr(day, calendarDateAttr);
}

ALTERNET_UI_API void Calendar_ResetAttr_(Calendar* obj, int day)
{
    obj->ResetAttr(day);
}

ALTERNET_UI_API void Calendar_EnableHolidayDisplay_(Calendar* obj, c_bool display)
{
    obj->EnableHolidayDisplay(display);
}

ALTERNET_UI_API void Calendar_SetHoliday_(Calendar* obj, int day)
{
    obj->SetHoliday(day);
}

ALTERNET_UI_API void* Calendar_GetMarkDateAttr_()
{
    return Calendar::GetMarkDateAttr();
}

ALTERNET_UI_API void Calendar_SetMarkDateAttr_(void* dateAttr)
{
    Calendar::SetMarkDateAttr(dateAttr);
}

ALTERNET_UI_API void* Calendar_CreateDateAttr_(int border)
{
    return Calendar::CreateDateAttr(border);
}

ALTERNET_UI_API void Calendar_DeleteDateAttr_(void* handle)
{
    Calendar::DeleteDateAttr(handle);
}

ALTERNET_UI_API void Calendar_DateAttrSetTextColor_(void* handle, Color colText)
{
    Calendar::DateAttrSetTextColor(handle, colText);
}

ALTERNET_UI_API void Calendar_DateAttrSetBackgroundColor_(void* handle, Color colBack)
{
    Calendar::DateAttrSetBackgroundColor(handle, colBack);
}

ALTERNET_UI_API void Calendar_DateAttrSetBorderColor_(void* handle, Color color)
{
    Calendar::DateAttrSetBorderColor(handle, color);
}

ALTERNET_UI_API void Calendar_DateAttrSetFont_(void* handle, void* font)
{
    Calendar::DateAttrSetFont(handle, font);
}

ALTERNET_UI_API void Calendar_DateAttrSetBorder_(void* handle, int border)
{
    Calendar::DateAttrSetBorder(handle, border);
}

ALTERNET_UI_API void Calendar_DateAttrSetHoliday_(void* handle, c_bool holiday)
{
    Calendar::DateAttrSetHoliday(handle, holiday);
}

ALTERNET_UI_API c_bool Calendar_DateAttrHasTextColor_(void* handle)
{
    return Calendar::DateAttrHasTextColor(handle);
}

ALTERNET_UI_API c_bool Calendar_DateAttrHasBackgroundColor_(void* handle)
{
    return Calendar::DateAttrHasBackgroundColor(handle);
}

ALTERNET_UI_API c_bool Calendar_DateAttrHasBorderColor_(void* handle)
{
    return Calendar::DateAttrHasBorderColor(handle);
}

ALTERNET_UI_API c_bool Calendar_DateAttrHasFont_(void* handle)
{
    return Calendar::DateAttrHasFont(handle);
}

ALTERNET_UI_API c_bool Calendar_DateAttrHasBorder_(void* handle)
{
    return Calendar::DateAttrHasBorder(handle);
}

ALTERNET_UI_API c_bool Calendar_DateAttrIsHoliday_(void* handle)
{
    return Calendar::DateAttrIsHoliday(handle);
}

ALTERNET_UI_API Color_C Calendar_DateAttrGetTextColor_(void* handle)
{
    return Calendar::DateAttrGetTextColor(handle);
}

ALTERNET_UI_API Color_C Calendar_DateAttrGetBackgroundColor_(void* handle)
{
    return Calendar::DateAttrGetBackgroundColor(handle);
}

ALTERNET_UI_API Color_C Calendar_DateAttrGetBorderColor_(void* handle)
{
    return Calendar::DateAttrGetBorderColor(handle);
}

ALTERNET_UI_API void* Calendar_DateAttrGetFont_(void* handle)
{
    return Calendar::DateAttrGetFont(handle);
}

ALTERNET_UI_API int Calendar_DateAttrGetBorder_(void* handle)
{
    return Calendar::DateAttrGetBorder(handle);
}

ALTERNET_UI_API void Calendar_SetEventCallback_(Calendar::CalendarEventCallbackType callback)
{
    Calendar::SetEventCallback(callback);
}

