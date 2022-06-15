#pragma once

#include "Common.h"
#include "MainMenu.h"
#include "MenuItem.h"
#include "Menu.h"

#ifdef __WXOSX_COCOA__

namespace Alternet::UI::MacOSMenu
{
    namespace
    {
        namespace RoleNames
        {
            // These must currespond to the ones defined on the .NET side.
            inline const char16_t* None = u"None";
            inline const char16_t* Auto = u"Auto";
            inline const char16_t* About = u"About";
            inline const char16_t* Exit = u"Exit";
            inline const char16_t* Preferences = u"Preferences";
        }

        std::vector<MenuItem*> GetAllMenuItems(Menu* menu)
        {
            std::vector<MenuItem*> result;
            for (auto item : menu->GetItems())
            {
                result.push_back(item);
                
                auto submenu = item->GetSubmenu();
                if (submenu == nullptr)
                    continue;

                auto items = GetAllMenuItems(submenu);
                result.insert(result.end(), items.begin(), items.end());
                
                submenu->Release();
            }

            return result;
        }

        std::vector<MenuItem*> GetAllMenuItems(MainMenu* mainMenu)
        {
            std::vector<MenuItem*> result;
            for (auto menu : mainMenu->GetItems())
            {
                auto items = GetAllMenuItems(menu);
                result.insert(result.end(), items.begin(), items.end());
            }

            return result;
        }

        bool DeduceAboutRole(MenuItem* item)
        {
            auto name = item->GetWxMenuItem()->GetItemLabelText();
            return name == "About" || name == "About..." || name.StartsWith("About ");
        }

        bool DeducePreferencesRole(MenuItem* item)
        {
            auto name = item->GetWxMenuItem()->GetItemLabelText();
            return  name == "Preferences" || name == "Preferences..." ||
                    name == "Options" || name == "Options...";
        }

        MenuItem* FindItemWithDeducedRole(const std::vector<MenuItem*>& items, const string& role)
        {
            MenuItem* foundItem = nullptr;
            for (auto item : items)
            {
                auto itemRole = item->GetRole();
                if (itemRole != u"" && itemRole != RoleNames::Auto)
                    continue;

                if (role == RoleNames::About)
                    foundItem = DeduceAboutRole(item) ? item : nullptr;
                else if (role == RoleNames::Preferences)
                    foundItem = DeducePreferencesRole(item) ? item : nullptr;
                
                if (foundItem != nullptr)
                    break;
            }

            return foundItem;
        }

        MenuItem* FindItemWithExplicitRole(const std::vector<MenuItem*>& items, const string& role)
        {
            for (auto item : items)
            {
                if (item->GetRole() == role)
                    return item;
            }

            return nullptr;
        }

        MenuItem* FindItemWithRole(MainMenu* mainMenu, const string& role)
        {
            auto items = GetAllMenuItems(mainMenu);

            auto explicitItem = FindItemWithExplicitRole(items, role);
            if (explicitItem != nullptr)
                return explicitItem;

            auto deducedItem = FindItemWithDeducedRole(items, role);
            if (deducedItem != nullptr)
                return deducedItem;

            return nullptr;
        }
    }

    string GetApplicationName()
    {
        return u"";
    }

    void RestoreItemOverride(MainMenu* mainMenu, MenuItem* item)
    {
        auto data = item->GetRoleBasedOverrideData().value();
        
        data.parentMenuOverride->Remove(item->GetWxMenuItem());
        item->SetRoleBasedOverrideData(nullopt);
        item->SetText(u""); // To force recreaction of the item.
        item->SetText(data.preservedText);
        item->SetShortcut(data.preservedKey, data.preservedModifierKeys);
    }

    void RestoreAllOverrides(MainMenu* mainMenu)
    {
        auto items = GetAllMenuItems(mainMenu);
        for (auto item : items)
        {
            if (item->GetRoleBasedOverrideData().has_value())
                RestoreItemOverride(mainMenu, item);
        }
    }

    void MoveItemToAppMenu(MenuItem* item, wxMenu* appMenu, string newName, Key key, ModifierKeys modifierKeys)
    {
        auto oldText = item->GetText();
        auto oldKey = item->GetShortcutKey();
        auto oldModifierKeys = item->GetShortcutModifierKeys();

        item->SetText(newName);
        item->SetShortcut(key, modifierKeys);
        item->GetParentMenu()->GetWxMenu()->Remove(item->GetWxMenuItem());
        appMenu->Insert(0, item->GetWxMenuItem());
        item->SetRoleBasedOverrideData(
            MenuItem::RoleBasedOverrideData {appMenu, oldText, oldKey, oldModifierKeys});
    }

    void ApplyItemRoles(MainMenu* mainMenu)
    {
        RestoreAllOverrides(mainMenu);

        auto appMenu = mainMenu->GetWxMenuBar()->OSXGetAppleMenu();

        auto preferencesItem = FindItemWithRole(mainMenu, RoleNames::Preferences);
        if (preferencesItem != nullptr)
            MoveItemToAppMenu(preferencesItem, appMenu, u"Preferences...", Key::Comma, ModifierKeys::Control);

        auto aboutItem = FindItemWithRole(mainMenu, RoleNames::About);
        if (aboutItem != nullptr)
            MoveItemToAppMenu(aboutItem, appMenu, u"About " + GetApplicationName(), Key::None, ModifierKeys::None);
    }

    void EnsureHelpItemIsLast(wxMenuBar* menuBar)
    {
        // macOS appends "Window" menu to the main menu automatically.
        // If our menu has "Help" menu, move it to the end, after the "Window" menu.
        // This only needs to be done when there is no "Window" menu explicitly added by the user.

        auto windowMenuIndex = menuBar->FindMenu("Window");
        if (windowMenuIndex != wxNOT_FOUND)
            return;

        auto helpMenuIndex = menuBar->FindMenu("Help");
        if (helpMenuIndex == wxNOT_FOUND)
            return;

        auto helpMenu = menuBar->GetMenu(helpMenuIndex);
        auto helpMenuLabel = menuBar->GetMenuLabel(helpMenuIndex);

        menuBar->Remove(helpMenuIndex);
        menuBar->Append(helpMenu, helpMenuLabel);
    }
}

#endif