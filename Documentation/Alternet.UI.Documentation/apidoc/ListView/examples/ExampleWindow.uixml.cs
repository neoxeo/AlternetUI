using Alternet.UI;
using System;

namespace Alternet.UI.Documentation.Examples.ListView
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listView.Items.Add(new Alternet.UI.ListViewItem { Text = "Item1" });
            listView.Items.Add(new Alternet.UI.ListViewItem { Text = "Item2" });
            listView.Items.Add(new Alternet.UI.ListViewItem { Text = "Item2" });
            listView.SelectedIndex = 1;
        }

        public void ListViewExample1()
        {
            #region ListViewCSharpCreation
            var ListView = new Alternet.UI.ListView();
            ListView.Items.Add(new Alternet.UI.ListViewItem { Text = "Item1"});
            ListView.Items.Add(new Alternet.UI.ListViewItem { Text = "Item2" });
            ListView.Items.Add(new Alternet.UI.ListViewItem { Text = "Item2" });
            ListView.SelectedIndex = 1;
            #endregion
        }

        #region ListViewEventHandler
        private void ListView_SelectionChanged(object? sender, EventArgs e)
        {
            MessageBox.Show("ListView: SelectionChanged. SelectedIndex: " + listView.SelectedIndex.ToString(), string.Empty);
        }

        #endregion    
    }
}