﻿
using ApiCommon;
using System;

namespace NativeApi.Api
{
    public class TextInputEventData : NativeEventData
    {
        public char keyChar;
        public long timestamp;
    }
}