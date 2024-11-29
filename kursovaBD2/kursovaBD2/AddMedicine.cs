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
    public partial class AddMedicine : Form
    {
        public AddMedicine()
        {
            InitializeComponent();
        }

        private void buttonAddMed_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Database=pharmacy;Uid=admin;Pwd=yoliyko;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // заповнюємо таблицю medicines
                string query = "INSERT INTO medicines(name, description, dosage_form, strength, expiry_date, price, quantity_in_stock, idsuppliers) VALUES (@name, @description, @dosage_form, @strength, @expiry_date, @price, @quantity_in_stock, @idsuppliers)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", textBoxName.Text);
                    command.Parameters.AddWithValue("@description", textBoxDescription.Text);
                    command.Parameters.AddWithValue("@dosage_form", textBoxDosageForm.Text);
                    command.Parameters.AddWithValue("@strength", textBoxStrength.Text);
                    command.Parameters.AddWithValue("@expiry_date", dateTimePickerExpire.Value);
                    command.Parameters.AddWithValue("@price", textBoxPrice.Text);
                    command.Parameters.AddWithValue("@quantity_in_stock", textBoxQuantity.Text);//змінити на інт
                    command.Parameters.AddWithValue("@idsuppliers", textBoxSupplier.Text);//змінити на інт

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
