using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace LayananLaundry.MainForm
{
    public partial class DataPelanggan : Form
    {
        public DataPelanggan()
        {
            InitializeComponent();
        }

        //idPelanggan dan status aktif
        private int idPelanggan;
        private bool status_aktif;

        private void timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo cl = new CultureInfo("id-ID");
            label3.Text = DateTime.Now.ToString("dddd,dd MMMM yyyy", cl);
            label4.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void DataPelanggan_Load(object sender, EventArgs e)
        {
            timer1.Start();
            DGVPelanggan();
            button6.Enabled = false;
            button8.Enabled = false;
        }

        void DGVPelanggan()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM dbo.pelanggan";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            dt.Clear();
                            da.Fill(dt);

                            dataGridView1.DataSource = dt;
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (idPelanggan == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu!");
                return;
            }

            DialogResult dg = MessageBox.Show("Yakin mau nonaktifkan data ini?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dg == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "UPDATE FROM dbo.pelanggan SET status_aktif = 0 WHERE id_pelanggan = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idPelanggan);
                        int result = cmd.ExecuteNonQuery();
                        if (result >= 1)
                        {
                            MessageBox.Show("Pelanggan berhasil di nonaktifkan");
                            idPelanggan = 0;
                            DGVPelanggan();
                            button6.Enabled = false;
                            button8.Enabled = false;

                        }
                        else
                        {
                            MessageBox.Show("Data gagal dinonaktifkan");
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;

                idPelanggan = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_pelanggan"].Value);
                status_aktif = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["status_aktif"].Value);

                if (status_aktif)
                {
                    button6.Enabled = true;
                    button8.Enabled = false;
                }
                else
                {
                    button8.Enabled = true;
                    button6.Enabled = false;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(idPelanggan == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }

            DialogResult dg = MessageBox.Show("Yakin mau hapus data ini?","Confirm",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.No) return;

            try
            {
                using(SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE FROM dbo.pelanggan SET status_aktif = 1 WHERE id_pelanggan = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn)) 
                    {
                        cmd.Parameters.AddWithValue("@id", idPelanggan);
                        int result = cmd.ExecuteNonQuery();
                        if (result >= 1)
                        {
                            MessageBox.Show("Data berhasil di aktifkan");
                            idPelanggan = 0;
                            DGVPelanggan();
                            button6.Enabled=false;
                            button8.Enabled=false;

                        }
                        else
                        {
                            MessageBox.Show("Data gagal dinonaktifkan");
                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error\n" +ex.Message,"ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
