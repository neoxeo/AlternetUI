﻿using System;

namespace NativeApi.Api
{
    public class Toolbar : Control
    {
        public int ItemsCount { get; }

        public void InsertItemAt(int index, ToolbarItem item) => throw new Exception();

        public void RemoveItemAt(int index) => throw new Exception();
    }
}