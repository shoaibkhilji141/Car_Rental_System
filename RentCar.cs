using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class RentCar : Form
    {
        public RentCar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Fetch car inputs
            string inputCarId = textBox1.Text.Trim();
            string inputBrand = textBox2.Text.Trim();
            string inputModel = textBox3.Text.Trim();
            int rentalHours = Convert.ToInt32(numericUpDown1.Value);
            int rentalPrice = 0;

            // Validate that car fields are not empty
            if (string.IsNullOrEmpty(inputCarId) || string.IsNullOrEmpty(inputBrand) || string.IsNullOrEmpty(inputModel))
            {
                MessageBox.Show("All car fields must be filled in!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Define connection string
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

                    // Step 2: Validate car information
                    string queryValidateCar = @"
                        SELECT Availability, Price 
                        FROM Cars 
                        WHERE Car_ID = @CarID AND Make = @Brand AND Model = @Model";

                    using (SqlCommand validateCarCommand = new SqlCommand(queryValidateCar, connection))
                    {
                        validateCarCommand.Parameters.AddWithValue("@CarID", inputCarId);
                        validateCarCommand.Parameters.AddWithValue("@Brand", inputBrand);
                        validateCarCommand.Parameters.AddWithValue("@Model", inputModel);

                        using (SqlDataReader reader = validateCarCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool isAvailable = Convert.ToBoolean(reader["Availability"]);
                                rentalPrice = Convert.ToInt32(reader["Price"]);

                                if (isAvailable)
                                {
                                    reader.Close();

                                    // Step 3: Insert rental details into the Rental_Record table
                                    string queryInsertRental = @"
                                        INSERT INTO Rental_Record (Car_ID, User_ID, Rental_Date, Total_Price, Return_Date, REntal_Hours)
                                        VALUES (@CarID, @UserID, @RentalDate, @TotalPrice, @ReturnDate, @RentalHours)";

                                    using (SqlCommand insertRentalCommand = new SqlCommand(queryInsertRental, connection))
                                    {
                                        insertRentalCommand.Parameters.AddWithValue("@CarID", inputCarId);
                                        insertRentalCommand.Parameters.AddWithValue("@UserID", loggedInUsername); // Use fetched username
                                        insertRentalCommand.Parameters.AddWithValue("@RentalDate", DateTime.Now); // Current date for Rental_Date
                                        insertRentalCommand.Parameters.AddWithValue("@TotalPrice", rentalPrice * rentalHours);
                                        insertRentalCommand.Parameters.AddWithValue("@ReturnDate", DBNull.Value); // No return date yet
                                        insertRentalCommand.Parameters.AddWithValue("@RentalHours", rentalHours);

                                        int rowsAffected = insertRentalCommand.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            // Step 4: Update car availability
                                            string queryUpdateAvailability = "UPDATE Cars SET Availability = 0 WHERE Car_ID = @CarID";

                                            using (SqlCommand updateCarCommand = new SqlCommand(queryUpdateAvailability, connection))
                                            {
                                                updateCarCommand.Parameters.AddWithValue("@CarID", inputCarId);
                                                int carUpdateRows = updateCarCommand.ExecuteNonQuery();

                                                if (carUpdateRows > 0)
                                                {
                                                    MessageBox.Show("Car has been successfully rented and rental record saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Failed to update car availability.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Failed to save rental record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The car is already rented!", "Car Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Car information does not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
