namespace WinFormsApp1
{
    partial class RemoveCar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveCar));
            panel3 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            button1 = new Button();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Location = new Point(-4, 337);
            panel3.Name = "panel3";
            panel3.Size = new Size(632, 60);
            panel3.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(textBox2);
            panel2.Location = new Point(67, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(534, 263);
            panel2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.ForeColor = Color.FromArgb(186, 149, 79);
            label2.Location = new Point(84, 81);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 7;
            label2.Text = "Car_ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.ForeColor = Color.FromArgb(186, 149, 79);
            label4.Location = new Point(84, 144);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 8;
            label4.Text = "Model:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.ForeColor = Color.FromArgb(186, 149, 79);
            label3.Location = new Point(62, 112);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 8;
            label3.Text = "Car Brand:";
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
            button1.Location = new Point(275, 188);
            button1.Name = "button1";
            button1.Size = new Size(88, 48);
            button1.TabIndex = 13;
            button1.Text = "Remove";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(145, 140);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(218, 23);
            textBox3.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Location = new Point(146, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(218, 23);
            textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(145, 109);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(218, 23);
            textBox2.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-14, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(615, 52);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(186, 149, 79);
            label1.Location = new Point(200, 16);
            label1.Name = "label1";
            label1.Size = new Size(201, 36);
            label1.TabIndex = 0;
            label1.Text = "REMOVE CAR";
            // 
            // RemoveCar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(601, 392);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(601, 392);
            MinimumSize = new Size(601, 392);
            Name = "RemoveCar";
            Text = "RemoveCar";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Panel panel2;
        private Label label2;
        private Label label4;
        private Label label3;
        private Button button1;
        private TextBox textBox3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Panel panel1;
        private Label label1;
    }
}