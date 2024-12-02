using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainFormUser : Form
    {
        public MainFormUser()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            RentCar rentCarForm = new RentCar();
            rentCarForm.TopLevel = false;
            rentCarForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(rentCarForm);
            rentCarForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            ReturnCar returnCarForm = new ReturnCar();
            returnCarForm.TopLevel = false;
            returnCarForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(returnCarForm);
            returnCarForm.Show();
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
            GiveFeedback feedbackForm = new GiveFeedback();
            feedbackForm.TopLevel = false;
            feedbackForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(feedbackForm);
            feedbackForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            UserRecord userRecord = new UserRecord();
            userRecord.TopLevel = false;
            userRecord.Dock = DockStyle.Fill;
            panel3.Controls.Add(userRecord);
            userRecord.Show();
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
