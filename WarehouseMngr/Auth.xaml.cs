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
using static WarehouseMngr.App;

namespace WarehouseMngr
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(EnterKeyChk);
        }

        private void EnterKeyChk(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Enterdb_Click(Enterdb, null);
            }
        }

        private void Enterdb_Click(object sender, RoutedEventArgs e)
        {
            User user = entities.User.Where(w => w.UserLogin == LoginBox.Text).FirstOrDefault();
            if (user != null)
            {
                if (user.UserPass == PassBox.Password)
                {
                    MainWindow.curruser = user;
                    MessageBox.Show("Добро Пожаловать");
                    NavigationService.Navigate(new Select());
                }
            }
        }

        private void ExtBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
