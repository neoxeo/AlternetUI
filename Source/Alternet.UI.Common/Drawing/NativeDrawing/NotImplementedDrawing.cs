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

        public override object CreateFont(object font) => NotImplemented();

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

        public override void UpdateFont(object font, FontParams prm) => NotImplemented();

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

        public override string GetFontName(object font) => NotImplemented<string>();

        public override int GetFontEncoding(object font) => NotImplemented<int>();

        public override SizeI GetFontSizeInPixels(object font) => NotImplemented<SizeI>();

        public override bool GetFontIsUsingSizeInPixels(object font) => NotImplemented<bool>();

        public override int GetFontNumericWeight(object font) => NotImplemented<int>();

        public override bool GetFontIsFixedWidth(object font) => NotImplemented<bool>();

        public override FontWeight GetFontWeight(object font) => NotImplemented<FontWeight>();

        public override FontStyle GetFontStyle(object font) => NotImplemented<FontStyle>();

        public override bool GetFontStrikethrough(object font) => NotImplemented<bool>();

        public override bool GetFontUnderlined(object font) => NotImplemented<bool>();

        public override double GetFontSizeInPoints(object font) => NotImplemented<double>();

        public override string GetFontInfoDesc(object font) => NotImplemented<string>();

        public override bool FontEquals(object font1, object font2) => NotImplemented<bool>();

        public override string FontToString(object font) => NotImplemented<string>();

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

        public override bool ImageSave(object image, string fileName)
        {
            throw new NotImplementedException();
        }

        public override bool ImageSave(object image, Stream stream, ImageFormat format)
        {
            throw new NotImplementedException();
        }

        public override SizeI GetImagePixelSize(object image)
        {
            throw new NotImplementedException();
        }

        public override bool ImageLoadFromStream(object image, Stream stream)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromImage(object original, SizeI newSize)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromGenericImage(object genericImage, int depth = -1)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromGraphics(int width, int height, object dc)
        {
            throw new NotImplementedException();
        }

        public override object CreateImageFromGraphicsAndGenericImage(object genericImage, object dc)
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

        public override bool GetImageHasAlpha(object image)
        {
            throw new NotImplementedException();
        }

        public override void SetImageHasAlpha(object image, bool hasAlpha)
        {
            throw new NotImplementedException();
        }

        public override double GetImageScaleFactor(object image)
        {
            throw new NotImplementedException();
        }

        public override void SetImageScaleFactor(object image, double value)
        {
            throw new NotImplementedException();
        }

        public override SizeI GetImageDipSize(object image)
        {
            throw new NotImplementedException();
        }

        public override double GetImageScaledHeight(object image)
        {
            throw new NotImplementedException();
        }

        public override SizeI GetImageScaledSize(object image)
        {
            throw new NotImplementedException();
        }

        public override double GetImageScaledWidth(object image)
        {
            throw new NotImplementedException();
        }

        public override int GetImageDepth(object image)
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

        public override bool ImageLoad(object image, string name, BitmapType type)
        {
            throw new NotImplementedException();
        }

        public override bool ImageSaveToFile(object image, string name, BitmapType type)
        {
            throw new NotImplementedException();
        }

        public override bool ImageSaveToStream(object image, Stream stream, BitmapType type)
        {
            throw new NotImplementedException();
        }

        public override bool ImageLoadFromStream(object image, Stream stream, BitmapType type)
        {
            throw new NotImplementedException();
        }

        public override object ImageGetSubBitmap(object image, RectI rect)
        {
            throw new NotImplementedException();
        }

        public override object ImageConvertToDisabled(object image, byte brightness = 255)
        {
            throw new NotImplementedException();
        }

        public override void ImageRescale(object image, SizeI sizeNeeded)
        {
            throw new NotImplementedException();
        }

        public override void ImageResetAlpha(object image)
        {
            throw new NotImplementedException();
        }

        public override bool GetImageIsOk(object image)
        {
            throw new NotImplementedException();
        }
    }
}