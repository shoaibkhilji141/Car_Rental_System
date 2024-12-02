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
    public partial class RemoveCar : Form
    {
        public RemoveCar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=CIRCUITSORCERER\\SQLEXPRESS;Initial Catalog=dbSigned_Up;Integrated Security=True;";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string carID = textBox1.Text;
            string make = textBox2.Text;
            string model = textBox3.Text;
            string Query1 = "DELETE FROM Cars WHERE Car_ID = @CarID AND Make = @Make AND Model = @Model";
            SqlCommand cmd1 = new SqlCommand(Query1, con);
            cmd1.Parameters.AddWithValue("@CarID", carID);
            cmd1.Parameters.AddWithValue("@Make", make);
            cmd1.Parameters.AddWithValue("@Model", model);
            int rowsAffected = cmd1.ExecuteNonQuery();
            con.Close();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Car has been removed successfully.");
            }
            else
            {
                MessageBox.Show("No matching car found. Please check the Car ID, Make, or Model.");
            }

        }
    }
}
