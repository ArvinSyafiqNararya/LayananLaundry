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
    public partial class PopUpTambahPelanggan : Form
    {
        public PopUpTambahPelanggan()
        {
            InitializeComponent();
        }

        private void PopUpTambahPelanggan_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text.Trim();
            string noHp = textBox2.Text.Trim();
            string alamat = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(noHp))
            {
                MessageBox.Show("nama dan noHP wajib di isi!");
                return;
            }

            if (textBox1.TextLength > 100)
            {
                MessageBox.Show("nama pelanggan tidak boleh lebih dari 100 karakter");
                return;
            }

            if (textBox2.TextLength > 15)
            {
                MessageBox.Show("no hp tidak boleh lebih dari 15 karakter");
                return;
            }

            if (textBox3.TextLength > 255)
            {
                MessageBox.Show("alamat tidak boleh lebih dari 255 karakter");
                return;
            }

            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "INSERT INTO dbo.pelanggan(nama,no_hp,alamat) VALUES(@n,@np,@a)";
                    string checkQuery = "SELECT COUNT(*) FROM dbo.pelanggan WHERE no_hp = @np";

                    using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@np", noHp);
                        int result = Convert.ToInt32(cmd.ExecuteScalar());
                        if (result >= 1)
                        {
                            MessageBox.Show("Data dengan nomor hp ini sudah terdaftar. Silahkan gunakan no HP yang lain", "no HP sudah terdaftar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@n", nama);
                        cmd.Parameters.AddWithValue("@np", noHp);
                        cmd.Parameters.AddWithValue("@a", alamat);

                        int result = cmd.ExecuteNonQuery();
                        if (result >= 1)
                        {
                            MessageBox.Show("Data Berhasil di tambahkan");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Data Gagal Ditambahkan");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
