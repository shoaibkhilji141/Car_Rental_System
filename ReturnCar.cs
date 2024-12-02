using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ReturnCar : Form
    {
        public ReturnCar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Fetch the CarID from the textbox
            string inputCarId = textBox1.Text.Trim();

            // Validate that the CarID is not empty
            if (string.IsNullOrEmpty(inputCarId))
            {
                MessageBox.Show("Car ID is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Define the connection string
            string connectionString = "Data Source=CIRCUITSORCERER\\SQLEXPRESS;Initial Catalog=dbSigned_Up;Integrated Security=True;";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Step 1: Fetch the last logged-in username from the LoggedIn table
                    string fetchLoggedInUserQuery = "SELECT TOP 1 Username FROM LoggedIn ORDER BY ID DESC"; 
                    string loggedInUsername = string.Empty;

                    using (SqlCommand fetchUserCommand = new SqlCommand(fetchLoggedInUserQuery, connection))
                    {
                        object result = fetchUserCommand.ExecuteScalar();
                        if (result != null)
                        {
                            loggedInUsername = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No logged-in user found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Step 2: Check if the rental record exists for the logged-in user and if the car has not been returned yet
                    string queryValidateReturn = @"
                        SELECT User_ID, Return_Date 
                        FROM Rental_Record 
                        WHERE Car_ID = @CarID AND User_ID = @UserID AND Return_Date IS NULL";

                    using (SqlCommand command = new SqlCommand(queryValidateReturn, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@CarID", inputCarId);
                        command.Parameters.AddWithValue("@UserID", loggedInUsername); // Use the fetched logged-in username

                        // Execute the query
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Car found and not yet returned
                                object returnDateObj = reader["Return_Date"];

                                // Ensure ReturnDate is NULL
                                if (returnDateObj == DBNull.Value)
                                {
                                    reader.Close();  // Close the reader before executing the update

                                    // Step 3: Update the ReturnDate to the current date
                                    string queryUpdateReturn = @"
                                        UPDATE Rental_Record 
                                        SET Return_Date = @ReturnDate 
                                        WHERE Car_ID = @CarID AND User_ID = @UserID AND Return_Date IS NULL";

                                    using (SqlCommand updateCommand = new SqlCommand(queryUpdateReturn, connection))
                                    {
                                        updateCommand.Parameters.AddWithValue("@CarID", inputCarId);
                                        updateCommand.Parameters.AddWithValue("@UserID", loggedInUsername); // Use the fetched logged-in username
                                        updateCommand.Parameters.AddWithValue("@ReturnDate", DateTime.Now); // Current date for ReturnDate

                                        int rowsAffected = updateCommand.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Car has been successfully returned!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Failed to update the return date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("This car has already been returned.", "Car Already Returned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No matching rental record found for the given Car ID and logged-in User.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
