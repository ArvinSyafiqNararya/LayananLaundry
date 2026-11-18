namespace LayananLaundry.MainForm
{
    partial class Transaksi
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            button7 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            button6 = new Button();
            textBox3 = new TextBox();
            label8 = new Label();
            comboBox1 = new ComboBox();
            label7 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            toolTip1 = new ToolTip(components);
            panel4 = new Panel();
            groupBox2 = new GroupBox();
            textBox7 = new TextBox();
            button8 = new Button();
            textBox6 = new TextBox();
            label13 = new Label();
            textBox5 = new TextBox();
            label12 = new Label();
            label11 = new Label();
            textBox4 = new TextBox();
            label10 = new Label();
            comboBox2 = new ComboBox();
            label9 = new Label();
            panel5 = new Panel();
            groupBox3 = new GroupBox();
            dataGridView1 = new DataGridView();
            id_layanan = new DataGridViewTextBoxColumn();
            jenis = new DataGridViewTextBoxColumn();
            harga = new DataGridViewTextBoxColumn();
            satuan = new DataGridViewTextBoxColumn();
            qty = new DataGridViewTextBoxColumn();
            subtotal = new DataGridViewTextBoxColumn();
            panel6 = new Panel();
            button10 = new Button();
            button9 = new Button();
            panel7 = new Panel();
            button12 = new Button();
            button11 = new Button();
            groupBox4 = new GroupBox();
            label15 = new Label();
            label14 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            panel4.SuspendLayout();
            groupBox2.SuspendLayout();
            panel5.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(176, 661);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Bottom;
            button7.BackColor = Color.Red;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = SystemColors.Control;
            button7.Location = new Point(12, 601);
            button7.Name = "button7";
            button7.Size = new Size(153, 48);
            button7.TabIndex = 9;
            button7.Text = "Exit";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.HotTrack;
            button5.FlatAppearance.BorderColor = Color.White;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.Control;
            button5.Location = new Point(12, 303);
            button5.Name = "button5";
            button5.Size = new Size(153, 48);
            button5.TabIndex = 5;
            button5.Text = "Laporan";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.HotTrack;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.Control;
            button4.Location = new Point(13, 240);
            button4.Name = "button4";
            button4.Size = new Size(152, 48);
            button4.TabIndex = 4;
            button4.Text = "Layanan";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.HotTrack;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.Control;
            button3.Location = new Point(13, 176);
            button3.Name = "button3";
            button3.Size = new Size(152, 48);
            button3.TabIndex = 3;
            button3.Text = "Pelanggan";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.HotTrack;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(13, 118);
            button2.Name = "button2";
            button2.Size = new Size(152, 48);
            button2.TabIndex = 2;
            button2.Text = "Transaksi";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(13, 58);
            button1.Name = "button1";
            button1.Size = new Size(152, 48);
            button1.TabIndex = 1;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.AliceBlue;
            label1.Location = new Point(13, 8);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(152, 25);
            label1.TabIndex = 0;
            label1.Text = "MY LAUNDRY";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(176, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1008, 54);
            panel2.TabIndex = 3;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(922, 32);
            label4.Name = "label4";
            label4.Size = new Size(64, 18);
            label4.TabIndex = 3;
            label4.Text = "08:08:08";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(824, 9);
            label3.Name = "label3";
            label3.Size = new Size(125, 18);
            label3.TabIndex = 2;
            label3.Text = "rabu, 11 nov 2026";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 10);
            label2.Name = "label2";
            label2.Size = new Size(133, 31);
            label2.TabIndex = 0;
            label2.Text = "Transaksi";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(176, 54);
            panel3.Name = "panel3";
            panel3.Size = new Size(1008, 167);
            panel3.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1008, 167);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informasi Transaksi";
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Right;
            button6.BackColor = Color.DeepSkyBlue;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(675, 119);
            button6.Name = "button6";
            button6.Size = new Size(310, 39);
            button6.TabIndex = 8;
            button6.Text = "Tambah Data Pelanggan";
            toolTip1.SetToolTip(button6, "Tambah data pelanggan jika belum tersedia di daftar.");
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Right;
            textBox3.Location = new Point(673, 74);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(312, 26);
            textBox3.TabIndex = 7;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(566, 80);
            label8.Name = "label8";
            label8.Size = new Size(43, 16);
            label8.TabIndex = 6;
            label8.Text = "Kasir :";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Right;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(673, 31);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(312, 28);
            comboBox1.TabIndex = 5;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(566, 37);
            label7.Name = "label7";
            label7.Size = new Size(79, 16);
            label7.TabIndex = 4;
            label7.Text = "Pelanggan :";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(102, 74);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(302, 26);
            textBox2.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 80);
            label6.Name = "label6";
            label6.Size = new Size(64, 16);
            label6.TabIndex = 2;
            label6.Text = "Tanggal :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(102, 31);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(302, 26);
            textBox1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(7, 37);
            label5.Name = "label5";
            label5.Size = new Size(89, 16);
            label5.TabIndex = 0;
            label5.Text = "ID Transaksi :";
            // 
            // toolTip1
            // 
            toolTip1.Popup += toolTip1_Popup;
            // 
            // panel4
            // 
            panel4.Controls.Add(groupBox2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(176, 221);
            panel4.Name = "panel4";
            panel4.Size = new Size(1008, 118);
            panel4.TabIndex = 5;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox7);
            groupBox2.Controls.Add(button8);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(label9);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1008, 118);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tambah Layanan";
            // 
            // textBox7
            // 
            textBox7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox7.Location = new Point(504, 33);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(141, 26);
            textBox7.TabIndex = 19;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button8.BackColor = Color.DeepSkyBlue;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(743, 68);
            button8.Name = "button8";
            button8.Size = new Size(242, 38);
            button8.TabIndex = 18;
            button8.Text = "Tambah";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox6.Location = new Point(743, 33);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(242, 26);
            textBox6.TabIndex = 17;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(675, 39);
            label13.Name = "label13";
            label13.Size = new Size(62, 16);
            label13.TabIndex = 16;
            label13.Text = "Subtotal :";
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.None;
            textBox5.Location = new Point(504, 82);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(141, 26);
            textBox5.TabIndex = 15;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.None;
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(426, 86);
            label12.Name = "label12";
            label12.Size = new Size(56, 16);
            label12.TabIndex = 13;
            label12.Text = "Jumlah :";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(426, 39);
            label11.Name = "label11";
            label11.Size = new Size(55, 16);
            label11.TabIndex = 12;
            label11.Text = "Satuan :";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(105, 80);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(239, 26);
            textBox4.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(7, 82);
            label10.Name = "label10";
            label10.Size = new Size(51, 16);
            label10.TabIndex = 10;
            label10.Text = "Harga :";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(105, 33);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(239, 28);
            comboBox2.TabIndex = 9;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(7, 39);
            label9.Name = "label9";
            label9.Size = new Size(65, 16);
            label9.TabIndex = 1;
            label9.Text = "Layanan :";
            // 
            // panel5
            // 
            panel5.Controls.Add(groupBox3);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(176, 339);
            panel5.Name = "panel5";
            panel5.Size = new Size(1008, 143);
            panel5.TabIndex = 6;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1008, 143);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Detail Transaksi";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id_layanan, jenis, harga, satuan, qty, subtotal });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1002, 118);
            dataGridView1.TabIndex = 0;
            // 
            // id_layanan
            // 
            id_layanan.HeaderText = "ID layanan";
            id_layanan.Name = "id_layanan";
            id_layanan.ReadOnly = true;
            // 
            // jenis
            // 
            jenis.HeaderText = "Nama layanan";
            jenis.Name = "jenis";
            jenis.ReadOnly = true;
            // 
            // harga
            // 
            harga.HeaderText = "Harga";
            harga.Name = "harga";
            harga.ReadOnly = true;
            // 
            // satuan
            // 
            satuan.HeaderText = "Satuan";
            satuan.Name = "satuan";
            satuan.ReadOnly = true;
            // 
            // qty
            // 
            qty.HeaderText = "Jumlah";
            qty.Name = "qty";
            qty.ReadOnly = true;
            // 
            // subtotal
            // 
            subtotal.HeaderText = "Subtotal";
            subtotal.Name = "subtotal";
            subtotal.ReadOnly = true;
            // 
            // panel6
            // 
            panel6.Controls.Add(button10);
            panel6.Controls.Add(button9);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(176, 482);
            panel6.Name = "panel6";
            panel6.Size = new Size(1008, 60);
            panel6.TabIndex = 7;
            // 
            // button10
            // 
            button10.BackColor = Color.Red;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.ForeColor = SystemColors.Control;
            button10.Location = new Point(7, 7);
            button10.Name = "button10";
            button10.Size = new Size(148, 47);
            button10.TabIndex = 1;
            button10.Text = "Hapus Item";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.BackColor = SystemColors.ActiveBorder;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.ForeColor = SystemColors.Control;
            button9.Location = new Point(161, 7);
            button9.Name = "button9";
            button9.Size = new Size(148, 47);
            button9.TabIndex = 0;
            button9.Text = "Reset";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(button12);
            panel7.Controls.Add(button11);
            panel7.Controls.Add(groupBox4);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(176, 542);
            panel7.Name = "panel7";
            panel7.Size = new Size(1008, 119);
            panel7.TabIndex = 8;
            // 
            // button12
            // 
            button12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button12.BackColor = Color.ForestGreen;
            button12.FlatStyle = FlatStyle.Flat;
            button12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button12.ForeColor = SystemColors.Control;
            button12.Location = new Point(694, 38);
            button12.Name = "button12";
            button12.Size = new Size(155, 54);
            button12.TabIndex = 12;
            button12.Text = "Simpan Transaksi";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // button11
            // 
            button11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button11.BackColor = SystemColors.ActiveBorder;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.White;
            button11.Location = new Point(865, 37);
            button11.Name = "button11";
            button11.Size = new Size(128, 54);
            button11.TabIndex = 11;
            button11.Text = "Batal";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = SystemColors.GradientActiveCaption;
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(label14);
            groupBox4.Location = new Point(7, 23);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(602, 91);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(194, 29);
            label15.Name = "label15";
            label15.Size = new Size(80, 39);
            label15.TabIndex = 1;
            label15.Text = "Rp0";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(16, 34);
            label14.Name = "label14";
            label14.Size = new Size(172, 24);
            label14.TabIndex = 0;
            label14.Text = "Total Pembayaran :";
            // 
            // Transaksi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Transaksi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transaksi";
            Load += Transaksi_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel4.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel5.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private Label label4;
        private System.Windows.Forms.Timer timer1;
        private Panel panel3;
        private GroupBox groupBox1;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private Label label7;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label8;
        private ComboBox comboBox1;
        private Button button7;
        private Button button6;
        private ToolTip toolTip1;
        private Panel panel4;
        private GroupBox groupBox2;
        private Label label10;
        private ComboBox comboBox2;
        private Label label9;
        private Label label12;
        private Label label11;
        private TextBox textBox4;
        private Button button8;
        private Label label13;
        private TextBox textBox5;
        private Panel panel5;
        private GroupBox groupBox3;
        private DataGridView dataGridView1;
        private Panel panel6;
        private Button button10;
        private Button button9;
        private Panel panel7;
        private GroupBox groupBox4;
        private Label label14;
        private Label label15;
        private Button button12;
        private Button button11;
        private TextBox textBox7;
        private TextBox textBox6;
        private DataGridViewTextBoxColumn id_layanan;
        private DataGridViewTextBoxColumn jenis;
        private DataGridViewTextBoxColumn harga;
        private DataGridViewTextBoxColumn satuan;
        private DataGridViewTextBoxColumn qty;
        private DataGridViewTextBoxColumn subtotal;
    }
}