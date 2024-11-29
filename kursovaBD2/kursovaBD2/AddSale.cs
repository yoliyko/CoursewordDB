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
    public partial class AddSale : Form
    {
        public AddSale()
        {
            InitializeComponent();
        }

        private void buttonAddSale_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Database=pharmacy;Uid=admin;Pwd=yoliyko;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // заповнюємо таблицю sales
                string query = "INSERT INTO sales(date, idcustomer, total_amount, payment_method) VALUES (@date, @idcustomer, @total_amount, @payment_method)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@idcustomer", textBoxCustomerId.Text);
                    command.Parameters.AddWithValue("@total_amount", textBoxAmount.Text);
                    command.Parameters.AddWithValue("@payment_method", textBoxPayment.Text);

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
