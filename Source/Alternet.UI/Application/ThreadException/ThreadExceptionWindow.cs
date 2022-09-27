﻿using Alternet.Drawing;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace Alternet.UI
{
    /// <summary>
    ///  Implements a window that is displayed when an unhandled exception occurs in
    ///  a thread.
    /// </summary>
    public class ThreadExceptionWindow : Window
    {
        private TextBox? messageTextBox;
        private readonly Exception exception;

        /// <summary>
        ///  Initializes a new instance of the <see cref="ThreadExceptionWindow"/> class.
        /// </summary>
        public ThreadExceptionWindow(Exception exception)
        {
            this.exception = exception;
            InitializeControls();

            var activeWindow = ActiveWindow;
            if (activeWindow is null || activeWindow.Title.Length == 0)
                Title = "Exception Occured";
            else
                Title = activeWindow.Title;

            messageTextBox!.Text = GetMessageText(exception);
        }

        private static Image LoadImage(string name)
        {
            return new Image(typeof(ThreadExceptionWindow).Assembly.GetManifestResourceStream(name));
        }

        private void InitializeControls()
        {
            // Cannot use UIXML in the Alternet.UI assembly itself, so populate the controls from code.

            BeginInit();

            Width = 450;
            Height = 250;

            Padding = new Thickness(10);
            MinimizeEnabled = false;
            MaximizeEnabled = false;
            StartLocation = WindowStartLocation.CenterScreen;
            AlwaysOnTop = true;

            var mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            Children.Add(mainGrid);

            var messageGrid = CreateMessageGrid();
            messageGrid.Margin = new Thickness(0, 0, 0, 10);
            mainGrid.Children.Add(messageGrid);

            var buttonsGrid = CreateButtonsGrid();
            Grid.SetRow(buttonsGrid, 1);
            buttonsGrid.VerticalAlignment = VerticalAlignment.Bottom;
            mainGrid.Children.Add(buttonsGrid);

            EndInit();

            Grid CreateMessageGrid()
            {
                var messageGrid = new Grid();
                messageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                messageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                var errorImagePictureBox = new PictureBox
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(0, 0, 10, 0)
                };

                errorImagePictureBox.Image = LoadImage("Alternet.UI.Application.ThreadException.Resources.ErrorImage.png");
                messageGrid.Children.Add(errorImagePictureBox);

                var stackPanel = new StackPanel { Orientation = StackPanelOrientation.Vertical };
                messageGrid.Children.Add(stackPanel);
                Grid.SetColumn(stackPanel, 1);

                var lines = new[]
                {
                    "Unhandled exception has occurred in your application.",
                    "If you click Continue, the application will ignore this error",
                    "and attempt to continue.",
                    "If you click Quit, the application will close immediately."
                };

                foreach (var line in lines)
                {
                    var label = new Label { Text = line };
                    stackPanel.Children.Add(label);
                }

                stackPanel.Children.Add(new Label { Text = "Exception message:", Margin = new Thickness(0, 15, 0, 5) });

                messageTextBox = new TextBox
                {
                    Text = " ",
                    ReadOnly = true,
                    Multiline = true
                };

                stackPanel.Children.Add(messageTextBox);

                return messageGrid;
            }

            Grid CreateButtonsGrid()
            {
                var buttonsGrid = new Grid();
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                var detailsButton = new Button { Text = "&Details..." };
                detailsButton.Click += DetailsButton_Click;
                buttonsGrid.Children.Add(detailsButton);
                Grid.SetColumn(detailsButton, 0);

                var continueButton = new Button { Text = "&Continue" };
                continueButton.Click += ContinueButton_Click;
                buttonsGrid.Children.Add(continueButton);
                Grid.SetColumn(continueButton, 2);

                var quitButton = new Button { Text = "&Quit" };
                quitButton.Click += QuitButton_Click;
                buttonsGrid.Children.Add(quitButton);
                Grid.SetColumn(quitButton, 3);

                return buttonsGrid;
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            using (var detailsWindow = new ThreadExceptionDetailsWindow(GetDetailsText(exception)))
                detailsWindow.ShowModal(this);
        }

        private static string GetMessageText(Exception e)
        {
            var messageText = e.Message;

            if (messageText.Length == 0)
                messageText = e.GetType().Name;

            messageText = Trim(messageText);

            return messageText;

            static string Trim(string s)
            {
                if (s is null)
                {
                    return s;
                }

                int i = s.Length;
                while (i > 0 && s[i - 1] == '.')
                {
                    i--;
                }

                return s.Substring(0, i);
            }
        }

        private static string GetDetailsText(Exception e)
        {
            StringBuilder detailsTextBuilder = new StringBuilder();
            string newline = "\r\n";
            string separator = "----------------------------------------\r\n";
            string sectionseparator = "\r\n************** {0} **************\r\n";

            detailsTextBuilder.Append(string.Format(CultureInfo.CurrentCulture, sectionseparator, "Exception Text"));
            detailsTextBuilder.Append(e.ToString());
            detailsTextBuilder.Append(newline);
            detailsTextBuilder.Append(newline);
            detailsTextBuilder.Append(string.Format(CultureInfo.CurrentCulture, sectionseparator, "Loaded Assemblies"));

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                AssemblyName name = asm.GetName();
                string? fileVer = "n/a";

                try
                {
                    if (name.EscapedCodeBase is not null && name.EscapedCodeBase.Length > 0)
                    {
                        Uri codeBase = new Uri(name.EscapedCodeBase);
                        if (codeBase.Scheme == "file")
                        {
                            fileVer = FileVersionInfo.GetVersionInfo(new System.Uri(name.EscapedCodeBase).LocalPath).FileVersion;
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                }

                const string ExDlgMsgLoadedAssembliesEntry = "{0}\r\n    Assembly Version: {1}\r\n    Win32 Version: {2}\r\n    CodeBase: {3}\r\n";

                detailsTextBuilder.Append(string.Format(ExDlgMsgLoadedAssembliesEntry, name.Name, name.Version, fileVer, name.EscapedCodeBase));
                detailsTextBuilder.Append(separator);
            }

            detailsTextBuilder.Append(newline);
            detailsTextBuilder.Append(newline);

            return detailsTextBuilder.ToString();
        }
    }
}