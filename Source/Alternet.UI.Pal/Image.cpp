#include "Image.h"

namespace Alternet::UI
{
    Image::Image()
    {
    }

    Image::~Image()
    {
    }

    void Image::LoadFromStream(void* stream)
    {
        InputStream inputStream(stream);
        ManagedInputStream managedInputStream(&inputStream);

        static bool imageHandlersInitialized = false;
        if (!imageHandlersInitialized)
        {
            wxInitAllImageHandlers();
            imageHandlersInitialized = true;
        }

        _image = wxImage(managedInputStream);
    }

    void Image::Initialize(const Size& size)
    {
        _image = wxImage(fromDip(size, nullptr));
    }

    wxImage Image::GetImage()
    {
        return _image;
    }
    
    Size Image::GetSize()
    {
        return toDip(_image.GetSize(), nullptr);
    }
    
    Int32Size Image::GetPixelSize()
    {
        return _image.GetSize();
    }
}