// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "TransformMatrix.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API TransformMatrix* TransformMatrix_Create_()
{
    return new TransformMatrix();
}

ALTERNET_UI_API double TransformMatrix_GetM11_(TransformMatrix* obj)
{
    return obj->GetM11();
}

ALTERNET_UI_API void TransformMatrix_SetM11_(TransformMatrix* obj, double value)
{
    obj->SetM11(value);
}

ALTERNET_UI_API double TransformMatrix_GetM12_(TransformMatrix* obj)
{
    return obj->GetM12();
}

ALTERNET_UI_API void TransformMatrix_SetM12_(TransformMatrix* obj, double value)
{
    obj->SetM12(value);
}

ALTERNET_UI_API double TransformMatrix_GetM21_(TransformMatrix* obj)
{
    return obj->GetM21();
}

ALTERNET_UI_API void TransformMatrix_SetM21_(TransformMatrix* obj, double value)
{
    obj->SetM21(value);
}

ALTERNET_UI_API double TransformMatrix_GetM22_(TransformMatrix* obj)
{
    return obj->GetM22();
}

ALTERNET_UI_API void TransformMatrix_SetM22_(TransformMatrix* obj, double value)
{
    obj->SetM22(value);
}

ALTERNET_UI_API double TransformMatrix_GetDX_(TransformMatrix* obj)
{
    return obj->GetDX();
}

ALTERNET_UI_API void TransformMatrix_SetDX_(TransformMatrix* obj, double value)
{
    obj->SetDX(value);
}

ALTERNET_UI_API double TransformMatrix_GetDY_(TransformMatrix* obj)
{
    return obj->GetDY();
}

ALTERNET_UI_API void TransformMatrix_SetDY_(TransformMatrix* obj, double value)
{
    obj->SetDY(value);
}

ALTERNET_UI_API c_bool TransformMatrix_GetIsIdentity_(TransformMatrix* obj)
{
    return obj->GetIsIdentity();
}

ALTERNET_UI_API void TransformMatrix_Initialize_(TransformMatrix* obj, double m11, double m12, double m21, double m22, double dx, double dy)
{
    obj->Initialize(m11, m12, m21, m22, dx, dy);
}

ALTERNET_UI_API void TransformMatrix_Reset_(TransformMatrix* obj)
{
    obj->Reset();
}

ALTERNET_UI_API void TransformMatrix_Multiply_(TransformMatrix* obj, TransformMatrix* matrix)
{
    obj->Multiply(matrix);
}

ALTERNET_UI_API void TransformMatrix_Translate_(TransformMatrix* obj, double offsetX, double offsetY)
{
    obj->Translate(offsetX, offsetY);
}

ALTERNET_UI_API void TransformMatrix_Scale_(TransformMatrix* obj, double scaleX, double scaleY)
{
    obj->Scale(scaleX, scaleY);
}

ALTERNET_UI_API void TransformMatrix_Rotate_(TransformMatrix* obj, double angle)
{
    obj->Rotate(angle);
}

ALTERNET_UI_API void TransformMatrix_Invert_(TransformMatrix* obj)
{
    obj->Invert();
}

ALTERNET_UI_API PointD_C TransformMatrix_TransformPoint_(TransformMatrix* obj, PointD point)
{
    return obj->TransformPoint(point);
}

ALTERNET_UI_API SizeD_C TransformMatrix_TransformSize_(TransformMatrix* obj, SizeD size)
{
    return obj->TransformSize(size);
}

ALTERNET_UI_API c_bool TransformMatrix_IsEqualTo_(TransformMatrix* obj, TransformMatrix* other)
{
    return obj->IsEqualTo(other);
}

ALTERNET_UI_API int TransformMatrix_GetHashCode__(TransformMatrix* obj)
{
    return obj->GetHashCode_();
}

