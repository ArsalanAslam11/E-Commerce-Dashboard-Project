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
    /// Interaction logic for newUser.xaml
    /// </summary>
    public partial class newUser : Window
    {

        /// <summary>
        /// initializing all variables needed for mysql conn
        /// </summary>
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;


        public newUser()
        {
            server = "localhost";
            database = "Ecommerce";
            uid = "root";
            password = "1234";

            String connString;
            connString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            conn = new MySqlConnection(connString);

            ///app will be initialised here for startup after connecting to mysql
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

        /// <summary>
        /// Events to happen when register button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createbtn_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Password;
            string fname = txtfname.Text;
            string lname = txtlname.Text;

            if (Signup(fname, lname, user, pass))
            {
                MessageBox.Show($"An attendant with username: {txtUsername.Text} was added");

                this.Hide();
                MainWindow home = new MainWindow();
                home.Show();
            }

            else
            {
                MessageBox.Show($"An attendant with username: {txtUsername.Text} was not added");
            }
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow home = new MainWindow();
            home.Show();
        }


        public bool Signup(string fname, string lname, string user, string pass, string role = "attendant")
        {
            string query = "INSERT INTO users(firstname, lastname, username, password, role) VALUES (@fname, @lname, @user, @pass, @role)";

            try
            {
                if (openConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@role", role);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception e)
                    {
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
            string query = $"SELECT * FROM users WHERE username='{user}' AND pasword='{pass}'";

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