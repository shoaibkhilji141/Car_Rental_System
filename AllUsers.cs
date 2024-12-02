using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class AllUsers : Form
    {
        public AllUsers()
        {
            InitializeComponent();

            // Load data into DataGridView when the form is opened
            LoadData();
        }

        // Function to load persons data from the database into DataGridView
        private void LoadData()
        {
            string connectionString = "Data Source=CIRCUITSORCERER\\SQLEXPRESS;Initial Catalog=dbSigned_Up;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL query to retrieve only Username, Gender, and Contact columns from Persons table
                    string query = "SELECT Username, Gender, Contact FROM Persons";

                    // Use SqlDataAdapter to fetch data and fill a DataTable
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    // Manually create columns with a specified width
                    dataGridView1.Columns.Clear(); // Clear existing columns if necessary

                    // Create Username column
                    DataGridViewTextBoxColumn usernameColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Username",
                        HeaderText = "Username",
                        Width = 200 // Set column width to 200
                    };
                    dataGridView1.Columns.Add(usernameColumn);

                    // Create Gender column
                    DataGridViewTextBoxColumn genderColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Gender",
                        HeaderText = "Gender",
                        Width = 200 // Set column width to 200
                    };
                    dataGridView1.Columns.Add(genderColumn);

                    // Create Contact column
                    DataGridViewTextBoxColumn contactColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Contact",
                        HeaderText = "Contact",
                        Width = 200 // Set column width to 200
                    };
                    dataGridView1.Columns.Add(contactColumn);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
