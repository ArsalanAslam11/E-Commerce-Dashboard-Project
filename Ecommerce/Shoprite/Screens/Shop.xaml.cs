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
using System.Windows.Shapes;

namespace Shoprite.Screens
{
    
    public partial class Shop : Window
    {
        public Shop()
        {
            InitializeComponent();

        }

        private void logback(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow shop = new MainWindow();
            shop.Show();
        }

        private void upd_toma(object sender, RoutedEventArgs e)
        {
            this.Hide();
            cart buyBox = new cart("Taila wali keri", "3000");
            buyBox.Show();


        }

        private void back(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Screens.Shop home = new Screens.Shop();
            home.Show();
        }

        private void nav(object sender, RoutedEventArgs e)
        {
            this.Hide();
            carts.Tomato home = new carts.Tomato();
            home.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BitmapImage productImage = new BitmapImage(new Uri("path_to_your_image/kohatikheri.jpeg", UriKind.RelativeOrAbsolute));
            cart buyBox = new cart("Jalidar Chappal","2800");
            buyBox.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BitmapImage productImage = new BitmapImage(new Uri("path_to_your_image/kohatikheri.jpeg", UriKind.RelativeOrAbsolute));
            cart buyBox = new cart("Black CHppal", "2100");
            buyBox.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BitmapImage productImage = new BitmapImage(new Uri("path_to_your_image/kohatikheri.jpeg", UriKind.RelativeOrAbsolute));
            cart buyBox = new cart( "Charsadwal 7610 Red Chappal", "1800");
            buyBox.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BitmapImage productImage = new BitmapImage(new Uri("path_to_your_image/kohatikheri.jpeg", UriKind.RelativeOrAbsolute));
            cart buyBox = new cart( "Red Panjidar Chappal", "2400");
            buyBox.Show();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BitmapImage productImage = new BitmapImage(new Uri("path_to_your_image/kohatikheri.jpeg", UriKind.RelativeOrAbsolute));
            cart buyBox = new cart("Kapttan Red Chappal", "2100");
            buyBox.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BitmapImage productImage = new BitmapImage(new Uri("path_to_your_image/kohatikheri.jpeg", UriKind.RelativeOrAbsolute));
            cart buyBox = new cart( "Kapttan Zard Keri", "1400");
            buyBox.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BitmapImage productImage = new BitmapImage(new Uri("path_to_your_image/kohatikheri.jpeg", UriKind.RelativeOrAbsolute));
            cart buyBox = new cart( "Taladar panjidar Chappal", "2900");
            buyBox.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BitmapImage productImage = new BitmapImage(new Uri("path_to_your_image/kohatikheri.jpeg", UriKind.RelativeOrAbsolute));
            cart buyBox = new cart("Red Chappal", "2200");
            buyBox.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BitmapImage productImage = new BitmapImage(new Uri("path_to_your_image/kohatikheri.jpeg", UriKind.RelativeOrAbsolute));
            cart buyBox = new cart( "Rgazine & leather Red Chappal", "2000");
            buyBox.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BitmapImage productImage = new BitmapImage(new Uri("path_to_your_image/kohatikheri.jpeg", UriKind.RelativeOrAbsolute));
            cart buyBox = new cart( "White Chappal", "1700");
            buyBox.Show();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BitmapImage productImage = new BitmapImage(new Uri("path_to_your_image/kohatikheri.jpeg", UriKind.RelativeOrAbsolute));
            cart buyBox = new cart( "Kapttan Blue Chappal", "2700");
            buyBox.Show();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {

        }
    }
}
