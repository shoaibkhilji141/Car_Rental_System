using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "1234")
            {
                MainFormAdmin formAdmin = new MainFormAdmin();
                formAdmin.Show();
                this.Hide();
            }
            else
            {
                string connectionString = "Data Source=CIRCUITSORCERER\\SQLEXPRESS;Initial Catalog=dbSigned_Up;Integrated Security=True;";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Open connection
                        con.Open();

                        // Prepare SELECT query to check user credentials
                        string query = "SELECT COUNT(*) FROM Persons WHERE Username = @Username AND Password = @Password";
                        SqlCommand cmd = new SqlCommand(query, con);

                        // Add parameters
                        cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", textBox2.Text.Trim());

                        // Execute query and check the result
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            // Insert into LoggedIn table
                            string insertQuery = "INSERT INTO LoggedIn (Username) VALUES (@Username)";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                            insertCmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                            insertCmd.ExecuteNonQuery();

                            // Redirect to user main form
                            MainFormUser userForm = new MainFormUser();
                            userForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Show error message
                            MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle SQL or other errors
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp page = new SignUp();
            page.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Custom paint logic (if needed)
        }
    }
}
