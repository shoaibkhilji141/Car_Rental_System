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
using Microsoft.ReportingServices;


namespace WinFormsApp1
{
    public partial class MainFormAdmin : Form
    {
        public MainFormAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            AddCars addCarForm = new AddCars();
            addCarForm.TopLevel = false;
            addCarForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(addCarForm);
            addCarForm.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            RemoveCar RemoveCarForm = new RemoveCar();
            RemoveCarForm.TopLevel = false;
            RemoveCarForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(RemoveCarForm);
            RemoveCarForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            AllCars allCarForm = new AllCars();
            allCarForm.TopLevel = false;
            allCarForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(allCarForm);
            allCarForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            AvailableCars availableCarForm = new AvailableCars();
            availableCarForm.TopLevel = false;
            availableCarForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(availableCarForm);
            availableCarForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            AllUsers allusers = new AllUsers();
            allusers.TopLevel = false;
            allusers.Dock = DockStyle.Fill;
            panel3.Controls.Add(allusers);
            allusers.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            UsersRecords usersRecords = new UsersRecords();
            usersRecords.TopLevel = false;
            usersRecords.Dock = DockStyle.Fill;
            panel3.Controls.Add(usersRecords);
            usersRecords.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            ShowFeedback feedback = new ShowFeedback();
            feedback.TopLevel = false;
            feedback.Dock = DockStyle.Fill;
            panel3.Controls.Add(feedback);
            feedback.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            UpdateCars updateCars = new UpdateCars();
            updateCars.TopLevel = false;
            updateCars.Dock = DockStyle.Fill;
            panel3.Controls.Add(updateCars);
            updateCars.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog box
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // Navigate to the login form
                Login loginForm = new Login(); // Replace 'LoginForm' with the name of your login form class
                loginForm.Show(); // Show the login form
                this.Hide(); // Hide the current form (optional: close with `this.Close()`)
            }
            else
            {
                // Do nothing and remain on the current page
            }
        }
    }

}
