using Microsoft.Win32;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using static WarehouseMngr.App;
using System.Windows.Media;

namespace WarehouseMngr
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        string filepath = string.Empty;
        System.Windows.Controls.Image img;
        public AddItem()
        {
            InitializeComponent();
            List<string> types = new List<string>();
            foreach(Type t in entities.Type)
            {
                types.Add(t.TypeName);
            }
            this.Type.ItemsSource = types;

        }
        string prodid;
        public AddItem(WHProds edprod)
        {
            InitializeComponent();
            AddEditBtn.Content = "Изменить";
            List<string> types = new List<string>();
            foreach (Type t in entities.Type)
            {
                types.Add(t.TypeName);
            }
            this.Type.ItemsSource = types;
            this.Type.SelectedIndex = edprod.Type.TypeID - 1;
            arttb.Text = edprod.ProdArticle;
            nametb.Text = edprod.ProdName;
            pricetb.Text = edprod.ProdPrice.ToString();
            counttb.Text = edprod.ProdCount.ToString();
            date.SelectedDate = edprod.ProdDate;
            LocBox.Text = edprod.ProdLoc;
            prodid = edprod.ProdID.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WHProds nprod = new WHProds();
            nprod.ProdArticle = arttb.Text;
            nprod.ProdName = nametb.Text;
            nprod.ProdPrice = decimal.Parse(pricetb.Text);
            nprod.ProdCount = int.Parse(counttb.Text);
            nprod.ProdType = Convert.ToInt16(Type.SelectedIndex + 1);
            if (date.SelectedDate != null)
                nprod.ProdDate = (DateTime)date.SelectedDate;
            else nprod.ProdDate = DateTime.Today;
            nprod.ProdLoc = LocBox.Text;
            if (img != null)
            {
                nprod.ProdImg = ImageToByteArray(System.Drawing.Image.FromFile(filepath));
            }
            Button bname = (Button)sender;
            switch(bname.Content.ToString())
            {
                case "Добавить":
                    {
                        try
                        {
                            entities.WHProds.Add(nprod);
                            entities.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
                case "Изменить":
                    {
                        try
                        {
                            nprod.ProdID = Convert.ToInt32(prodid);
                            entities.WHProds.AddOrUpdate(nprod);
                            entities.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
            }
            
            NavigationService.Navigate(new Assets());
        }

        private void path_Click(object sender, RoutedEventArgs e)
        {
            filepath = string.Empty;
            img = new System.Windows.Controls.Image();
            OpenFileDialog fdg = new OpenFileDialog()
            {
                InitialDirectory = @"C:\",
                Filter = "PNG files (*.png)|*.png|JPG files (*.jpg)|*.jpg",
                FilterIndex = 1,
            };
            if (fdg.ShowDialog().GetValueOrDefault())
            {
                filepath = fdg.FileName;
                FilePath.Text = filepath;
                img.Source = new BitmapImage(new Uri(filepath));
                AddImg.Source = new BitmapImage(new Uri(filepath));
            }
        }
    }
}
