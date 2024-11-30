using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static WarehouseMngr.App;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Data;
using System.Reflection;
using System.Drawing.Printing;
using System.Windows.Media;

namespace WarehouseMngr
{
    /// <summary>
    /// Interaction logic for ConsoldSum.xaml
    /// </summary>
    public partial class ConsoldSum : Page
    {
        List<WHProds> consold;
        public ConsoldSum()
        {
            InitializeComponent();
            datelbl.Content = $"Сегодня: {DateTime.Today.ToShortDateString()}";
            consold = new List<WHProds>();
            consold = entities.WHProds.ToList();
            DGView.ItemsSource = consold;
            decimal sum = 0;
            foreach (var cons in consold)
            {
                sum = sum + cons.ProdPrice * cons.ProdCount;
            }
            sumLbl.Content = $"Сумма: {sum.ToString("0.00")}Р";
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = ToDataTable(consold);
            dt.Columns.Remove("ProdArticle");
            dt.Columns.Remove("ProdType");
            dt.Columns.Remove("ProdDate");
            dt.Columns.Remove("ProdImg");
            dt.Columns.Remove("Type");
            PrintDialog print = new PrintDialog();
            if ((bool)print.ShowDialog().GetValueOrDefault())
            {
                Table table = new Table() 
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(0, 2, 0, 2),
                };
                for (int x = 0; x < DGView.Columns.Count; x++)
                {
                    table.Columns.Add(new TableColumn() {
                        Width = new GridLength(150,GridUnitType.Pixel)});
                }
                table.RowGroups.Add(new TableRowGroup());
                table.RowGroups[0].Rows.Add(new TableRow());
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    TableRow row = table.RowGroups[0].Rows[0];
                    row.Cells.Add(new TableCell(
                        new Paragraph(
                            new Run($"{DGView.Columns[i].Header}"))){
                        BorderBrush = Brushes.Black});
                }
                for (int i = 0; i < consold.Count; i++)
                {
                    TableRow row = table.RowGroups[0].Rows[0];
                    table.RowGroups[0].Rows.Add(new TableRow());
                    row = table.RowGroups[0].Rows[i + 1];
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        row.Cells.Add(new TableCell(
                            new Paragraph(
                                new Run($"{dt.Rows[i][j]}"))) {
                            BorderBrush = Brushes.Black});
                    }
                }
                table.RowGroups[0].Rows[0].Background = Brushes.DarkGray;
                for (int i = 1;i < table.RowGroups[0].Rows.Count; i++)
                {
                    if(i % 2 == 0)
                        table.RowGroups[0].Rows[i].Background = Brushes.White;
                    else
                        table.RowGroups[0].Rows[i].Background = Brushes.LightGray;
                }
                PrinterSettings ps = new PrinterSettings();
                IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
                PaperSize afour = paperSizes.First(size => size.Kind == PaperKind.A4);
                FlowDocument document = new FlowDocument()
                {
                    ColumnWidth = afour.Width,
                    PageWidth = afour.Width,
                    PageHeight = afour.Height
                };
                document.Blocks.Add(new Paragraph(new Run($"{namelbl.Content}")) { Margin = new Thickness(120, 0, 10, 0) });
                document.Blocks.Add(new Paragraph(new Run($"{datelbl.Content}")) { Margin = new Thickness(120, 0, 10, 0) });
                document.Blocks.Add(new Section(table) { Margin = new Thickness(40, 0, 10, 0) });
                document.Blocks.Add(new Paragraph(new Run($"{sumLbl.Content}")) { Margin = new Thickness(120, 0, 10, 0) });
                IDocumentPaginatorSource src = document;
                src.DocumentPaginator.PageSize = new System.Windows.Size(afour.Width, afour.Height);
                print.PrintDocument(src.DocumentPaginator, string.Empty);
                NavigationService.GoBack();
            }          
        }        
    }
}
