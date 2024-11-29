using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovaBD2
{
    public partial class AddInventory : Form
    {
        public AddInventory()
        {
            InitializeComponent();
        }

        private void buttonAddInv_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Database=pharmacy;Uid=admin;Pwd=yoliyko;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // заповнюємо таблицю inventory
                string query = "INSERT INTO inventory(idmedicines, idsuppliers, quantity_added, date_added) VALUES (@idmedicines, @idsuppliers, @quantity_added, @date_added)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idmedicines", textBoxMedId.Text);
                    command.Parameters.AddWithValue("@idsuppliers", textBoxSupId.Text);
                    command.Parameters.AddWithValue("@quantity_added", textBoxQuantity.Text);
                    command.Parameters.AddWithValue("@date_added", dateTimePicker1.Value);
                    
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
