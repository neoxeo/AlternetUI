using Alternet.Drawing;
using Alternet.Drawing.Printing;
using Alternet.UI;

namespace PrintingSample
{
    public partial class MainWindow : Window
    {
        private Font font = new Font(FontFamily.GenericSerif, 25);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawingArea_Paint(object? sender, PaintEventArgs e)
        {
            var dc = e.DrawingContext;
            var bounds = e.Bounds;

            if (originAtMarginCheckBox.IsChecked)
            {
                var margins = TryGetPageMargins();
                if (margins != null)
                    bounds.Inflate(margins.Value.Size * -1);
            }

            DrawFirstPage(dc, bounds);
        }

        private void DrawFirstPage(DrawingContext dc, Rect bounds)
        {
            dc.DrawRectangle(Pens.Blue, bounds);
            dc.DrawText(
                "The quick brown fox jumps over the lazy dog.",
                font,
                Brushes.Black,
                bounds,
                new TextFormat { Wrapping = TextWrapping.None });
        }

        private void PrintImmediatelyMenuItem_Click(object sender, System.EventArgs e)
        {
            var document = CreatePrintDocument();
            document.PrintPage += Document_PrintPage;
            document.Print();
        }

        Margins? TryGetPageMargins()
        {
            if (Thickness.TryParse(pageMarginTextBox.Text, out var thickness))
                return new Margins(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);

            return null;
        }

        private PrintDocument CreatePrintDocument()
        {
            var document = new PrintDocument
            {
                OriginAtMargins = originAtMarginCheckBox.IsChecked,
                DocumentName = printDocumentNameTextBox.Text,
            };

            document.DefaultPageSettings.Margins = TryGetPageMargins() ?? new Margins();

            return document;
        }

        private void PrintMenuItem_Click(object sender, System.EventArgs e)
        {
            var dialog = new PrintDialog();
            var document = CreatePrintDocument();

            dialog.Document = document;
            dialog.AllowSelection = true;
            dialog.AllowSomePages = false;

            document.PrintPage += Document_PrintPage;

            if (dialog.ShowModal() == ModalResult.Accepted)
                document.Print();
        }

        private void PageSetupMenuItem_Click(object sender, System.EventArgs e)
        {
            var pageSetupDialog = new PageSetupDialog();
            var document = CreatePrintDocument();

            pageSetupDialog.Document = document;
            //setupDlg.AllowMargins = false;
            //setupDlg.AllowOrientation = false;
            //setupDlg.AllowPaper = false;
            //setupDlg.AllowPrinter = false;

            if (pageSetupDialog.ShowModal() == ModalResult.Accepted)
            {
                //document.DefaultPageSettings = pageSetupDialog.PageSettings;
                //document.PrinterSettings = pageSetupDialog.PrinterSettings;

                document.PrintPage += Document_PrintPage;
                document.Print();
            }
        }

        private void PrintPreviewMenuItem_Click(object sender, System.EventArgs e)
        {
            var dialog = new PrintPreviewDialog();
            var document = new PrintDocument();

            document.PrintPage += Document_PrintPage;
            dialog.Document = document;
            dialog.ShowModal();
        }

        private void Document_PrintPage(object? sender, PrintPageEventArgs e)
        {
            var pb = e.PageBounds;
            var ppb = e.PrintablePageBounds;
            var phpb = e.PhysicalPageBounds;
            var mb = e.MarginBounds;

            int pageNumber = e.PageNumber;

            if (pageNumber == 1)
            {
                DrawFirstPage(
                    e.DrawingContext,
                    new Rect(
                        new Point(),
                        originAtMarginCheckBox.IsChecked ? e.MarginBounds.Size : e.PrintablePageBounds.Size));
            }
            else
            {
                DrawAdditionalPage(e.DrawingContext, pageNumber);
            }

            e.HasMorePages = pageNumber - 1 < additionalPagesCountNumericUpDown.Value;
        }

        private void DrawAdditionalPage(DrawingContext dc, int pageNumber)
        {
            dc.DrawText("Additional page #" + pageNumber, font, Brushes.Black, new Point());
        }

        private void AboutMenuItem_Click(object sender, System.EventArgs e) => MessageBox.Show("AlterNET UI Printing Sample Application.", "About");

        private void ExitMenuItem_Click(object sender, System.EventArgs e) => Close();

        private void OriginAtMarginCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            DrawingArea.Invalidate();
        }

        private void PageMarginTextBox_TextChanged(object sender, Alternet.UI.TextChangedEventArgs e)
        {
            DrawingArea.Invalidate();
        }
    }
}