using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace LayananLaundry.MainForm
{
    public partial class statusTransaksi : Form
    {
        public statusTransaksi()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo cl = new CultureInfo("id-ID");
            label3.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", cl);
            label4.Text = DateTime.Now.ToString("HH:mm:ss", cl);
        }

        private void statusTransaksi_Load(object sender, EventArgs e)
        {
            timer1.Start();
            DGV();
            button9.Enabled = false;
            comboBox1.Items.AddRange(new string[] { "Diterima", "Diproses", "Siap Diambil", "Sudah Diambil"});
        }

        void DGV()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT id_transaksi,kode_transaksi AS [Kode Transaksi],tanggal_transaksi AS [Tanggal Transaksi], u.username AS [kasir],p.nama AS [pelanggan],status
                                     FROM transaksi t JOIN users u ON t.id_users = u.id_users JOIN pelanggan p ON t.id_pelanggan = p.id_pelanggan";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            dt.Clear();
                            da.Fill(dt);

                            dataGridView1.DataSource = dt;
                            dataGridView1.Columns["id_transaksi"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data DGV\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //id
        int idTransaksi;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Kode Transaksi"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Tanggal Transaksi"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["kasir"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["pelanggan"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();
                idTransaksi = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_transaksi"].Value);
                button9.Enabled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text.Trim()) || string.IsNullOrWhiteSpace(textBox2.Text.Trim()) || string.IsNullOrWhiteSpace(textBox3.Text.Trim()) || string.IsNullOrWhiteSpace(textBox4.Text.Trim()) || string.IsNullOrWhiteSpace(textBox5.Text.Trim()) || string.IsNullOrWhiteSpace(comboBox1.Text.Trim()))
            {
                MessageBox.Show("Semua Box Harus Terisi!");
                return;
            }

            try
            {
                using(SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "UPDATE transaksi SET status = @s WHERE id_transaksi = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn)) 
                    {
                        cmd.Parameters.AddWithValue("@s", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@id", idTransaksi);
                        int result = cmd.ExecuteNonQuery();

                        if(result >= 1)
                        {
                            MessageBox.Show("Data Berhasil Diubah");
                            DGV();
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            comboBox1.SelectedIndex = -1;
                        }


                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memperbarui data\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
