#include "ImageSet.h"
#include "Api/InputStream.h"
#include "ManagedInputStream.h"
#include "wx/wxprec.h"
#include "Image.h"

namespace Alternet::UI
{
	ImageSet::ImageSet()
	{
	}

	ImageSet::~ImageSet()
	{
	}

	void ImageSet::AddImage(Image* image)
	{
		if (_readOnly)
			return;
		wxIcon icon;
		icon.CopyFromBitmap(image->GetBitmap());
		_iconBundle.AddIcon(icon);
		_bitmaps.push_back(image->GetBitmap());
		InvalidateBitmapBundle();
	}

	void ImageSet::LoadFromStream(void* stream)
	{
		if (_readOnly)
			return;
		InputStream inputStream(stream);
		ManagedInputStream managedInputStream(&inputStream);

		Image::EnsureImageHandlersInitialized();

		managedInputStream.SeekI(0);
		_iconBundle.AddIcon(managedInputStream);
		managedInputStream.SeekI(0);
		_bitmaps.push_back(wxBitmap(managedInputStream));
		InvalidateBitmapBundle();
	}

	bool ImageSet::GetIsOk()
	{
		return GetBitmapBundle().IsOk();
	}

	bool ImageSet::GetIsReadOnly()
	{
		return _readOnly;
	}

	void ImageSet::Clear()
	{
		if (_readOnly || _bitmaps.empty())
			return;
		_bitmaps.clear();
		_iconBundle = wxIconBundle();
		InvalidateBitmapBundle();
	}

	void ImageSet::LoadSvgFromStream(void* stream, int width, int height)
	{
		Clear();
		_bitmapBundleValid = true;
		_readOnly = true;
		_bitmapBundle = Image::CreateFromSvgStream(stream, width, height);
	}

	wxIconBundle* ImageSet::GetIconBundle()
	{
		return &_iconBundle;
	}
	
	void ImageSet::InitImage(Image* image, int width, int height)
	{
		auto bitmapBundle = GetBitmapBundle();
		auto bitmap = bitmapBundle.GetBitmap(wxSize(width, height));
		image->_bitmap = bitmap;
	}

	wxBitmapBundle ImageSet::GetBitmapBundle()
	{
		if (!_bitmapBundleValid)
		{
			if (_readOnly)
				return _bitmapBundle;
			_bitmapBundle = wxBitmapBundle::FromBitmaps(_bitmaps);
			_bitmapBundleValid = true;
		}

		return _bitmapBundle;
	}
	
	void ImageSet::InvalidateBitmapBundle()
	{
		if (_bitmapBundleValid)
		{
			_bitmapBundle = wxBitmapBundle();
			_bitmapBundleValid = false;
		}
	}
}
