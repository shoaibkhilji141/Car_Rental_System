using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class AllCars : Form
    {
        // DllImport for rounded corners


        public AllCars()
        {
            InitializeComponent();



            // Load data into DataGridView when the form is opened
            LoadData();
        }


        // Event handler for data errors in DataGridView

        // Event handler for formatting the Availability column


        // Function to load data from the database into DataGridView
        private void LoadData()
        {
            string connectionString = "Data Source=CIRCUITSORCERER\\SQLEXPRESS;Initial Catalog=dbSigned_Up;Integrated Security=True;";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // SQL query to retrieve car data including availability
                    string query = "SELECT Car_ID, Make, Model, price, Year, CAST(Availability AS BIT) AS Availability FROM Cars";

                    // Use SqlDataAdapter to fetch data and fill a DataTable
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    dataGridView1.AutoGenerateColumns = true;

                    // Binding DataTable to DataGridView
                    dataGridView1.DataSource = dataTable;

                    // NO need to manually add columns if binding to DataSource.
                    // Columns will be created automatically from DataTable.

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

        // Event handlers (if needed)
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Customize the panel paint behavior if required
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Handle cell clicks if needed
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
