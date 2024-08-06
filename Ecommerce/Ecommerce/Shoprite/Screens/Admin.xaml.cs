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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {

        public static Admin instace;
        public TextBox txtBox;

        /// <summary>
        /// initializing all variables needed for mysql conn
        /// </summary>
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;
        public Admin()
        {

            server = "localhost";
            database = "Ecommerce";
            uid = "root";
            password = "1234";

            String connString;
            connString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            conn = new MySqlConnection(connString);


            InitializeComponent();

            instace = this;
            txtBox = txtUsername;
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


        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Password;

            if (Islogin(user, pass))
            {
                MessageBox.Show($"Welcome {txtUsername.Text} ");

                this.Hide();
                Screens.AdminScreen ho = new Screens.AdminScreen();
                ho.Show();
            }
            else if (txtUsername.Text.Equals(""))
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                MessageBox.Show($"Admin logins is incorrect");
            }
        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow he = new MainWindow();
            he.Show();
        }


        private bool openConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        MessageBox.Show("connection to server failed");
                        break;
                    case 1045:
                        MessageBox.Show("Server username or password incorrect");
                        break;
                }
                return false;
            }
        }


        public bool Islogin(string user, string pass)
        {
            string query = $"SELECT * FROM users WHERE username='{user}' AND password='{pass}' AND role='admin'";

            try
            {
                if (openConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        conn.Close();
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                conn.Close();
                return false;

            }
        }
    }
}