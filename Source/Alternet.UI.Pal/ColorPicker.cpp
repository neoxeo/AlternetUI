#include "ColorPicker.h"

namespace Alternet::UI
{
    ColorPicker::ColorPicker():
        _value(*this, *wxBLACK, &Control::IsWxWindowCreated, &ColorPicker::RetrieveValue, &ColorPicker::ApplyValue)
    {
        GetDelayedValues().Add(&_value);
    }

    ColorPicker::~ColorPicker()
    {
        if (IsWxWindowCreated())
        {
            auto window = GetWxWindow();
            if (window != nullptr)
            {
                window->Unbind(wxEVT_COLOURPICKER_CHANGED, &ColorPicker::OnColourPickerValueChanged, this);
            }
        }
    }

    Color ColorPicker::GetValue()
    {
        return _value.Get();
    }

    void ColorPicker::SetValue(const Color& value)
    {
        _value.Set(value);
    }

    class wxColourPickerCtrl2 : public wxColourPickerCtrl, public wxWidgetExtender
    {
    public:
        wxColourPickerCtrl2(wxWindow* parent, wxWindowID id,
            const wxColour& col = *wxBLACK, const wxPoint& pos = wxDefaultPosition,
            const wxSize& size = wxDefaultSize, long style = wxCLRP_DEFAULT_STYLE,
            const wxValidator& validator = wxDefaultValidator,
            const wxString& name = wxASCII_STR(wxColourPickerCtrlNameStr))
        {
            Create(parent, id, col, pos, size, style, validator, name);
        }
    };

    wxWindow* ColorPicker::CreateWxWindowCore(wxWindow* parent)
    {
        auto value = new wxColourPickerCtrl2(parent, wxID_ANY,
            *wxBLACK,
            wxDefaultPosition,
            wxDefaultSize,
            wxCLRP_DEFAULT_STYLE,
            wxDefaultValidator,
            wxASCII_STR(wxColourPickerCtrlNameStr));

        value->Bind(wxEVT_COLOURPICKER_CHANGED, &ColorPicker::OnColourPickerValueChanged, this);
        return value;
    }
    
    void ColorPicker::OnColourPickerValueChanged(wxColourPickerEvent& event)
    {
        RaiseEvent(ColorPickerEvent::ValueChanged);
    }
    
    wxColourPickerCtrl* ColorPicker::GetColourPickerCtrl()
    {
        return dynamic_cast<wxColourPickerCtrl*>(GetWxWindow());
    }
    
    Color ColorPicker::RetrieveValue()
    {
        return GetColourPickerCtrl()->GetColour();
    }
    
    void ColorPicker::ApplyValue(const Color& value)
    {
        GetColourPickerCtrl()->SetColour(value);
    }
}
