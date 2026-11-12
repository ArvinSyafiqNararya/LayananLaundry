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
    public partial class PopUpEditPelanggan : Form
    {

        private int idPelanggan;
        bool statusAktif;

        public PopUpEditPelanggan(int id, string nama, string noHP, string alamat, bool status_aktif)
        {
            InitializeComponent();
            idPelanggan = id;

            textBox1.Text = nama;
            textBox2.Text = noHP;
            textBox3.Text = alamat;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Aktif");
            comboBox1.Items.Add("Nonaktif");

            if (status_aktif == true)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
        }

        private void PopUpEditPelanggan_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.Trim()) || string.IsNullOrWhiteSpace(textBox2.Text.Trim()))
            {
                MessageBox.Show("nama dan no hp wajib di isi!");
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Silahkan Pilih Status Pelanggan");
                return;
            }

            if (textBox1.TextLength > 100)
            {
                MessageBox.Show("nama tidak boleh lebih dari 100 karakter");
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

                    string checkQuery = "SELECT COUNT(*) FROM dbo.pelanggan WHERE no_hp = @np AND id_pelanggan <> @id";
                    string query = "UPDATE dbo.pelanggan SET nama = @n,no_hp = @np,alamat = @a,status_aktif = @sa WHERE id_pelanggan = @id";

                    using (SqlCommand CheckCmd = new SqlCommand(checkQuery, conn))
                    {

                        CheckCmd.Parameters.AddWithValue("@np", textBox2.Text.Trim());
                        CheckCmd.Parameters.AddWithValue("@id", idPelanggan);
                        int result = Convert.ToInt32(CheckCmd.ExecuteScalar());

                        if (result >= 1)
                        {
                            MessageBox.Show("Data dengan nomor hp ini sudah terdaftar. Silahkan gunakan no HP yang lain", "no HP sudah terdaftar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idPelanggan);
                        cmd.Parameters.AddWithValue("@n", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@np", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@a", textBox3.Text.Trim());

                        if (comboBox1.SelectedItem.ToString() == "Aktif")
                        {
                            statusAktif = true;
                        }
                        else
                        {
                            statusAktif = false;
                        }

                        cmd.Parameters.AddWithValue("@sa", statusAktif);

                        int result = cmd.ExecuteNonQuery();
                        if (result >= 1)
                        {
                            MessageBox.Show("Data berhasil di ubah");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Data gagal di ubah");
                            return;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
