#pragma once

#include "Common.h"
#include "DrawingContext.h"
#include "Object.h"

namespace Alternet::UI
{
    class Control : public Object
    {
#include "Api/Control.inc"
    public:
        virtual wxWindow* CreateWxWindowCore(wxWindow* parent) = 0;

        wxWindow* GetWxWindow();
        bool IsWxWindowCreated();

    protected:
        void CreateWxWindow();

        virtual void OnWxWindowCreated();
        DelayedValues& GetDelayedValues();

        virtual wxWindow* GetParentingWxWindow();

        virtual SizeF GetDefaultSize();

        virtual Color RetrieveBackgroundColor();
        virtual void ApplyBackgroundColor(const Color& value);

    private:
        enum class ControlFlags
        {
            None = 0,
            Visible = 1 << 0,
        };

        wxWindow* _wxWindow = nullptr;
        Control* _parent = nullptr;
        std::vector<Control*> _children;

        DelayedFlags<Control, ControlFlags> _flags;
        DelayedValue<Control, RectangleF> _bounds;
        DelayedValue<Control, Color> _backgroundColor;
        DelayedValues _delayedValues;

        bool RetrieveVisible();
        void ApplyVisible(bool value);

        RectangleF RetrieveBounds();
        void ApplyBounds(const RectangleF& value);

        void OnPaint(wxPaintEvent& event);

        void OnMouseCaptureLost(wxEvent& event);

        void OnMouseMove(wxMouseEvent& event);
        void OnMouseEnter(wxMouseEvent& event);
        void OnMouseLeave(wxMouseEvent& event);
        void OnMouseLeftButtonDown(wxMouseEvent& event);
        void OnMouseLeftButtonUp(wxMouseEvent& event);
    };
}

template<> struct enable_bitmask_operators<Alternet::UI::Control::ControlFlags> { static const bool enable = true; };

