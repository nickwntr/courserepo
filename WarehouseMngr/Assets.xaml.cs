using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
    /// Логика взаимодействия для Assets.xaml
    /// </summary>
    public partial class Assets : Page
    {
        static List<WHProds> list;
        public Assets()
        {
            InitializeComponent();
            UserLog.Content = MainWindow.curruser.UserLogin;
            UserRole.Content = MainWindow.curruser.Role.RoleName;
            Update();
            this.KeyDown += KeyPress;
            List<string> types = new List<string>()
            {
                "Нет",
            };
            foreach (Type t in entities.Type)
            {
                types.Add(t.TypeName);
            }
            Fltrbox.ItemsSource = types;
            if (MainWindow.curruser.Role.RoleID == 1)
            {
                AddItem.Visibility = Visibility.Visible;
                EdtItem.Visibility = Visibility.Visible;
                DelItem.Visibility = Visibility.Visible;
            }
        }
        private void KeyPress (object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search(SearchBox.Text);
            }
        }
        private void Search(string searchstr)
        {
            if (!string.IsNullOrEmpty(searchstr)) 
            {
                List<WHProds> srclist = new List<WHProds>();
                foreach (WHProds prods in list)
                {
                    if (prods.ProdName.Contains(searchstr))
                    {
                        srclist.Add(prods);
                    }
                }
                LView.ItemsSource = null;
                LView.ItemsSource = srclist;
                SearchBox.Text = "";
            }
            else LView.ItemsSource = list;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddItem());
        }

        private void EdtItem_Click(object sender, RoutedEventArgs e)
        {
            if(LView.SelectedIndex != -1)
            {
                var item = (WHProds)LView.SelectedItem;
                NavigationService.Navigate(new AddItem(item));
            }    
        }

        private void fltr(object sender, SelectionChangedEventArgs e)
        {
            if (Fltrbox.SelectedIndex != 0)
            {
                List<WHProds> srclist = new List<WHProds>();
                foreach (WHProds prods in list)
                {
                    if (prods.ProdType == Fltrbox.SelectedIndex)
                    {
                        srclist.Add(prods);
                    }
                }
                LView.ItemsSource = null;
                LView.ItemsSource = srclist;
            }
            else LView.ItemsSource = list;
        }

        private void DelItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (WHProds)LView.SelectedItem;
                entities.WHProds.Remove(item);
                entities.SaveChanges();
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Update()
        {
            Fltrbox.SelectedIndex = 0;
            SearchBox.Text = "";
            list = entities.WHProds.ToList();
            LView.ItemsSource = list;
        }
        private void ConsoldTo(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ConsoldSum());
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
