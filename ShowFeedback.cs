using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ShowFeedback : Form
    {
        public ShowFeedback()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = "Data Source=CIRCUITSORCERER\\SQLEXPRESS;Initial Catalog=dbSigned_Up;Integrated Security=True;";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL query to retrieve only Username and Feedback columns from FEEDBACK table
                    string query = "SELECT Username, Feedback FROM FEEDBACK";

                    // Use SqlDataAdapter to fetch data and fill a DataTable
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    // Clear existing columns in DataGridView
                    dataGridView1.Columns.Clear();

                    // Create Username column
                    DataGridViewTextBoxColumn usernameColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Username", // Column name from DataTable
                        HeaderText = "Username",       // Header text in DataGridView
                        Width = 200                    // Set column width
                    };
                    dataGridView1.Columns.Add(usernameColumn);

                    // Create Feedback column
                    DataGridViewTextBoxColumn feedbackColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Feedback", // Column name from DataTable
                        HeaderText = "Feedback",       // Header text in DataGridView
                        Width = 400                    // Set column width
                    };
                    dataGridView1.Columns.Add(feedbackColumn);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Display error message in case of exception
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
