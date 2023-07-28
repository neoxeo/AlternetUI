#include "FontDialog.h"

namespace Alternet::UI
{

    bool FontDialog::GetAllowSymbols()
    {
        return _allowSymbols;
    }

    void FontDialog::SetAllowSymbols(bool value)
    {
        _allowSymbols = value;
    }

    bool FontDialog::GetShowHelp()
    {
        return _showHelp;
    }

    void FontDialog::SetShowHelp(bool value)
    {
        _showHelp = value;
    }

    bool FontDialog::GetEnableEffects()
    {
        return _enableEffects;
    }

    void FontDialog::SetEnableEffects(bool value)
    {
        _enableEffects = value;
    }

    int FontDialog::GetRestrictSelection()
    {
        return _restrictSelection;
    }

    void FontDialog::SetRestrictSelection(int value)
    {
        _restrictSelection = value;
    }

    void FontDialog::SetRange(int minRange, int maxRange)
    {
        _minRange = minRange;
        _maxRange = _maxRange;
    }

    Color FontDialog::GetColor()
    {
        return _color;
    }

    void FontDialog::SetColor(const Color& value)
    {
        _color = value;
    }

    Font* FontDialog::GetFont()
    {
        //Font* font = new Font();
        //font->SetWxFont(_wxfont);
        //return font;
        return nullptr;
    }

    void FontDialog::SetFont(Font* value)
    {
        if (value == nullptr)
            return;
        //_wxfont = value->GetWxFont();
    }

    wxFontData& FontDialog::GetFontData() 
    {
        wxFontData& data = GetDialog()->GetFontData();
        return data;
    }

    bool FontDialog::DialogGetAllowSymbols()
    {
        return GetFontData().GetAllowSymbols();
    }

    void FontDialog::DialogSetAllowSymbols(bool value)
    {
        GetFontData().SetAllowSymbols(value);
    }

    bool FontDialog::DialogGetShowHelp()
    {
        return GetFontData().GetShowHelp();
    }

    void FontDialog::DialogSetShowHelp(bool value)
    {
        GetFontData().SetShowHelp(value);
    }

    bool FontDialog::DialogGetEnableEffects()
    {
        return GetFontData().GetEnableEffects();
    }

    void FontDialog::DialogSetEnableEffects(bool value)
    {
        GetFontData().EnableEffects(value);
    }

    int FontDialog::DialogGetRestrictSelection()
    {
        return GetFontData().GetRestrictSelection();
    }

    void FontDialog::DialogSetRestrictSelection(int value)
    {
        GetFontData().RestrictSelection(value);
    }

    void FontDialog::DialogSetRange(int minRange, int maxRange)
    {
        GetFontData().SetRange(minRange, maxRange);
    }

    Color FontDialog::DialogGetColor()
    {
        return GetFontData().GetColour();
    }

    void FontDialog::DialogSetColor(const Color& value)
    {
        GetFontData().SetColour(value);
    }

    wxFont FontDialog::DialogGetFont()
    {
        wxFontData& _data = GetDialog()->GetFontData();
        auto wxf = _data.GetChosenFont();
        return wxf;
    }

    optional<string> FontDialog::GetTitle()
    {
        return _title;
    }

    void FontDialog::SetTitle(optional<string> value)
    {
        _title = value;
        GetDialog()->SetTitle(wxStr(value.value_or(u"")));
    }

    ModalResult FontDialog::ShowModal(Window* owner)
    {
        bool ownerChanged = _owner != owner;
        _owner = owner;
        if (ownerChanged)
            RecreateDialog();

#if defined(__WXMSW__)
        DialogSetAllowSymbols(_allowSymbols);
        DialogSetShowHelp(_showHelp);
        DialogSetEnableEffects(_enableEffects);
        DialogSetRestrictSelection(_restrictSelection);
        DialogSetRange(_minRange, _maxRange);
#endif
        DialogSetColor(_color);

       // GetFontData().SetInitialFont(_wxfont);

        auto result = GetDialog()->ShowModal();

        if (result == wxID_OK)
        {
            wxFont font = DialogGetFont();

            //_wxfont = font;
            _color = DialogGetColor();
            return ModalResult::Accepted;
        }
        else if (result == wxID_CANCEL)
            return ModalResult::Canceled;
        else
            throwExNoInfo;
    }

    void FontDialog::RecreateDialog()
    {
        DestroyDialog();
        CreateDialog();
    }

    wxFontDialog* FontDialog::GetDialog()
    {
        if (_dialog == nullptr)
            RecreateDialog();

        return _dialog;
    }

    void FontDialog::DestroyDialog()
    {
        if (_dialog != nullptr)
        {
            delete _dialog;
            _dialog = nullptr;
        }

        /*if (_data != nullptr)
        {
            delete _data;
            _data = nullptr;
        }*/
    }

    FontDialog::FontDialog()
    {
    }

    FontDialog::~FontDialog()
    {
        DestroyDialog();
    }

    void FontDialog::CreateDialog()
    {
        auto owner = _owner != nullptr ? _owner->GetWxWindow() : nullptr;

        _dialog = new wxFontDialog(owner);

        if (_title.has_value())
            _dialog->SetTitle(wxStr(_title.value()));
    }
}

