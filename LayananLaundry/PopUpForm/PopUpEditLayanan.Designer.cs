namespace LayananLaundry.PopUpForm
{
    partial class PopUpEditLayanan
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
            button2 = new Button();
            button1 = new Button();
            textBox3 = new TextBox();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Gold;
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(206, 399);
            button2.Name = "button2";
            button2.Size = new Size(134, 44);
            button2.TabIndex = 19;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(346, 399);
            button1.Name = "button1";
            button1.Size = new Size(134, 44);
            button1.TabIndex = 18;
            button1.Text = "Batal";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 256);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "10000";
            textBox3.Size = new Size(460, 23);
            textBox3.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 220);
            label5.Name = "label5";
            label5.Size = new Size(61, 24);
            label5.TabIndex = 16;
            label5.Text = "Harga";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 176);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(144, 23);
            comboBox1.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 149);
            label4.Name = "label4";
            label4.Size = new Size(144, 24);
            label4.TabIndex = 14;
            label4.Text = "Satuan Layanan";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 107);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Contoh: Cuci Kering";
            textBox1.Size = new Size(460, 23);
            textBox1.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 80);
            label3.Name = "label3";
            label3.Size = new Size(130, 24);
            label3.TabIndex = 12;
            label3.Text = "Jenis Layanan";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(237, 31);
            label1.TabIndex = 11;
            label1.Text = "Edit Data Layanan";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 302);
            label2.Name = "label2";
            label2.Size = new Size(60, 24);
            label2.TabIndex = 20;
            label2.Text = "Status";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 329);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(144, 23);
            comboBox2.TabIndex = 21;
            // 
            // PopUpEditLayanan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 455);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "PopUpEditLayanan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PopUpEditLayanan";
            Load += PopUpEditLayanan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private TextBox textBox3;
        private Label label5;
        private ComboBox comboBox1;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private Label label1;
        private Label label2;
        private ComboBox comboBox2;
    }
}