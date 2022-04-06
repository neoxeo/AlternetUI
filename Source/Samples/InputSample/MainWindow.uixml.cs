using System;
using Alternet.UI;

namespace InputSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InputManager.Current.PreProcessInput += InputManager_PreProcessInput;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            UpdateModifierKeys();
            if (e.Key == Key.F9 && Keyboard.Modifiers == (ModifierKeys.Control | ModifierKeys.Shift))
            {
                MessageBox.Show("You have just pressed Ctrl+Shift+F9.", "Key Combination Pressed");
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            UpdateModifierKeys();
        }

        private void UpdateModifierKeys()
        {
            controlPressedCheckBox.IsChecked = (Keyboard.Modifiers & ModifierKeys.Control) != 0;
            shiftPressedCheckBox.IsChecked = (Keyboard.Modifiers & ModifierKeys.Shift) != 0;
            altPressedCheckBox.IsChecked = (Keyboard.Modifiers & ModifierKeys.Alt) != 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                InputManager.Current.PreProcessInput -= InputManager_PreProcessInput;
            }

            base.Dispose(disposing);
        }

        private void InputManager_PreProcessInput(object sender, PreProcessInputEventArgs e)
        {
            if (cancelF1KeyInputCheckBox.IsChecked)
            {
                if (e.Input is KeyEventArgs ke)
                {
                    if (ke.Key == Key.F1)
                        e.Cancel();
                }
            }
        }

        int messageNumber;

        private void LogMessage(string m)
        {
            lb.Items.Add(m);
            lb.SelectedIndex = lb.Items.Count - 1;
        }

        private void LogKey(KeyEventArgs e, string objectName, string eventName) => LogMessage($"{++messageNumber} {objectName}_{eventName} [{e.Key}], Rep: {e.IsRepeat}");

        private void HelloButton_KeyDown(object sender, KeyEventArgs e) => LogKey(e, "HelloButton", "KeyDown");

        private void StackPanel_KeyDown(object sender, KeyEventArgs e) => LogKey(e, "StackPanel", "KeyDown");

        private void Window_KeyDown(object sender, KeyEventArgs e) => LogKey(e, "Window", "KeyDown");

        private void HelloButton_KeyUp(object sender, KeyEventArgs e) => LogKey(e, "HelloButton", "KeyUp");

        private void StackPanel_KeyUp(object sender, KeyEventArgs e) => LogKey(e, "StackPanel", "KeyUp");

        private void Window_KeyUp(object sender, KeyEventArgs e) => LogKey(e, "Window", "KeyUp");

        private void HelloButton_PreviewKeyDown(object sender, KeyEventArgs e) => LogKey(e, "HelloButton", "PreviewKeyDown");

        private void StackPanel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            LogKey(e, "StackPanel", "PreviewKeyDown");
            if (handlePreviewEventsCheckBox.IsChecked)
                e.Handled = true;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e) => LogKey(e, "Window", "PreviewKeyDown");

        private void HelloButton_PreviewKeyUp(object sender, KeyEventArgs e) => LogKey(e, "HelloButton", "PreviewKeyUp");

        private void StackPanel_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            LogKey(e, "StackPanel", "PreviewKeyUp");
            if (handlePreviewEventsCheckBox.IsChecked)
                e.Handled = true;
        }

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e) => LogKey(e, "Window", "PreviewKeyUp");
    }
}