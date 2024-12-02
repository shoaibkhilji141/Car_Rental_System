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
    public partial class UsersRecords : Form
    {
        public UsersRecords()
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

                    // Fetch all records from the Rental_Record table
                    string fetchAllRentalDataQuery = @"
            SELECT Rental_ID, User_ID, Car_ID, Rental_Hours, Total_Price, Rental_Date, Return_Date
            FROM Rental_Record";

                    using (SqlCommand fetchAllRentalCommand = new SqlCommand(fetchAllRentalDataQuery, conn))
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(fetchAllRentalCommand);
                        DataTable rentalDataTable = new DataTable();
                        sqlDataAdapter.Fill(rentalDataTable);

                        if (rentalDataTable.Rows.Count > 0)
                        {
                            // Bind the data to the DataGridView
                            dataGridView1.DataSource = rentalDataTable;

                            // Adjust column headers for better readability
                            dataGridView1.Columns["Rental_ID"].HeaderText = "Rental ID";
                            dataGridView1.Columns["User_ID"].HeaderText = "User ID";
                            dataGridView1.Columns["Car_ID"].HeaderText = "Car ID";
                            dataGridView1.Columns["Rental_Hours"].HeaderText = "Rental Hours";
                            dataGridView1.Columns["Total_Price"].HeaderText = "Total Price";
                            dataGridView1.Columns["Rental_Date"].HeaderText = "Rental Date";
                            dataGridView1.Columns["Return_Date"].HeaderText = "Return Date";
                        }
                        else
                        {
                            MessageBox.Show("No rental records found.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.DataSource = null; // Clear the grid if no data is found
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
