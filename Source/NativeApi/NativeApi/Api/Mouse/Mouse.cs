﻿using System;
using System.ComponentModel;
using Alternet.Drawing;
using ApiCommon;

namespace NativeApi.Api
{
    public class Mouse
    {
        public event NativeEventHandler<MouseEventData>? MouseMove { add => throw new Exception(); remove => throw new Exception(); }

        public Point GetPosition() => throw new Exception();

        public MouseButtonState GetButtonState(MouseButton button) => throw new Exception();
    }
}