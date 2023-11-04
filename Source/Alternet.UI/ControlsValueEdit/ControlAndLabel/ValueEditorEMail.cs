﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    public class ValueEditorEMail : ValueEditorCustom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueEditorEMail"/> class.
        /// </summary>
        /// <param name="title">Label text.</param>
        /// <param name="text">Default value of the Text property.</param>
        public ValueEditorEMail(string title, string? text = default)
                    : base(title, text)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueEditorEMail"/> class.
        /// </summary>
        public ValueEditorEMail()
            : base()
        {
        }

        /// <inheritdoc/>
        protected override void Init()
        {
            base.Init();
            TextBox.SetErrorText(ValueValidatorKnownError.EMailIsExpected);
            TextBox.TextChanged += TextBox_TextChanged;
            TextBox.Options &= ~TextBoxOptions.DefaultValidation;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox.ReportErrorEmptyText())
                return;

            var text = TextBox.Text;

            if (string.IsNullOrEmpty(text) || ValueValidatorFactory.IsValidMailAddress(text))
                TextBox.ReportValidatorError(false);
            else
                TextBox.ReportValidatorError(true);
        }
    }
}