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
    public partial class GiveFeedback : Form
    {
        public GiveFeedback()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Fetch the feedback from textBox1
            string feedbackText = textBox1.Text.Trim();

            // Validate that feedback is not empty
            if (string.IsNullOrEmpty(feedbackText))
            {
                MessageBox.Show("Feedback cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Define the connection string
            string connectionString = "Data Source=CIRCUITSORCERER\\SQLEXPRESS;Initial Catalog=dbSigned_Up;Integrated Security=True;";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Fetch the Username from the LoggedIn table (the most recent logged-in user)
                    string fetchLoggedInUserQuery = "SELECT TOP 1 Username FROM LoggedIn ORDER BY ID DESC";
                    string loggedInUsername = string.Empty;

                    using (SqlCommand command = new SqlCommand(fetchLoggedInUserQuery, connection))
                    {
                        // Execute the query and get the username
                        object result = command.ExecuteScalar();

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

                    // Insert the feedback into the FEEDBACK table
                    string insertFeedbackQuery = "INSERT INTO FEEDBACK (Username, Feedback) VALUES (@Username, @Feedback)";

                    using (SqlCommand insertCommand = new SqlCommand(insertFeedbackQuery, connection))
                    {
                        // Add parameters to prevent SQL injection
                        insertCommand.Parameters.AddWithValue("@Username", loggedInUsername);
                        insertCommand.Parameters.AddWithValue("@Feedback", feedbackText);

                        // Execute the insert query
                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Feedback has been successfully submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit feedback.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
