using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static kursovaBD2.Program;

namespace kursovaBD2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public class DatabaseManager
        {
            private string connectionString = "Server=127.0.0.1;Database=pharmacy;Uid=admin;Pwd=yoliyko;";
            public DatabaseManager(string connectionString)
            {
                this.connectionString = connectionString;
            }
            public DataTable ExecuteQuery(string query)
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            connection.Open();
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                dataTable.Load(reader);
                            }
                            connection.Close();
                        }
                    }
                    return dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
    }
}

