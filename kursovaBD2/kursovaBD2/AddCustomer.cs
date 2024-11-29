using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovaBD2
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void buttonAddCl_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Database=pharmacy;Uid=admin;Pwd=yoliyko;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // заповнюємо таблицю customers
                string query = "INSERT INTO customers(name, date_of_birth, address, phone_number, email) VALUES (@name, @date_of_birth, @address, @phone_number, @email)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", textBoxName.Text);
                    command.Parameters.AddWithValue("@date_of_birth", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@address", textBoxAddress.Text);
                    command.Parameters.AddWithValue("@phone_number", textBoxPhoneNumber.Text);
                    command.Parameters.AddWithValue("@email", textBoxEmail.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запис успішно додано");
                    }
                    else
                    {
                        MessageBox.Show("Помилка при додаванні запису");
                    }
                }
            }
        }
    }
}
