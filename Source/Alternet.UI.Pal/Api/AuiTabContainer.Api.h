// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>

#pragma once

#include "AuiTabContainer.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API AuiTabContainer* AuiTabContainer_Create_()
{
    return MarshalExceptions<AuiTabContainer*>([&](){
            return new AuiTabContainer();
        });
}
