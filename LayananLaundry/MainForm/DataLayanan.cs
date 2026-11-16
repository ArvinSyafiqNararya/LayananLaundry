using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using LayananLaundry.PopUpForm;
using Microsoft.Data.SqlClient;

namespace LayananLaundry.MainForm
{
    public partial class DataLayanan : Form
    {
        public DataLayanan()
        {
            InitializeComponent();
        }

        //Data
        private int id_layanan;
        private string jenis;
        private string satuan;
        private decimal harga;
        private bool status_aktif;

        private void timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo cl = new CultureInfo("id-ID");
            label3.Text = DateTime.Now.ToString("dddd,dd MMMM yyyy", cl);
            label4.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void DataLayanan_Load(object sender, EventArgs e)
        {
            timer1.Start();
            button6.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            DGVLayanan();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;

                id_layanan = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_layanan"].Value);
                jenis = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["jenis"].Value);
                satuan = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["satuan"].Value);
                harga = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["harga"].Value);
                status_aktif = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["status_aktif"].Value);

                button9.Enabled = true;

                if (status_aktif)
                {
                    button6.Enabled = true;
                    button8.Enabled = false;
                }
                else
                {
                    button6.Enabled = false;
                    button8.Enabled = true;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PopUpTambahLayanan popup = new PopUpTambahLayanan();
            popup.ShowDialog();
            DGVLayanan();

        }

        void DGVLayanan()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM layanan";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (id_layanan == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }

            DialogResult dg = MessageBox.Show("Apakah anda yakin ingin menonaktifkan data ini?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE layanan SET status_aktif = 0 WHERE id_layanan = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id_layanan);
                        int result = cmd.ExecuteNonQuery();
                        if (result >= 1)
                        {
                            MessageBox.Show("Data Berhasil Dinonaktifkan");
                            DGVLayanan();
                            id_layanan = 0;
                            button6.Enabled = false;
                            button8.Enabled = false;
                            button9.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Data layanan gagal dinonaktifkan");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (id_layanan == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }

            DialogResult dg = MessageBox.Show("Yakin ingin mengaktifkan data ini?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "UPDATE layanan SET status_aktif = 1 WHERE id_layanan = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id_layanan);
                        int result = cmd.ExecuteNonQuery();
                        if (result >= 1)
                        {
                            MessageBox.Show("Data Berhasil Diaktifkan");
                            DGVLayanan();
                            id_layanan = 0;
                            button6.Enabled = false;
                            button8.Enabled = false;
                            button9.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PopUpEditLayanan edit = new PopUpEditLayanan(id_layanan,jenis,satuan,harga,status_aktif);
            edit.ShowDialog();
            DGVLayanan();
            id_layanan = 0;
            button6.Enabled=false;
            button8.Enabled = false;
            button9.Enabled=false;
        }
    }
}
