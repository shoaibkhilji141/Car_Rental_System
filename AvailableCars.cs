using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class AvailableCars : Form
    {
        // DllImport for rounded corners (if needed)

        public AvailableCars()
        {
            InitializeComponent();

            // Load data into DataGridView when the form is opened
            LoadData();
        }

        // Function to load only available cars from the database into DataGridView
        private void LoadData()
        {
            string connectionString = "Data Source=CIRCUITSORCERER\\SQLEXPRESS;Initial Catalog=dbSigned_Up;Integrated Security=True;";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL query to retrieve only available cars (Availability = 1 or true)
                    string query = "SELECT Car_ID, Make, Model, price, Year, CAST(Availability AS BIT) AS Availability " +
                                   "FROM Cars WHERE Availability = 1";

                    // Use SqlDataAdapter to fetch data and fill a DataTable
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    dataGridView1.AutoGenerateColumns = true;

                    // Binding DataTable to DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Adjusting DataGridView column headers (Optional, since headers are auto-generated)
                    dataGridView1.Columns["Car_ID"].HeaderText = "Car ID";
                    dataGridView1.Columns["Make"].HeaderText = "Brand";
                    dataGridView1.Columns["Model"].HeaderText = "Model";
                    dataGridView1.Columns["price"].HeaderText = "Rental Price";
                    dataGridView1.Columns["Year"].HeaderText = "Year";
                    dataGridView1.Columns["Availability"].HeaderText = "Availability";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
