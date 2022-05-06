using System;
using Alternet.UI;

namespace WindowPropertiesSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UpdateControls();
        }

        TestWindow? testWindow;

        private void CreateAndShowWindowButton_Click(object sender, System.EventArgs e)
        {
            testWindow = new TestWindow();
            testWindow.ShowInTaskbar = showInTaskBarCheckBox.IsChecked;
            testWindow.Show();
            testWindow.Closed += TestWindow_Closed;
            UpdateControls();
        }

        void UpdateControls()
        {
            createAndShowWindowButton.Enabled = testWindow == null;
        }


        private void TestWindow_Closed(object? sender, WindowClosedEventArgs e)
        {
            testWindow = null;
            UpdateControls();
        }

        private void ShowInTaskBarCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (testWindow != null)
                testWindow.ShowInTaskbar = showInTaskBarCheckBox.IsChecked;
        }
    }
}