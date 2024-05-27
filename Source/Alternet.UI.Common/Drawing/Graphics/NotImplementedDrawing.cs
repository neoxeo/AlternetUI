﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alternet.UI;

namespace Alternet.Drawing
{
    /// <summary>
    /// Overrides <see cref="AbstractDrawing"/> methods throwing
    /// <see cref="NotImplementedException"/>.
    /// </summary>
    internal class NotImplementedDrawing : NativeDrawing
    {
        public override object CreateGenericImage()
        {
            throw new NotImplementedException();
        }

        public override object CreateGenericImage(int width, int height, bool clear = false)
        {
            throw new NotImplementedException();
        }

        public override object CreateGenericImage(SizeI size, bool clear = false)
        {
            throw new NotImplementedException();
        }

        public override object CreateGenericImage(string fileName, BitmapType bitmapType = BitmapType.Any, int index = -1)
        {
            throw new NotImplementedException();
        }

        public override object CreateGenericImage(string name, string mimetype, int index = -1)
        {
            throw new NotImplementedException();
        }

        public override object CreateGenericImage(Stream stream, BitmapType bitmapType = BitmapType.Any, int index = -1)
        {
            throw new NotImplementedException();
        }

        public override object CreateGenericImage(Stream stream, string mimeType, int index = -1)
        {
            throw new NotImplementedException();
        }

        public override object CreateGenericImage(int width, int height, IntPtr data, bool staticData = false)
        {
            throw new NotImplementedException();
        }

        public override object CreateGenericImage(int width, int height, IntPtr data, IntPtr alpha, bool staticData = false)
        {
            throw new NotImplementedException();
        }

        public override int GetGenericImageWidth(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override int GetGenericImageHeight(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override bool GetGenericImageIsOk(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageCanRead(string filename)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageCanRead(Stream stream)
        {
            throw new NotImplementedException();
        }

        public override string GetGenericImageExtWildcard()
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageRemoveHandler(string name)
        {
            throw new NotImplementedException();
        }

        public override int GetGenericImageCount(string filename, BitmapType bitmapType = BitmapType.Any)
        {
            throw new NotImplementedException();
        }

        public override int GetGenericImageCount(Stream stream, BitmapType bitmapType = BitmapType.Any)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageCleanUpHandlers()
        {
            throw new NotImplementedException();
        }

        public override GenericImageLoadFlags GetGenericImageDefaultLoadFlags()
        {
            throw new NotImplementedException();
        }

        public override void SetGenericImageDefaultLoadFlags(GenericImageLoadFlags flags)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetAlpha(GenericImage img, int x, int y, byte alpha)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageClearAlpha(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetMask(GenericImage img, bool hasMask = true)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetMaskColor(GenericImage img, RGBValue rgb)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageSetMaskFromImage(GenericImage img1, GenericImage img2, RGBValue mask)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetOptionAsString(GenericImage img, string name, string value)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetOptionAsInt(GenericImage img, string name, int value)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetRGB(GenericImage img, int x, int y, RGBValue rgb)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetRGBRect(GenericImage img, RGBValue rgb, RectI? rect = null)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetImageType(GenericImage img, BitmapType type)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageCopy(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageReset(GenericImage img, int width, int height, bool clear = false)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageClear(GenericImage img, byte value = 0)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageReset(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override Color GenericImageFindFirstUnusedColor(GenericImage img, RGBValue? startRGB = null)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageInitAlpha(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageBlur(GenericImage img, int blurRadius)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageBlurHorizontal(GenericImage img, int blurRadius)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageBlurVertical(GenericImage img, int blurRadius)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageMirror(GenericImage img, bool horizontally = true)
        {
            throw new NotImplementedException();
        }

        public override void GenericImagePaste(GenericImage img1, GenericImage img2, int x, int y, GenericImageAlphaBlendMode alphaBlend = GenericImageAlphaBlendMode.Overwrite)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageReplace(GenericImage img, RGBValue r1, RGBValue r2)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageRescale(GenericImage img, int width, int height, GenericImageResizeQuality quality = GenericImageResizeQuality.Nearest)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageResizeNoScale(GenericImage img, SizeI size, PointI pos, RGBValue? color = null)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageSizeNoScale(GenericImage img, SizeI size, PointI pos = default, RGBValue? color = null)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageRotate90(GenericImage img, bool clockwise = true)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageRotate180(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageRotateHue(GenericImage img, double angle)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageChangeSaturation(GenericImage img, double factor)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageChangeBrightness(GenericImage img, double factor)
        {
            throw new NotImplementedException();
        }

        public override GenericImageLoadFlags GenericImageGetLoadFlags(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetLoadFlags(GenericImage img, GenericImageLoadFlags flags)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageChangeHSV(GenericImage img, double angleH, double factorS, double factorV)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageScale(GenericImage img, int width, int height, GenericImageResizeQuality quality = GenericImageResizeQuality.Nearest)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageConvertAlphaToMask(GenericImage img, byte threshold)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageConvertAlphaToMask(GenericImage img, RGBValue rgb, byte threshold)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageConvertToGreyscale(GenericImage img, double weightR, double weightG, double weightB)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageConvertToGreyscale(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageConvertToMono(GenericImage img, RGBValue rgb)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageConvertToDisabled(GenericImage img, byte brightness = 255)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageChangeLightness(GenericImage img, int ialpha)
        {
            throw new NotImplementedException();
        }

        public override byte GenericImageGetAlpha(GenericImage img, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override RGBValue GenericImageGetRGB(GenericImage img, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Color GenericImageGetPixel(GenericImage img, int x, int y, bool withAlpha = false)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetPixel(GenericImage img, int x, int y, Color color, bool withAlpha = false)
        {
            throw new NotImplementedException();
        }

        public override byte GenericImageGetRed(GenericImage img, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override byte GenericImageGetGreen(GenericImage img, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override byte GenericImageGetBlue(GenericImage img, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override RGBValue GenericImageGetMaskRGB(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override byte GenericImageGetMaskRed(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override byte GenericImageGetMaskGreen(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override byte GenericImageGetMaskBlue(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override string GenericImageGetOptionAsString(GenericImage img, string name)
        {
            throw new NotImplementedException();
        }

        public override int GenericImageGetOptionAsInt(GenericImage img, string name)
        {
            throw new NotImplementedException();
        }

        public override GenericImage GenericImageGetSubImage(GenericImage img, RectI rect)
        {
            throw new NotImplementedException();
        }

        public override void DisposeGenericImage(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override BitmapType GenericImageGetImageType(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageHasAlpha(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageHasMask(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageHasOption(GenericImage img, string name)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageIsTransparent(GenericImage img, int x, int y, byte threshold)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageLoadFromStream(GenericImage img, Stream stream, BitmapType bitmapType = BitmapType.Any, int index = -1)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageLoadFromFile(GenericImage img, string filename, BitmapType bitmapType = BitmapType.Any, int index = -1)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageLoadFromFile(GenericImage img, string name, string mimetype, int index = -1)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageLoadFromStream(GenericImage img, Stream stream, string mimetype, int index = -1)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageSaveToStream(GenericImage img, Stream stream, string mimetype)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageSaveToFile(GenericImage img, string filename, BitmapType bitmapType)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageSaveToFile(GenericImage img, string filename, string mimetype)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageSaveToFile(GenericImage img, string filename)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageSaveToStream(GenericImage img, Stream stream, BitmapType type)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetNativeData(GenericImage img, IntPtr data, int new_width, int new_height, bool static_data = false)
        {
            throw new NotImplementedException();
        }

        public override IntPtr GenericImageGetNativeAlphaData(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override IntPtr GenericImageGetNativeData(GenericImage img)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageCreateNativeData(GenericImage img, int width, int height, IntPtr data, bool staticData = false)
        {
            throw new NotImplementedException();
        }

        public override bool GenericImageCreateNativeData(GenericImage img, int width, int height, IntPtr data, IntPtr alpha, bool staticData = false)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetNativeAlphaData(GenericImage img, IntPtr alpha = default, bool staticData = false)
        {
            throw new NotImplementedException();
        }

        public override void GenericImageSetNativeData(GenericImage img, IntPtr data, bool staticData = false)
        {
            throw new NotImplementedException();
        }
    }
}