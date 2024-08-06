using MySql.Data.MySqlClient;
using Shoprite.carts;
using System;
using System.Data;
using System.Windows;

namespace Shoprite.Screens
{
    /// <summary>
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;

        public AdminScreen()
        {
            server = "localhost";
            database = "Ecommerce";
            uid = "root";
            password = "1234";

            string connString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            conn = new MySqlConnection(connString);

            InitializeComponent();

            // Initialize data on load
            LoadData();
        }

        private void LoadData()
        {
            LoadAdminCount();
            LoadCategoryData();
            LoadAttendantCount();
            LoadTillCount();
            LoadSalesData();
        }

        private void LoadAdminCount()
        {
            string query = "SELECT COUNT(*) FROM users WHERE role='admin'";
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            int rows = Convert.ToInt32(command.ExecuteScalar());
            admins.Text = rows.ToString();
            conn.Close();
        }

        private void LoadCategoryData()
        {
            string query = "SELECT * FROM category";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            dataGrid.DataContext = dt;
        }

        private void LoadAttendantCount()
        {
            string query = "SELECT COUNT(*) FROM users WHERE role='attendant'";
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            int rows = Convert.ToInt32(command.ExecuteScalar());
            users.Text = rows.ToString();
            conn.Close();
        }

        private void LoadTillCount()
        {
            string query = "SELECT COUNT(*) FROM tills";
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            int rows = Convert.ToInt32(command.ExecuteScalar());
            total_tills.Text = rows.ToString();
            conn.Close();
        }

        private void LoadSalesData()
        {
            string query = "SELECT * FROM sales";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            sales.DataContext = dt;
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
            carts.Tomato home = new carts.Tomato();
            home.Show();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Screens.Shop home = new Screens.Shop();
            home.Show();
        }

        private void views(object sender, RoutedEventArgs e)
        {
            LoadCategoryData();
            LoadAttendantCount();
            LoadTillCount();
            LoadAdminCount();
        }

        private void update(object sender, RoutedEventArgs e)
        {
            try
            {
                string itemName = Name.Text;
                int quantity = int.Parse(quatityx.Text);
                decimal price = decimal.Parse(pricex.Text);
                decimal amount = decimal.Parse(amountx.Text);
                int sold = int.Parse(soldx.Text);
                int id = int.Parse(idx.Text);

                string query = "UPDATE category SET Name=@Name, quantity=@quantity, price=@price, sold=@sold, amount=@amount WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", itemName);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@sold", sold);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                int value = cmd.ExecuteNonQuery();
                MessageBox.Show($"ID number {id} is UPDATED SUCCESSFULLY");
                conn.Close();

                ClearInputFields();
                LoadCategoryData(); // Refresh data grid after update
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                conn.Close();
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            try
            {
                string type = Name.Text;
                string item = Name.Text;
                int quantity = int.Parse(quatityx.Text);
                decimal price = decimal.Parse(pricex.Text);
                decimal amount = decimal.Parse(amountx.Text);
                int sold = int.Parse(soldx.Text);

                string query = "INSERT INTO category(Name,quantity, price, sold, amount) VALUES (@Name, @quantity, @price, @sold, @amount)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", type);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@sold", sold);

                conn.Open();
                int value = cmd.ExecuteNonQuery();
                MessageBox.Show("Added SUCCESSFULLY");
                conn.Close();

                ClearInputFields();
                LoadCategoryData(); // Refresh data grid after insert
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                conn.Close();
            }
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(idx.Text);

                string query = "DELETE FROM category WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                int value = cmd.ExecuteNonQuery();
                MessageBox.Show($"ID number {id} DELETED SUCCESSFULLY");
                conn.Close();

                ClearInputFields();
                LoadCategoryData(); // Refresh data grid after delete
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                conn.Close();
            }
        }

        private void view_sales(object sender, RoutedEventArgs e)
        {
            LoadSalesData();
        }

        private void gotoTill(object sender, RoutedEventArgs e)
        {
            this.Close();
            Tills home = new Tills();
            home.Show();
        }

        private void ClearInputFields()
        {
            Name.Text = "";
            Name.Text = "";
            quatityx.Text = "";
            pricex.Text = "";
            amountx.Text = "";
            soldx.Text = "";
            idx.Text = "";
        }

        private void Name_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}