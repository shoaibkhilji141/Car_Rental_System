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
    public partial class UpdateCars : Form
    {
        public UpdateCars()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Fetch input values from the user
            string inputCarId = textBox1.Text.Trim(); // Car_ID
            string inputBrand = textBox2.Text.Trim(); // Brand
            string inputModel = textBox3.Text.Trim(); // Model
            string inputRentalPrice = textBox4.Text.Trim(); // Rental Price
            DateTime inputManufacturingYear = dateTimePicker1.Value; // Manufacturing Year

            // Validate that required fields are not empty
            if (string.IsNullOrEmpty(inputCarId) || string.IsNullOrEmpty(inputBrand) ||
                string.IsNullOrEmpty(inputModel) || string.IsNullOrEmpty(inputRentalPrice))
            {
                MessageBox.Show("All fields must be filled in!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Define the connection string
            string connectionString = "Data Source=CIRCUITSORCERER\\SQLEXPRESS;Initial Catalog=dbSigned_Up;Integrated Security=True;";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Check if the Car_ID exists in the Cars table
                    string queryCheckCarId = "SELECT COUNT(*) FROM Cars WHERE Car_ID = @CarID";
                    using (SqlCommand checkCommand = new SqlCommand(queryCheckCarId, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@CarID", inputCarId);

                        int carExists = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (carExists > 0)
                        {
                            // Update the car details if the Car_ID exists
                            string queryUpdateCar = @"
                        UPDATE Cars 
                        SET Make = @Brand, 
                            Model = @Model, 
                            Price = @RentalPrice, 
                            Year = @ManufacturingYear
                        WHERE Car_ID = @CarID";

                            using (SqlCommand updateCommand = new SqlCommand(queryUpdateCar, connection))
                            {
                                // Add parameters to avoid SQL injection
                                updateCommand.Parameters.AddWithValue("@CarID", inputCarId);
                                updateCommand.Parameters.AddWithValue("@Brand", inputBrand);
                                updateCommand.Parameters.AddWithValue("@Model", inputModel);
                                updateCommand.Parameters.AddWithValue("@RentalPrice", inputRentalPrice);
                                updateCommand.Parameters.AddWithValue("@ManufacturingYear", inputManufacturingYear);

                                // Execute the update command
                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Car details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Failed to update car details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            // Show a message if the Car_ID does not exist
                            MessageBox.Show("Car ID not found in the Cars table!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
