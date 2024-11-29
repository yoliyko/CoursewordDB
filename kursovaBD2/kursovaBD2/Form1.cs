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
using System.Xml.Serialization;
using static kursovaBD2.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace kursovaBD2
{
    public partial class MainForm : Form
    {
        public class ChangedField
        {
            public string FieldName { get; set; }
            public object OldValue { get; set; }
            public object NewValue { get; set; }
        }
        private List<ChangedField> changedFields = new List<ChangedField>();
        public MainForm()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=127.0.0.1;Database=pharmacy;Uid=admin;Pwd=yoliyko;";
                string selectedTable = comboBox1.SelectedItem.ToString();
                string query = $"SELECT * FROM {selectedTable}";

                DatabaseManager dbManager = new DatabaseManager(connectionString);
                DataTable dataTable = dbManager.ExecuteQuery(query);
                dataGridView1.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem.ToString();

            switch (selectedValue)
            {
                case "medicines":
                    AddMedicine form1 = new AddMedicine();
                    form1.Show();
                    break;
                case "suppliers":
                    AddSupplier form2 = new AddSupplier();
                    form2.Show();
                    break;
                case "customers":
                    AddCustomer form3 = new AddCustomer();
                    form3.Show();
                    break;
                case "sales":
                    AddSale form4 = new AddSale();
                    form4.Show();
                    break;
                case "sale_items":
                    MessageBox.Show("Неможливо додати запис!");
                    break;
                case "prescriptions":
                    MessageBox.Show("Неможливо додати запис!");
                    break;
                case "inventory":
                    AddInventory form5 = new AddInventory();
                    form5.Show();
                    break;
            }
        }
    }
}
