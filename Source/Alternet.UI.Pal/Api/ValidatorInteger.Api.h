// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>

#pragma once

#include "ValidatorInteger.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API ValidatorInteger* ValidatorInteger_Create_()
{
    return MarshalExceptions<ValidatorInteger*>([&](){
            return new ValidatorInteger();
        });
}
