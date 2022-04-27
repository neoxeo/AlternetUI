#include "Font.h"

namespace Alternet::UI
{
    Font::Font()
    {
    }

    Font::~Font()
    {
    }

    void Font::Initialize(GenericFontFamily genericFamily, optional<string> familyName, double emSize, FontStyle style)
    {
        wxFontInfo fontInfo(emSize);

        if (genericFamily != GenericFontFamily::None)
            fontInfo.Family(GetWxFontFamily(genericFamily));

        if (familyName.has_value())
            fontInfo.FaceName(wxStr(familyName.value()));

        if ((style & FontStyle::Bold) != (FontStyle)0)
            fontInfo.Bold();

        if ((style & FontStyle::Italic) != (FontStyle)0)
            fontInfo.Italic();

        if ((style & FontStyle::Strikethrough) != (FontStyle)0)
            fontInfo.Strikethrough();

        if ((style & FontStyle::Underlined) != (FontStyle)0)
            fontInfo.Underlined();

        _font = wxFont(fontInfo);
    }

    void Font::InitializeWithDefaultFont()
    {
        _font = wxSystemSettings::GetFont(wxSystemFont::wxSYS_DEFAULT_GUI_FONT);
    }

    wxFont Font::GetWxFont()
    {
        return _font;
    }

    string Font::GetName()
    {
        return wxStr(_font.GetFaceName());
    }

    FontStyle Font::GetStyle()
    {
        auto style = FontStyle::Regular;
        auto wxStyle = _font.GetStyle();
        if (wxStyle & wxFontStyle::wxFONTSTYLE_ITALIC)
            style |= FontStyle::Italic;

        auto weight = _font.GetWeight();
        if (weight & wxFontWeight::wxFONTWEIGHT_BOLD)
            style |= FontStyle::Bold;

        if (_font.GetStrikethrough())
            style |= FontStyle::Strikethrough;

        if (_font.GetUnderlined())
            style |= FontStyle::Underlined;

        return style;
    }

    double Font::GetSizeInPoints()
    {
        return _font.GetFractionalPointSize();
    }

    string Font::GetDescription()
    {
        return wxStr(_font.GetNativeFontInfoUserDesc());
    }

    bool Font::IsEqualTo(Font* other)
    {
        if (other == nullptr)
            return false;
        
        return _font == other->_font;
    }

    string Font::Serialize()
    {
        return wxStr(_font.GetNativeFontInfoDesc());
    }

    /*static*/ wxFontFamily Font::GetWxFontFamily(GenericFontFamily genericFamily)
    {
        switch (genericFamily)
        {
        case GenericFontFamily::SansSerif:
            return wxFontFamily::wxFONTFAMILY_SWISS;
        case GenericFontFamily::Serif:
            return wxFontFamily::wxFONTFAMILY_ROMAN;
        case GenericFontFamily::Monospace:
            return wxFontFamily::wxFONTFAMILY_TELETYPE;
        default:
            throwExInvalidOp;
        }
    }

    /*static*/ void* Font::OpenFamiliesArray()
    {
        auto facenames = wxFontEnumerator::GetFacenames();
        return new wxArrayString(facenames.begin(), facenames.end());
    }

    /*static*/ int Font::GetFamiliesItemCount(void* array)
    {
        return ((wxArrayString*)array)->GetCount();
    }

    /*static*/ string Font::GetFamiliesItemAt(void* array, int index)
    {
        return wxStr(((wxArrayString*)array)->Item(index));
    }

    /*static*/ void Font::CloseFamiliesArray(void* array)
    {
        delete (wxArrayString*)array;
    }

    /*static*/ bool Font::IsFamilyValid(const string& fontFamily)
    {
#ifdef __WXOSX_COCOA__
        if (fontFamily == u".AppleSystemUIFont")
            return true; // the wx function will return false for this. This is a family name of the macOS system font.
#endif

        return wxFontEnumerator::IsValidFacename(wxStr(fontFamily));
    }

    /*static*/ string Font::GetGenericFamilyName(GenericFontFamily genericFamily)
    {
        if (genericFamily == GenericFontFamily::None)
            throwExInvalidArg(genericFamily, u"genericFamily cannot be None");

        wxFontInfo fontInfo;
        fontInfo.Family(GetWxFontFamily(genericFamily));
        return wxStr(wxFont(fontInfo).GetFaceName());
    }
}
