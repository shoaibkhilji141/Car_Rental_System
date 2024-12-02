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
    

    public partial class SignUp : Form
    {
        public string UserId
        {
            get { return textBox1.Text.Trim(); }
        }

        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=localhost;Initial Catalog=dbSigned_Up;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string Query = "SELECT COUNT(*) FROM Persons WHERE Username= @FirstName";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
            int count = (int)cmd.ExecuteScalar();
            if (count == 0)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    string connectionString = "Data Source=CIRCUITSORCERER\\SQLEXPRESS;Initial Catalog=dbSigned_Up;Integrated Security=True;";
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    string username = textBox1.Text;
                    string password = textBox2.Text;
                    string gender = comboBox1.Text;
                    string Contact = textBox4.Text;
                    string Query1 = "Insert into persons(Username, password, Gender, Contact) values('" + username + "', '" + password + "', '" + gender + "', '" + Contact + "')";
                    SqlCommand cmd1 = new SqlCommand(Query1, con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("You are Signed-up, Now go to the Login Page.");
                }
                else
                {
                    MessageBox.Show("Password doesn't match!");
                }
            }
            else
            {
                MessageBox.Show("The User is already Registered");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
