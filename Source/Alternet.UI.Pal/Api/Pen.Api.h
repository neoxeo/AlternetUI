// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "Pen.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Pen* Pen_Create_()
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<Pen*>([&](){
    #endif
        return new Pen();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void Pen_Initialize_(Pen* obj, PenDashStyle style, Color color, double width, LineCap lineCap, LineJoin lineJoin)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->Initialize(style, color, width, lineCap, lineJoin);
    #if !defined(__WXMSW__)
    });
    #endif
}

