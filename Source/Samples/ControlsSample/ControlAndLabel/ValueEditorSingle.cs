﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    public class ValueEditorSingle : ValueEditorCustom
    {
        public ValueEditorSingle(string title, string? text = default)
                    : base(title, text)
        {
        }

        public ValueEditorSingle()
            : base()
        {
        }

        protected override void Init()
        {
            base.Init();
            TextBox.UseValidator<float>();
            TextBox.SetErrorText(ValueValidatorKnownError.FloatIsExpected);
        }
    }
}
