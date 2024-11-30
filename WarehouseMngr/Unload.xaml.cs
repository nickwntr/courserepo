using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static WarehouseMngr.App;
namespace WarehouseMngr
{
    /// <summary>
    /// Interaction logic for Unload.xaml
    /// </summary>
    public partial class UnloadPage : Page
    {
        public UnloadPage()
        {
            List<string> clentsname = new List<string>()
            {
                "Любой"
            };
            List<string> typesname = new List<string>();
            foreach(Clents cl in entities.Clents.ToList())
            {
                clentsname.Add(cl.ClientName);
            }
            foreach(Type t in entities.Type.ToList())
            {
                typesname.Add(t.TypeName);
            }
            InitializeComponent();
            if (MainWindow.curruser.UserRole == 1)
                AddGrid.Visibility = Visibility.Visible;
            else AddGrid.Visibility = Visibility.Hidden;
            CltsCB.ItemsSource = clentsname;
            AddClnt.ItemsSource = clentsname;
            AddType.ItemsSource = typesname;
            CltsCB.SelectedIndex = 0;
        }
        private void Update(object sender, SelectionChangedEventArgs e)
        {
            DGView.ItemsSource = null;
            List<UnLoad> unloads = new List<UnLoad>();
            if(CltsCB.SelectedIndex != 0)
            {
                unloads = entities.UnLoad.Where(u => u.Loader == CltsCB.SelectedIndex).ToList();
            }
            else 
                unloads = entities.UnLoad.ToList();
            DateTime? fromdt = new DateTime();
            DateTime? todt = new DateTime();
            if (DateFrom.SelectedDate != null)
                fromdt = DateFrom.SelectedDate;
            else fromdt = DateTime.MinValue;
            if (DateTo.SelectedDate != null)
                todt = DateTo.SelectedDate;
            else todt = DateTime.MaxValue;
            unloads = unloads.Where(unload => unload.LoadDate >= fromdt && unload.LoadDate <= todt).ToList();
            DGView.ItemsSource = unloads;
            decimal sum = 0;
            foreach(UnLoad unload in unloads)
            {
                sum += unload.LoadCount * unload.LoadPrice;
            }
            sumLbl.Content = $"Сумма: {sum}Р";
        }
        private void UnlClk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UnLoad un = new UnLoad();
                un.LoadArticle = UnlArt.Text;
                un.LoadName = UnlName.Text;
                if (UnlDate.SelectedDate != null)
                    un.LoadDate = (DateTime)UnlDate.SelectedDate;
                else un.LoadDate = DateTime.Today;
                un.Loader = AddClnt.SelectedIndex;
                un.LoadPrice = Convert.ToInt32(UnlPrice.Text);
                un.LoadCount = Convert.ToInt32(UnlCount.Text);
                un.LoadType = (short)AddType.SelectedIndex;
                entities.UnLoad.Add(un);
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UnlArt.Text = string.Empty;
            UnlName.Text = string.Empty;
            UnlDate.SelectedDate = null;
            AddClnt.SelectedIndex = -1;
            UnlPrice.Text = string.Empty;
            UnlCount.Text = string.Empty;
            AddType.SelectedIndex = -1;
        }

        private void printclk_Click(object sender, RoutedEventArgs e)
        {
            List<UnLoad> ul = DGView.ItemsSource as List<UnLoad>; PrintDialog print = new PrintDialog();
            DataTable dt = ToDataTable(ul);
            dt.Columns.Remove("LoadArticle");
            dt.Columns.Remove("LoadDate");
            dt.Columns.Remove("Loader");
            dt.Columns.Remove("LoadType");
            dt.Columns.Remove("Clents");
            dt.Columns.Remove("Type");
            if ((bool)print.ShowDialog().GetValueOrDefault())
            {
                Table table = new Table()
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(0, 2, 0, 2),
                };
                for (int x = 0; x < DGView.Columns.Count; x++)
                {
                    table.Columns.Add(new TableColumn()
                    {
                        Width = new GridLength(150, GridUnitType.Pixel)
                    });
                }
                table.RowGroups.Add(new TableRowGroup());
                table.RowGroups[0].Rows.Add(new TableRow());
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    TableRow row = table.RowGroups[0].Rows[0];
                    row.Cells.Add(new TableCell(
                        new Paragraph(
                            new Run($"{DGView.Columns[i].Header}")))
                    {
                        BorderBrush = Brushes.Black
                    });
                }
                for (int i = 0; i < ul.Count; i++)
                {
                    TableRow row = table.RowGroups[0].Rows[0];
                    table.RowGroups[0].Rows.Add(new TableRow());
                    row = table.RowGroups[0].Rows[i + 1];
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        row.Cells.Add(new TableCell(
                            new Paragraph(
                                new Run($"{dt.Rows[i][j]}")))
                        {
                            BorderBrush = Brushes.Black
                        });
                    }
                }
                table.RowGroups[0].Rows[0].Background = Brushes.DarkGray;
                for (int i = 1; i < table.RowGroups[0].Rows.Count; i++)
                {
                    if (i % 2 == 0)
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
                document.Blocks.Add(new Paragraph(new Run($"ООО Балашихский кирпичный склад")) { Margin = new Thickness(120, 0, 10, 0) });
                document.Blocks.Add(new Paragraph(new Run($"Отчет отгрузок")) { Margin = new Thickness(120, 0, 10, 0) });
                if(CltsCB.SelectedItem.ToString() != "Любой")
                {
                    document.Blocks.Add(new Paragraph(new Run($"для {CltsCB.SelectedItem.ToString()}")) { Margin = new Thickness(120, 0, 10, 0) });
                    
                }
                if(DateFrom.SelectedDate != null)
                {
                    document.Blocks.Add(new Paragraph(new Run($"С {DateFrom.SelectedDate.Value.ToShortDateString()}")) { Margin = new Thickness(120, 0, 10, 0) });
                    
                }
                if(DateTo.SelectedDate != null)
                {
                    document.Blocks.Add(new Paragraph(new Run($"По {DateTo.SelectedDate.Value.ToShortDateString()}")) { Margin = new Thickness(120, 0, 10, 0) });
                    
                }
                document.Blocks.Add(new Section(table) { Margin = new Thickness(40, 0, 10, 0) });
                document.Blocks.Add(new Paragraph(new Run($"{sumLbl.Content}")) { Margin = new Thickness(120, 0, 10, 0) });
                IDocumentPaginatorSource src = document;
                src.DocumentPaginator.PageSize = new System.Windows.Size(afour.Width, afour.Height);
                print.PrintDocument(src.DocumentPaginator, string.Empty);
            }
        }
    }
}
