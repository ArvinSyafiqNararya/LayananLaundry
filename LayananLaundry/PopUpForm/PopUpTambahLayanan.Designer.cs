namespace LayananLaundry.PopUpForm
{
    partial class PopUpTambahLayanan
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
            label1 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(289, 31);
            label1.TabIndex = 0;
            label1.Text = "Tambah Data Layanan";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 80);
            label3.Name = "label3";
            label3.Size = new Size(130, 24);
            label3.TabIndex = 2;
            label3.Text = "Jenis Layanan";
            label3.Click += label3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 107);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Contoh: Cuci Kering";
            textBox1.Size = new Size(460, 23);
            textBox1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 149);
            label4.Name = "label4";
            label4.Size = new Size(144, 24);
            label4.TabIndex = 5;
            label4.Text = "Satuan Layanan";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 176);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(144, 23);
            comboBox1.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 220);
            label5.Name = "label5";
            label5.Size = new Size(61, 24);
            label5.TabIndex = 7;
            label5.Text = "Harga";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 256);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "10000";
            textBox3.Size = new Size(460, 23);
            textBox3.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(338, 325);
            button1.Name = "button1";
            button1.Size = new Size(134, 44);
            button1.TabIndex = 9;
            button1.Text = "Batal";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightSkyBlue;
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(198, 325);
            button2.Name = "button2";
            button2.Size = new Size(134, 44);
            button2.TabIndex = 10;
            button2.Text = "Simpan";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // PopUpTambahLayanan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 379);
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
            Name = "PopUpTambahLayanan";
            Text = "Tambah Layanan";
            Load += PopUpTambahLayanan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private ComboBox comboBox1;
        private Label label5;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
    }
}