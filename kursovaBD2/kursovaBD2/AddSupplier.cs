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
    public partial class AddSupplier : Form
    {
        public AddSupplier()
        {
            InitializeComponent();
        }

        private void buttonAddSup_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Database=pharmacy;Uid=admin;Pwd=yoliyko;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // заповнюємо таблицю suppliers
                string query = "INSERT INTO suppliers(name, contact_info, address, phone_number, email) VALUES (@name, @contact_info, @address, @phone_number, @email)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", textBoxName.Text);
                    command.Parameters.AddWithValue("@contact_info", textBoxContact.Text);
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
