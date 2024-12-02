namespace WinFormsApp1
{
    partial class UpdateCars
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateCars));
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            button1 = new Button();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            textBox4 = new TextBox();
            textBox2 = new TextBox();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-8, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(616, 75);
            panel1.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(186, 149, 79);
            label1.Location = new Point(201, 27);
            label1.Name = "label1";
            label1.Size = new Size(187, 36);
            label1.TabIndex = 0;
            label1.Text = "UPDATE CAR";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(textBox2);
            panel2.Location = new Point(96, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(395, 263);
            panel2.TabIndex = 18;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarForeColor = Color.FromArgb(186, 149, 79);
            dateTimePicker1.CalendarMonthBackground = Color.FromArgb(186, 149, 79);
            dateTimePicker1.CalendarTitleBackColor = Color.FromArgb(186, 149, 79);
            dateTimePicker1.CalendarTitleForeColor = Color.FromArgb(186, 149, 79);
            dateTimePicker1.CalendarTrailingForeColor = Color.FromArgb(186, 149, 79);
            dateTimePicker1.Location = new Point(162, 149);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.ForeColor = Color.FromArgb(186, 149, 79);
            label2.Location = new Point(0, 26);
            label2.Name = "label2";
            label2.Size = new Size(162, 20);
            label2.TabIndex = 7;
            label2.Text = "Enter Car_ID to update:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(186, 149, 79);
            label6.Location = new Point(32, 119);
            label6.Name = "label6";
            label6.Size = new Size(124, 20);
            label6.TabIndex = 8;
            label6.Text = "New Rental Price:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.ForeColor = Color.FromArgb(186, 149, 79);
            label5.Location = new Point(-5, 148);
            label5.Name = "label5";
            label5.Size = new Size(161, 20);
            label5.TabIndex = 8;
            label5.Text = "New Manufacture Year:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.ForeColor = Color.FromArgb(186, 149, 79);
            label4.Location = new Point(67, 89);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 8;
            label4.Text = "New Model:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.ForeColor = Color.FromArgb(186, 149, 79);
            label3.Location = new Point(45, 58);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 8;
            label3.Text = "New Car Brand:";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(17, 205, 239);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.White;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            button1.Location = new Point(292, 184);
            button1.Name = "button1";
            button1.Size = new Size(88, 48);
            button1.TabIndex = 13;
            button1.Text = "UPDATE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(162, 86);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(218, 23);
            textBox3.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Location = new Point(163, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(218, 23);
            textBox1.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(162, 117);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(218, 23);
            textBox4.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(162, 55);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(218, 23);
            textBox2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Location = new Point(0, 341);
            panel3.Name = "panel3";
            panel3.Size = new Size(608, 91);
            panel3.TabIndex = 15;
            // 
            // UpdateCars
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(601, 406);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(601, 406);
            MinimumSize = new Size(601, 406);
            Name = "UpdateCars";
            Text = "UpdateCars";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button button1;
        private TextBox textBox3;
        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox textBox2;
        private Panel panel3;
    }
}