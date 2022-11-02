#include "NotifyIcon.h"

namespace Alternet::UI
{
    NotifyIcon::NotifyIcon()
    {
    }

    NotifyIcon::~NotifyIcon()
    {
        DeleteTaskBarIcon();
    }

    void NotifyIcon::CreateTaskBarIcon()
    {
        if (_taskBarIcon != nullptr)
            throwExNoInfo;

        _taskBarIcon = new wxTaskBarIcon();
        
        auto text = wxStr(_text.value_or(u""));

        if (_icon != nullptr)
        {
            wxBitmapBundle bundle(_icon->GetBitmap());
            _taskBarIcon->SetIcon(bundle, text);
        }
        else
        {
            wxBitmapBundle bundle;
            _taskBarIcon->SetIcon(bundle, text);
        }
    }

    void NotifyIcon::DeleteTaskBarIcon()
    {
        if (_taskBarIcon != nullptr)
        {
            delete _taskBarIcon;
            _taskBarIcon = nullptr;
        }
    }

    void NotifyIcon::RecreateTaskBarIcon()
    {
        DeleteTaskBarIcon();

        if (_visible)
            CreateTaskBarIcon();
    }

    optional<string> NotifyIcon::GetText()
    {
        return _text;
    }

    void NotifyIcon::SetText(optional<string> value)
    {
        _text = value;
        RecreateTaskBarIcon();
    }

    Image* NotifyIcon::GetIcon()
    {
        return _icon;
    }

    void NotifyIcon::SetIcon(Image* value)
    {
        _icon = value;
        RecreateTaskBarIcon();
    }

    Menu* NotifyIcon::GetMenu()
    {
        return nullptr;
    }

    void NotifyIcon::SetMenu(Menu* value)
    {
    }

    bool NotifyIcon::GetVisible()
    {
        return _visible;
    }

    void NotifyIcon::SetVisible(bool value)
    {
        _visible = value;
        RecreateTaskBarIcon();
    }
}
