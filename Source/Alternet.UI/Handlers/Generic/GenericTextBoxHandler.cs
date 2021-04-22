using System;
using System.Drawing;

namespace Alternet.UI
{
    internal class GenericTextBoxHandler : ControlHandler<TextBox>
    {
        private Border? border;

        private TextBox? editTextBox;

        protected override void OnAttach()
        {
            base.OnAttach();

            Control.TextChanged += Control_TextChanged;

            border = new Border
            {
                Padding = new Thickness(5),
                BackgroundColor = Color.White
            };

            Control.VisualChildren.Add(border);

            editTextBox = new TextBox { EditControlOnly = true, BackgroundColor = Color.White };
            border.VisualChildren.Add(editTextBox);

            editTextBox.Text = Control.Text;
            editTextBox.TextChanged += EditTextBox_TextChanged;

            UpdateVisual();
        }

        private void EditTextBox_TextChanged(object? sender, EventArgs? e)
        {
            if (editTextBox == null)
                throw new InvalidOperationException();

            Control.Text = editTextBox.Text;
        }

        protected override void OnDetach()
        {
            base.OnDetach();

            if (border == null)
                throw new InvalidOperationException();

            if (editTextBox == null)
                throw new InvalidOperationException();

            editTextBox.TextChanged -= EditTextBox_TextChanged;

            Control.VisualChildren.Remove(border);
            Control.TextChanged -= Control_TextChanged;
        }

        protected override void OnMouseEnter()
        {
            base.OnMouseEnter();
            UpdateVisual();
        }

        protected override void OnMouseLeave()
        {
            base.OnMouseLeave();
            UpdateVisual();
        }

        protected override void OnMouseMove()
        {
            base.OnMouseMove();
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (border == null)
                throw new InvalidOperationException();

            var color = Color.FromArgb(0x92A0B5);
            if (IsMouseOver)
            {
                color = Color.FromArgb(0x5C7FB2);
            }

            border.BorderColor = color;
        }

        private void Control_TextChanged(object? sender, System.EventArgs? e)
        {
            if (e is null)
                throw new System.ArgumentNullException(nameof(e));

            if (editTextBox == null)
                throw new InvalidOperationException();

            editTextBox.Text = Control.Text;
        }
    }
}