using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class UserRecord : Form
    {
        public UserRecord()
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

                    // Fetch the Username of the last logged-in user from the LoggedIn table
                    string fetchLastLoggedInUserQuery = "SELECT TOP 1 Username FROM LoggedIn ORDER BY ID DESC";
                    string loggedInUsername = null;

                    using (SqlCommand fetchLoggedInCommand = new SqlCommand(fetchLastLoggedInUserQuery, conn))
                    {
                        var result = fetchLoggedInCommand.ExecuteScalar();
                        if (result != null)
                        {
                            loggedInUsername = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No logged-in user found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Check if the logged-in user exists in the Rental_Record table and fetch data
                    string fetchRentalDataQuery = @"
                SELECT Rental_ID, User_ID, Car_ID, Rental_Hours, Total_Price, Rental_Date, Return_Date
                FROM Rental_Record
                WHERE User_ID = @UserID";

                    using (SqlCommand fetchRentalCommand = new SqlCommand(fetchRentalDataQuery, conn))
                    {
                        fetchRentalCommand.Parameters.AddWithValue("@UserID", loggedInUsername);

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(fetchRentalCommand);
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
                            MessageBox.Show("No rental records found for the logged-in user.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
