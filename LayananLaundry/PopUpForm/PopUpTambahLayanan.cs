using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LayananLaundry.PopUpForm
{
    public partial class PopUpTambahLayanan : Form
    {
        public PopUpTambahLayanan()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopUpTambahLayanan_Load(object sender, EventArgs e)
        {
            DataCombox();
        }

        void DataCombox()
        {
            comboBox1.Items.Add("Kg");
            comboBox1.Items.Add("Pcs");
            comboBox1.Items.Add("Pasang");
            comboBox1.Items.Add("Meter");
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text.Trim()) || string.IsNullOrWhiteSpace(textBox3.Text.Trim()) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Semua box harus di isi!");
                return;
            }

            if(!decimal.TryParse(textBox3.Text.Trim(),out decimal harga))
            {
                MessageBox.Show("Harga harus berupa angka yang valid");
                return;
            }

            if(harga <= 0)
            {
                MessageBox.Show("harga lebih dari 0!");
                return;
            }

            if(textBox1.TextLength > 50)
            {
                MessageBox.Show("jenis tidak boleh lebih dari 50 karakter");
                return;
            }

            try
            {
                using (SqlConnection conn = Connection.GetConnection()) 
                {
                    conn.Open();

                    string query = "INSERT INTO layanan (jenis,satuan,harga) VALUES (@j,@s,@h)";
                    string QValidasi = "SELECT COUNT(*) FROM layanan WHERE jenis = @j";

                    using (SqlCommand CheckCmd = new SqlCommand(QValidasi, conn))
                    {
                        CheckCmd.Parameters.AddWithValue("@j", textBox1.Text.Trim());
                        int result = Convert.ToInt32(CheckCmd.ExecuteScalar());
                        if (result >= 1)
                        {
                            MessageBox.Show("Jenis layanan sudah terdaftar");
                            return;
                        }

                        using(SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@j", textBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@s",comboBox1.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@h", harga);
                            int Hasil = cmd.ExecuteNonQuery();
                            if(Hasil >= 1)
                            {
                                MessageBox.Show("Data Layanan Berhasil Ditambahkan");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Data Layanan Gagal Ditambahkan","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
