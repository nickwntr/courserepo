using System;
using System.Collections.Generic;
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

namespace WarehouseMngr
{
    /// <summary>
    /// Логика взаимодействия для Sel.xaml
    /// </summary>
    public partial class Sel : Page
    {
        public Sel()
        {
            InitializeComponent();
        }

        private void ButtonWH_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Assets());
        }

        private void ButtonUnload_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
