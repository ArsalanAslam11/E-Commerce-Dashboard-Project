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
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;

namespace Shoprite.Screens
{
    /// <summary>
    /// Interaction logic for Forget.xaml
    /// </summary>
    public partial class Forget : Window
    {

        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Forget()
        {

            server = "localhost";
            database = "Ecommerce";
            uid = "root";
            password = "1234";

            String connString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            conn = new MySqlConnection(connString);
            InitializeComponent();
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public bool IsDarkTheme { get; set; }
        public Uri Source { get; private set; }

        private readonly PaletteHelper pallethelper = new PaletteHelper();

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = pallethelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }

            pallethelper.SetTheme(theme);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void login(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow home = new MainWindow();
            home.Show();
        }

        private void reset(object sender, RoutedEventArgs e)
        {

            string user = txtUsername.Text;
            string pass = txtPassword.Password;



            conn.Open();
            string query = $" UPDATE users SET password= '{pass}' WHERE username= '{user}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show($"Passsword reset SUCCESSFULLY");
            conn.Close();


            txtPassword.Password = "";
            txtUsername.Text = "";

        }
    }
}