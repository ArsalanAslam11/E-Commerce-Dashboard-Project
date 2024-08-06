using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Shoprite.Screens
{
    public partial class cart : Window
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;

        public cart(string desc, string amount)
        {
            server = "localhost";
            database = "Ecommerce";
            uid = "root";
            password = "1234";
            string connString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            conn = new MySqlConnection(connString);

            InitializeComponent();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
                return;
            }

            // Set the text for the labels
            Label1.Content = desc;
            Label2.Content = amount;
        }

        private void Buy_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = Name.Text;
                int contact =int.Parse( Contact.Text);
                string address = Address.Text;

                int price = int.Parse(Label2.Content.ToString());

                string addressQuery = $"INSERT INTO Address (full_Address,  product_Price) VALUES ('{address}',  {price})";
                string customerQuery = $"INSERT INTO customer (full_name, contact) VALUES ('{name}', {contact})";

                using (MySqlCommand addressCmd = new MySqlCommand(addressQuery, conn))
                using (MySqlCommand customerCmd = new MySqlCommand(customerQuery, conn))
                {
                    int addressRowsAffected = addressCmd.ExecuteNonQuery();
                    int customerRowsAffected = customerCmd.ExecuteNonQuery();

                    if (addressRowsAffected > 0 && customerRowsAffected > 0)
                    {
                        MessageBox.Show("Data inserted successfully!");

                        Name.Text = "Name";
                        Contact.Text = "Contact";
                        Address.Text = "Address";
                        Zip_Code.Text = "Price";
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert data!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void TextBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == textBox.Name)
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Name;
            }
        }
    }
}
