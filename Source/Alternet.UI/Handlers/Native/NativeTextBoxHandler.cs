using System;
using System.Runtime.InteropServices;

namespace Alternet.UI
{
    internal class NativeTextBoxHandler : NativeControlHandler<TextBox, Native.TextBox>
    {
        private bool handlingNativeControlTextChanged;

        public bool HasSelection
        {
            get
            {
                return NativeControl.HasSelection;
            }
        }

        public bool IsModified
        {
            get
            {
                return NativeControl.IsModified;
            }

            set
            {
                NativeControl.IsModified = value;
            }
        }

        public bool CanCopy
        {
            get
            {
                return NativeControl.CanCopy;
            }
        }

        public bool CanCut
        {
            get
            {
                return NativeControl.CanCut;
            }
        }

        public bool CanPaste
        {
            get
            {
                return NativeControl.CanPaste;
            }
        }

        public bool CanRedo
        {
            get
            {
                return NativeControl.CanRedo;
            }
        }

        public bool CanUndo
        {
            get
            {
                return NativeControl.CanUndo;
            }

        }
        public bool IsEmpty
        {
            get
            {
                return NativeControl.IsEmpty;
            }
        }

        public string EmptyTextHint
        {
            get
            {
                return NativeControl.EmptyTextHint;
            }

            set
            {
                NativeControl.EmptyTextHint = value;
            }
        }

        public bool IsRichEdit
        {
            get
            {
                return NativeControl.IsRichEdit;
            }

            set
            {
                NativeControl.IsRichEdit = value;
            }
        }

        public int GetLineLength(long lineNo)
        {
            return NativeControl.GetLineLength(lineNo);
        }

        public string GetLineText(long lineNo)
        {
            return NativeControl.GetLineText(lineNo);
        }

        public int GetNumberOfLines()
        {
            return NativeControl.GetNumberOfLines();
        }

        public Alternet.Drawing.Point PositionToXY(long pos)
        {
            return NativeControl.PositionToXY(pos);
        }

        public Alternet.Drawing.Point PositionToCoords(long pos)
        {
            return NativeControl.PositionToCoords(pos);
        }

        public void ShowPosition(long pos)
        {
            NativeControl.ShowPosition(pos);
        }

        public long XYToPosition(long x, long y)
        {
            return NativeControl.XYToPosition(x, y);
        }

        public System.IntPtr GetDefaultStyle()
        {
            return NativeControl.GetDefaultStyle();
        }

        public IntPtr GetStyle(long position)
        {
            return NativeControl.GetStyle(position);
        }

        public bool SetDefaultStyle(System.IntPtr style)
        {
            return NativeControl.SetDefaultStyle(style);
        }

        public bool SetStyle(long start, long end, System.IntPtr style)
        {
            return NativeControl.SetStyle(start, end, style);
        }

        public void Clear()
        {
            NativeControl.Clear();
        }

        public void Copy()
        {
            NativeControl.Copy();
        }

        public void Cut()
        {
            NativeControl.Cut();
        }

        public void AppendText(string text)
        {
            NativeControl.AppendText(text);
        }

        public long GetInsertionPoint()
        {
            return NativeControl.GetInsertionPoint();
        }

        public void Paste()
        {
            NativeControl.Paste();
        }

        public void Redo()
        {
            NativeControl.Redo();
        }

        public void Remove(long from, long to)
        {
            NativeControl.Remove(from, to);
        }

        public void Replace(long from, long to, string value)
        {
            NativeControl.Replace(from, to, value);
        }

        public void SetInsertionPoint(long pos)
        {
            NativeControl.SetInsertionPoint(pos);
        }

        public void SetInsertionPointEnd()
        {
            NativeControl.SetInsertionPointEnd();
        }

        public void SetMaxLength(ulong len)
        {
            NativeControl.SetMaxLength(len);
        }

        public void SetSelection(long from, long to)
        {
            NativeControl.SetSelection(from, to);
        }

        public void SelectAll()
        {
            NativeControl.SelectAll();
        }

        public void SelectNone()
        {
            NativeControl.SelectNone();
        }

        public void Undo()
        {
            NativeControl.Undo();
        }

        public void WriteText(string text)
        {
            NativeControl.WriteText(text);
        }

        public string GetRange(long from, long to)
        {
            return NativeControl.GetRange(from, to);
        }

        public string GetStringSelection()
        {
            return NativeControl.GetStringSelection();
        }

        public void EmptyUndoBuffer()
        {
            NativeControl.EmptyUndoBuffer();
        }

        public bool IsValidPosition(long pos)
        {
            return NativeControl.IsValidPosition(pos);
        }

        public long GetLastPosition()
        {
            return NativeControl.GetLastPosition();
        }

        public long GetSelectionStart()
        {
            return NativeControl.GetSelectionStart();
        }

        public long GetSelectionEnd()
        {
            return NativeControl.GetSelectionEnd();
        }

        internal override Native.Control CreateNativeControl()
        {
            return new Native.TextBox() {
                Text = Control.Text,
                EditControlOnly = !Control.HasBorder,
            };
        }

        protected override void OnAttach()
        {
            base.OnAttach();

            ApplyMultiline();
            ApplyReadOnly();
            NativeControl.Text = Control.Text;

            Control.HasBorderChanged += Control_HasBorderChanged;
            Control.TextChanged += Control_TextChanged;
            Control.MultilineChanged += Control_MultilineChanged;
            Control.ReadOnlyChanged += Control_ReadOnlyChanged;
            NativeControl.TextChanged += NativeControl_TextChanged;
        }

        private void Control_ReadOnlyChanged(object? sender, System.EventArgs e)
        {
            ApplyReadOnly();
        }

        private void ApplyReadOnly()
        {
            NativeControl.ReadOnly = Control.ReadOnly;
        }

        private void ApplyMultiline()
        {
            NativeControl.Multiline = Control.Multiline;
        }

        private void Control_MultilineChanged(object? sender, System.EventArgs e)
        {
            ApplyMultiline();
        }

        private void Control_HasBorderChanged(object? sender, System.EventArgs? e)
        {
            NativeControl.EditControlOnly = !Control.HasBorder;
        }

        protected override void OnDetach()
        {
            base.OnDetach();
            Control.TextChanged -= Control_TextChanged;
            NativeControl.TextChanged -= NativeControl_TextChanged;
            Control.HasBorderChanged -= Control_HasBorderChanged;
            Control.MultilineChanged -= Control_MultilineChanged;
            Control.ReadOnlyChanged -= Control_ReadOnlyChanged;
        }

        private void NativeControl_TextChanged(object? sender, System.EventArgs? e)
        {
            if (e is null)
                throw new System.ArgumentNullException(nameof(e));

            handlingNativeControlTextChanged = true;
            try
            {
                Control.Text = NativeControl.Text!;
            }
            finally
            {
                handlingNativeControlTextChanged = false;
            }
        }

        private void Control_TextChanged(object? sender, System.EventArgs? e)
        {
            if (e is null)
                throw new System.ArgumentNullException(nameof(e));

            if (!handlingNativeControlTextChanged)
            {
                if (NativeControl.Text != Control.Text)
                    NativeControl.Text = Control.Text;
            }
        }
    }
}