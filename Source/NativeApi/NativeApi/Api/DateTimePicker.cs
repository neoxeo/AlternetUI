﻿#pragma warning disable
using System;
using Alternet.UI;
using ApiCommon;

namespace NativeApi.Api
{
    public class DateTimePicker : Control
    {
        public event EventHandler? ValueChanged 
        { 
            add => throw new Exception(); 
            remove => throw new Exception(); 
        }

        public Alternet.UI.DateTime Value { get; set; }
        public Alternet.UI.DateTime MinValue { get; set; }
        public Alternet.UI.DateTime MaxValue { get; set; }

        public void SetRange(bool useMinValue, bool useMaxValue)
            => throw new Exception();
        public int ValueKind { get; set; }
        public int PopupKind { get; set; }
    }
}