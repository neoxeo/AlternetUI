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
        public override object CreateFont() => NotImplemented();

        public override object CreateDefaultFont() => NotImplemented();

        public override Font CreateSystemFont(SystemSettingsFont systemFont) => NotImplemented<Font>();

        public override object CreateFont(Font font) => NotImplemented();

        public override object CreateDefaultMonoFont() => NotImplemented();

        public override object CreatePen() => NotImplemented();

        public override object CreateTransparentBrush() => NotImplemented();

        public override object CreateHatchBrush() => NotImplemented();

        public override object CreateLinearGradientBrush() => NotImplemented();

        public override object CreateRadialGradientBrush() => NotImplemented();

        public override object CreateSolidBrush() => NotImplemented();

        public override object CreateTextureBrush() => NotImplemented();

        public override void UpdatePen(Pen pen) => NotImplemented();

        public override void UpdateSolidBrush(SolidBrush brush) => NotImplemented();

        public override void UpdateFont(Font font, FontParams prm) => NotImplemented();

        public override void UpdateHatchBrush(HatchBrush brush) => NotImplemented();

        public override void UpdateLinearGradientBrush(LinearGradientBrush brush) => NotImplemented();

        public override void UpdateRadialGradientBrush(RadialGradientBrush brush) => NotImplemented();

        public override Color GetColor(SystemSettingsColor index) => NotImplemented<Color>();

        public override string[] GetFontFamiliesNames() => NotImplemented<string[]>();

        public override bool IsFontFamilyValid(string name) => NotImplemented<bool>();

        public override string GetFontFamilyName(GenericFontFamily genericFamily)
             => NotImplemented<string>();

        public override int GetDefaultFontEncoding() => NotImplemented<int>();

        public override void SetDefaultFontEncoding(int value) => NotImplemented();

        public override string GetFontName(Font font) => NotImplemented<string>();

        public override int GetFontEncoding(Font font) => NotImplemented<int>();

        public override SizeI GetFontSizeInPixels(Font font) => NotImplemented<SizeI>();

        public override bool GetFontIsUsingSizeInPixels(Font font) => NotImplemented<bool>();

        public override int GetFontNumericWeight(Font font) => NotImplemented<int>();

        public override bool GetFontIsFixedWidth(Font font) => NotImplemented<bool>();

        public override FontWeight GetFontWeight(Font font) => NotImplemented<FontWeight>();

        public override FontStyle GetFontStyle(Font font) => NotImplemented<FontStyle>();

        public override bool GetFontStrikethrough(Font font) => NotImplemented<bool>();

        public override bool GetFontUnderlined(Font font) => NotImplemented<bool>();

        public override double GetFontSizeInPoints(Font font) => NotImplemented<double>();

        public override string GetFontInfoDesc(Font font) => NotImplemented<string>();

        public override bool FontEquals(Font font1, Font font2) => NotImplemented<bool>();

        public override string FontToString(Font font) => NotImplemented<string>();

        public override void UpdateTransformMatrix(object matrix, double m11, double m12, double m21, double m22, double dx, double dy)
        {
            throw new NotImplementedException();
        }

        public override double GetTransformMatrixM11(object matrix)
        {
            throw new NotImplementedException();
        }

        public override double GetTransformMatrixM12(object matrix)
        {
            throw new NotImplementedException();
        }

        public override double GetTransformMatrixM21(object matrix)
        {
            throw new NotImplementedException();
        }

        public override double GetTransformMatrixM22(object matrix)
        {
            throw new NotImplementedException();
        }

        public override double GetTransformMatrixDX(object matrix)
        {
            throw new NotImplementedException();
        }

        public override double GetTransformMatrixDY(object matrix)
        {
            throw new NotImplementedException();
        }

        public override bool GetTransformMatrixIsIdentity(object matrix)
        {
            throw new NotImplementedException();
        }

        public override void ResetTransformMatrix(object matrix)
        {
            throw new NotImplementedException();
        }

        public override void MultiplyTransformMatrix(object matrix1, object matrix2)
        {
            throw new NotImplementedException();
        }

        public override void TranslateTransformMatrix(object matrix, double offsetX, double offsetY)
        {
            throw new NotImplementedException();
        }

        public override void ScaleTransformMatrix(object matrix, double scaleX, double scaleY)
        {
            throw new NotImplementedException();
        }

        public override void RotateTransformMatrix(object matrix, double angle)
        {
            throw new NotImplementedException();
        }

        public override void InvertTransformMatrix(object matrix)
        {
            throw new NotImplementedException();
        }

        public override void SetTransformMatrixM11(object matrix, double value)
        {
            throw new NotImplementedException();
        }

        public override void SetTransformMatrixM12(object matrix, double value)
        {
            throw new NotImplementedException();
        }

        public override void SetTransformMatrixM21(object matrix, double value)
        {
            throw new NotImplementedException();
        }

        public override void SetTransformMatrixM22(object matrix, double value)
        {
            throw new NotImplementedException();
        }

        public override void SetTransformMatrixDX(object matrix, double value)
        {
            throw new NotImplementedException();
        }

        public override void SetTransformMatrixDY(object matrix, double value)
        {
            throw new NotImplementedException();
        }

        public override PointD TransformMatrixOnPoint(object matrix, PointD point)
        {
            throw new NotImplementedException();
        }

        public override SizeD TransformMatrixOnSize(object matrix, SizeD size)
        {
            throw new NotImplementedException();
        }

        public override bool TransformMatrixEquals(object matrix1, object matrix2)
        {
            throw new NotImplementedException();
        }

        public override int TransformMatrixGetHashCode(object matrix)
        {
            throw new NotImplementedException();
        }

        public override object CreateTransformMatrix()
        {
            throw new NotImplementedException();
        }

        public override object CreateImage()
        {
            throw new NotImplementedException();
        }

        public override bool ImageSave(Image img, string fileName)
        {
            throw new NotImplementedException();
        }

        public override bool ImageSave(Image img, Stream stream, ImageFormat format)
        {
            throw new NotImplementedException();
        }

        public override SizeI GetImagePixelSize(Image img)
        {
            throw new NotImplementedException();
        }

        public override bool ImageLoadFromStream(Image img, Stream stream)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromImage(Image original, SizeI newSize)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromGenericImage(GenericImage genericImage, int depth = -1)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromGraphics(int width, int height, Graphics dc)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromGraphicsAndGenericImage(GenericImage genericImage, Graphics dc)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageWithSizeAndDepth(SizeI size, int depth = 32)
        {
            throw new NotImplementedException();
        }

        public override BitmapType GetDefaultBitmapType()
        {
            throw new NotImplementedException();
        }

        public override bool GetImageHasAlpha(Image img)
        {
            throw new NotImplementedException();
        }

        public override void SetImageHasAlpha(Image img, bool hasAlpha)
        {
            throw new NotImplementedException();
        }

        public override double GetImageScaleFactor(Image img)
        {
            throw new NotImplementedException();
        }

        public override void SetImageScaleFactor(Image img, double value)
        {
            throw new NotImplementedException();
        }

        public override SizeI GetImageDipSize(Image img)
        {
            throw new NotImplementedException();
        }

        public override double GetImageScaledHeight(Image img)
        {
            throw new NotImplementedException();
        }

        public override SizeI GetImageScaledSize(Image img)
        {
            throw new NotImplementedException();
        }

        public override double GetImageScaledWidth(Image img)
        {
            throw new NotImplementedException();
        }

        public override int GetImageDepth(Image img)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromScreen()
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromSvgStream(Stream stream, int width, int height, Color? color = null)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromSvgString(string s, int width, int height, Color? color = null)
        {
            throw new NotImplementedException();
        }

        public override bool ImageLoad(Image img, string name, BitmapType type)
        {
            throw new NotImplementedException();
        }

        public override bool ImageSaveToFile(Image img, string name, BitmapType type)
        {
            throw new NotImplementedException();
        }

        public override bool ImageSaveToStream(Image img, Stream stream, BitmapType type)
        {
            throw new NotImplementedException();
        }

        public override bool ImageLoadFromStream(Image img, Stream stream, BitmapType type)
        {
            throw new NotImplementedException();
        }

        public override object ImageGetSubBitmap(Image img, RectI rect)
        {
            throw new NotImplementedException();
        }

        public override object ImageConvertToDisabled(Image img, byte brightness = 255)
        {
            throw new NotImplementedException();
        }

        public override void ImageRescale(Image img, SizeI sizeNeeded)
        {
            throw new NotImplementedException();
        }

        public override void ImageResetAlpha(Image img)
        {
            throw new NotImplementedException();
        }

        public override bool GetImageIsOk(Image img)
        {
            throw new NotImplementedException();
        }

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

        public override FillMode GraphicsPathGetFillMode(object graphicsPath)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathSetFillMode(object graphicsPath, FillMode value)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathAddLines(object graphicsPath, PointD[] points)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathAddLine(object graphicsPath, PointD pt1, PointD pt2)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathAddLineTo(object graphicsPath, PointD pt)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathAddEllipse(object graphicsPath, RectD rect)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathAddBezier(object graphicsPath, PointD startPoint, PointD controlPoint1, PointD controlPoint2, PointD endPoint)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathAddBezierTo(object graphicsPath, PointD controlPoint1, PointD controlPoint2, PointD endPoint)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathAddArc(object graphicsPath, PointD center, double radius, double startAngle, double sweepAngle)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathAddRectangle(object graphicsPath, RectD rect)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathAddRoundedRectangle(object graphicsPath, RectD rect, double cornerRadius)
        {
            throw new NotImplementedException();
        }

        public override RectD GraphicsPathGetBounds(object graphicsPath)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathStartFigure(object graphicsPath, PointD point)
        {
            throw new NotImplementedException();
        }

        public override void GraphicsPathCloseFigure(object graphicsPath)
        {
            throw new NotImplementedException();
        }

        public override object CreateGraphicsPath()
        {
            throw new NotImplementedException();
        }

        public override object CreateRegion()
        {
            throw new NotImplementedException();
        }

        public override object CreateRegion(RectD rect)
        {
            throw new NotImplementedException();
        }

        public override object CreateRegion(object region)
        {
            throw new NotImplementedException();
        }

        public override object CreateRegion(PointD[] points, FillMode fillMode = FillMode.Alternate)
        {
            throw new NotImplementedException();
        }

        public override bool RegionIsEmpty(object nativeRegion)
        {
            throw new NotImplementedException();
        }

        public override bool RegionIsOk(object nativeRegion)
        {
            throw new NotImplementedException();
        }

        public override void RegionClear(object nativeRegion)
        {
            throw new NotImplementedException();
        }

        public override RegionContain RegionContains(object nativeRegion, PointD pt)
        {
            throw new NotImplementedException();
        }

        public override RegionContain RegionContains(object nativeRegion, RectD rect)
        {
            throw new NotImplementedException();
        }

        public override void RegionIntersect(object nativeRegion, RectD rect)
        {
            throw new NotImplementedException();
        }

        public override void RegionIntersect(object nativeRegion1, object nativeRegion2)
        {
            throw new NotImplementedException();
        }

        public override void RegionUnion(object nativeRegion, RectD rect)
        {
            throw new NotImplementedException();
        }

        public override void RegionUnion(object nativeRegion1, object nativeRegion2)
        {
            throw new NotImplementedException();
        }

        public override void RegionXor(object nativeRegion1, object nativeRegion2)
        {
            throw new NotImplementedException();
        }

        public override void RegionXor(object nativeRegion, RectD rect)
        {
            throw new NotImplementedException();
        }

        public override void RegionSubtract(object nativeRegion, RectD rect)
        {
            throw new NotImplementedException();
        }

        public override void RegionSubtract(object nativeRegion1, object nativeRegion2)
        {
            throw new NotImplementedException();
        }

        public override void RegionTranslate(object nativeRegion, double dx, double dy)
        {
            throw new NotImplementedException();
        }

        public override RectD RegionGetBounds(object nativeRegion)
        {
            throw new NotImplementedException();
        }

        public override bool RegionEquals(object nativeRegion1, object nativeRegion2)
        {
            throw new NotImplementedException();
        }

        public override int RegionGetHashCode(object nativeRegion)
        {
            throw new NotImplementedException();
        }

        public override object ImageConvertToGenericImage(Image image)
        {
            throw new NotImplementedException();
        }

        public override void UpdateTextureBrush(TextureBrush brush)
        {
            throw new NotImplementedException();
        }

        public override object CreateGraphicsPath(object nativeGraphics)
        {
            throw new NotImplementedException();
        }

        public override SizeI ImageListGetPixelImageSize(ImageList imageList)
        {
            throw new NotImplementedException();
        }

        public override void ImageListSetPixelImageSize(ImageList imageList, SizeI value)
        {
            throw new NotImplementedException();
        }

        public override SizeD ImageListGetImageSize(ImageList imageList)
        {
            throw new NotImplementedException();
        }

        public override void ImageListSetImageSize(ImageList imageList, SizeD value)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageList()
        {
            throw new NotImplementedException();
        }

        public override void ImageListAdd(ImageList imageList, int index, Image item)
        {
            throw new NotImplementedException();
        }

        public override void ImageListRemove(ImageList imageList, int index, Image item)
        {
            throw new NotImplementedException();
        }

        public override void IconSetAdd(IconSet iconSet, Image image)
        {
            throw new NotImplementedException();
        }

        public override void IconSetAdd(IconSet iconSet, Stream stream)
        {
            throw new NotImplementedException();
        }

        public override void IconSetClear(IconSet iconSet)
        {
            throw new NotImplementedException();
        }

        public override object CreateIconSet()
        {
            throw new NotImplementedException();
        }

        public override bool IconSetIsOk(IconSet iconSet)
        {
            throw new NotImplementedException();
        }

        public override SizeI ImageSetGetPreferredBitmapSizeAtScale(ImageSet imageSet, double scale)
        {
            throw new NotImplementedException();
        }

        public override void ImageSetAddImage(ImageSet imageSet, int index, Image item)
        {
            throw new NotImplementedException();
        }

        public override void ImageSetRemoveImage(ImageSet imageSet, int index, Image item)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageSet()
        {
            throw new NotImplementedException();
        }

        public override object CreateImageSetFromSvgStream(Stream stream, int width, int height, Color? color = null)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageSetFromSvgString(string s, int width, int height, Color? color = null)
        {
            throw new NotImplementedException();
        }

        public override SizeI ImageSetGetDefaultSize(ImageSet imageSet)
        {
            throw new NotImplementedException();
        }

        public override bool ImageSetIsOk(ImageSet imageSet)
        {
            throw new NotImplementedException();
        }

        public override bool ImageSetIsReadOnly(ImageSet imageSet)
        {
            throw new NotImplementedException();
        }

        public override void ImageSetLoadFromStream(ImageSet imageSet, Stream stream)
        {
            throw new NotImplementedException();
        }

        public override object CreateImage(ImageSet imageSet, SizeI size)
        {
            throw new NotImplementedException();
        }

        public override object CreateCaret()
        {
            throw new NotImplementedException();
        }

        public override object CreateCaret(IControl control, int width, int height)
        {
            throw new NotImplementedException();
        }

        public override int CaretGetBlinkTime()
        {
            throw new NotImplementedException();
        }

        public override void CaretSetBlinkTime(int value)
        {
            throw new NotImplementedException();
        }

        public override SizeI CaretGetSize(Caret caret)
        {
            throw new NotImplementedException();
        }

        public override void CaretSetSize(Caret caret, SizeI value)
        {
            throw new NotImplementedException();
        }

        public override PointI CaretGetPosition(Caret caret)
        {
            throw new NotImplementedException();
        }

        public override void CaretSetPosition(Caret caret, PointI value)
        {
            throw new NotImplementedException();
        }

        public override bool CaretIsOk(Caret caret)
        {
            throw new NotImplementedException();
        }

        public override bool CaretGetVisible(Caret caret)
        {
            throw new NotImplementedException();
        }

        public override void CaretSetVisible(Caret caret, bool value)
        {
            throw new NotImplementedException();
        }

        public override void DisposeCaret(Caret caret)
        {
            throw new NotImplementedException();
        }

        public override Graphics CreateGraphicsFromScreen()
        {
            throw new NotImplementedException();
        }

        public override Graphics CreateGraphicsFromImage(Image image)
        {
            throw new NotImplementedException();
        }

        public override object CreateCursor()
        {
            throw new NotImplementedException();
        }

        public override object CreateCursor(CursorType cursor)
        {
            throw new NotImplementedException();
        }

        public override object CreateCursor(string cursorName, BitmapType type, int hotSpotX = 0, int hotSpotY = 0)
        {
            throw new NotImplementedException();
        }

        public override object CreateCursor(Image image)
        {
            throw new NotImplementedException();
        }

        public override bool CursorIsOk(Cursor cursor)
        {
            throw new NotImplementedException();
        }

        public override PointI CursorGetHotSpot(Cursor cursor)
        {
            throw new NotImplementedException();
        }

        public override void CursorSetGlobal(Cursor? cursor)
        {
            throw new NotImplementedException();
        }

        public override void DisposeCursor(Cursor cursor)
        {
            throw new NotImplementedException();
        }

        public override object CreateDisplay()
        {
            throw new NotImplementedException();
        }

        public override object CreateDisplay(int index)
        {
            throw new NotImplementedException();
        }

        public override int DisplayGetCount()
        {
            throw new NotImplementedException();
        }

        public override int DisplayGetDefaultDPIValue()
        {
            throw new NotImplementedException();
        }

        public override SizeI DisplayGetDefaultDPI()
        {
            throw new NotImplementedException();
        }

        public override string DisplayGetName(Display display)
        {
            throw new NotImplementedException();
        }

        public override SizeI DisplayGetDPI(Display display)
        {
            throw new NotImplementedException();
        }

        public override double DisplayGetScaleFactor(Display display)
        {
            throw new NotImplementedException();
        }

        public override bool DisplayGetIsPrimary(Display display)
        {
            throw new NotImplementedException();
        }

        public override RectI DisplayGetClientArea(Display display)
        {
            throw new NotImplementedException();
        }

        public override RectI DisplayGetGeometry(Display display)
        {
            throw new NotImplementedException();
        }

        public override int DisplayGetFromPoint(PointI pt)
        {
            throw new NotImplementedException();
        }

        public override void DisposeDisplay(Display display)
        {
            throw new NotImplementedException();
        }

        public override int DisplayGetFromControl(IControl control)
        {
            throw new NotImplementedException();
        }

        public override object CreateImage(ImageSet imageSet, IControl control)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromImage(Image image)
        {
            throw new NotImplementedException();
        }

        public override void SetDefaultFont(Font value)
        {
            throw new NotImplementedException();
        }
    }
}