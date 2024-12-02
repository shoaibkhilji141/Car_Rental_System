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
    public partial class AddCars : Form
    {
        public AddCars()
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
            int price = int.Parse(textBox4.Text);
            DateTime year = dateTimePicker1.Value;
            string Query1 = "INSERT INTO Cars (Car_ID, Make, Model, Price, Year) VALUES (@CarID, @Make, @Model, @Price, @Year)";
            SqlCommand cmd1 = new SqlCommand(Query1, con);
            cmd1.Parameters.AddWithValue("@CarID", carID);
            cmd1.Parameters.AddWithValue("@Make", make);
            cmd1.Parameters.AddWithValue("@Model", model);
            cmd1.Parameters.AddWithValue("@Price", price);
            cmd1.Parameters.AddWithValue("@Year", year);
            cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Car details have been added successfully.");

        }
    }
}
