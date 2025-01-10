#include "Clipboard.h"

namespace Alternet::UI
{
    Clipboard::Clipboard()
    {
    }
    
    Clipboard::~Clipboard()
    {
    }
    
    UnmanagedDataObject* Clipboard::GetDataObject()
    {
        wxClipboardLocker clipboardLocker;
        if (!clipboardLocker)
            return nullptr;

        auto compositeDataObject = GetCompositeDataObjectFromClipboard();
        if (compositeDataObject->GetFormatCount() == 0)
        {
            delete compositeDataObject;
            return nullptr;
        }

        return new UnmanagedDataObject(compositeDataObject);
    }

    void Clipboard::SetDataObject(UnmanagedDataObject* value)
    {
        wxClipboardLocker clipboardLocker;
        if (!clipboardLocker)
            return;

        if (value == nullptr)
        {
            wxTheClipboard->Clear();
            return;
        }

        wxDataObjectComposite* composite = value->GetDataObjectComposite();

        if (composite->GetFormatCount() == 0)
        {
            wxTheClipboard->Clear();
            return;
        }
        
        wxTheClipboard->AddData(composite);

        /*
        auto bitmapDataObject = UnmanagedDataObject::TryGetBitmapDataObject(composite);

        if (bitmapDataObject != nullptr)
        {
            // Workaround: wxWidgets does not support Composite Data Objects which
            // contain bitmap objects.
            wxTheClipboard->SetData(bitmapDataObject);
        }
        else
        {
            wxTheClipboard->AddData(composite);
        }*/
    }

    optional<string> Clipboard::TryGetText()
    {
        wxTextDataObject data;
        if (!wxTheClipboard->GetData(data))
            return nullopt;

        return wxStr(data.GetText());
    }

    optional<string> Clipboard::TryGetFiles()
    {
        return optional<string>();
    }

    optional<wxBitmap> Clipboard::TryGetBitmap()
    {
        return optional<wxBitmap>();
    }

    wxDataObjectComposite* Clipboard::GetCompositeDataObjectFromClipboard()
    {
        auto result = new wxDataObjectComposite();

        auto textData = new wxTextDataObject();
        if (wxTheClipboard->GetData(*textData))
            result->Add(textData);
        else
            delete textData;

        auto fileData = new wxFileDataObject();
        if (wxTheClipboard->GetData(*fileData))
            result->Add(fileData);
        else
            delete fileData;

        auto bitmapData = new wxBitmapDataObject();
        if (wxTheClipboard->GetData(*bitmapData))
            result->Add(bitmapData);
        else
            delete bitmapData;

        return result;
    }
}
