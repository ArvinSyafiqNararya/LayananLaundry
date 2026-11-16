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
    public partial class PopUpEditLayanan : Form
    {
        int id_layanan;
        bool status_aktif;

        public PopUpEditLayanan(int id, string jenis, string satuan, decimal harga, bool status_aktif)
        {
            InitializeComponent();
            Combox();
            id_layanan = id;
            textBox1.Text = jenis;
            comboBox1.SelectedItem = satuan;
            textBox3.Text = harga.ToString();
            comboBox2.Items.Add("Aktif");
            comboBox2.Items.Add("Nonaktif");
            

            if (status_aktif)
            {
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                comboBox2.SelectedIndex = 1;
            }
        }

        void Combox()
        {
            comboBox1.Items.Add("Kg");
            comboBox1.Items.Add("Pcs");
            comboBox1.Items.Add("Pasang");
            comboBox1.Items.Add("Meter");
        }

        private void PopUpEditLayanan_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.Trim()) || string.IsNullOrWhiteSpace(textBox3.Text.Trim()) || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("semua box harus terisi!");
                return;
            }

            if (!decimal.TryParse(textBox3.Text.Trim(), out decimal harga)) 
            {
                MessageBox.Show("harga harus berupa angka yang valid");
                return;
            }

            if(harga <= 0)
            {
                MessageBox.Show("harga harus lebih dari 0");
                return; 
            }

            if(textBox1.TextLength > 50)
            {
                MessageBox.Show("jenis tidak boleh lebih dari 50 karakter");
                return;
            }

            try
            {
                using(SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM layanan WHERE jenis = @j AND id_layanan <> @id";
                    string query = "UPDATE layanan SET jenis = @j,satuan = @s,harga = @h,status_aktif = @sa WHERE id_layanan = @id";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@j", textBox1.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@id", id_layanan);
                        int result = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if(result >= 1)
                        {
                            MessageBox.Show("jenis sudah terdaftar di database gunakan nama yang lain");
                            return;
                        }
                    }

                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id_layanan);
                        cmd.Parameters.AddWithValue("@j", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@s",comboBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@h", harga);
                        if(comboBox2.SelectedItem.ToString() == "Aktif")
                        {
                            status_aktif = true;
                        }
                        else
                        {
                            status_aktif= false;
                        }
                        cmd.Parameters.AddWithValue("@sa", status_aktif);

                        int result = cmd.ExecuteNonQuery();

                        if(result >= 1)
                        {
                            MessageBox.Show("data berhasil di ubah");
                            
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("data gagal diubah");
                            return;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
