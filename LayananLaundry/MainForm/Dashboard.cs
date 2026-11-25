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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            dataTransaksi();
            dataTotalPelanggan();
            PendapatanHariIni();
            totalLayanan();
            DGVtransaksi();
            izin();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo cl = new CultureInfo("id-ID");
            label3.Text = DateTime.Now.ToString("dddd,dd MMMM yyyy", cl);
            label4.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //Session
            void izin()
            {
                bool admin = Session.role == "admin";
                button3.Enabled = admin;
                button4.Enabled = admin;
                button5.Enabled = admin;
            }

        void dataTransaksi()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM dbo.transaksi";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int total = Convert.ToInt32(cmd.ExecuteScalar());
                        label5.Text = total.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void dataTotalPelanggan()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM dbo.pelanggan";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int total = Convert.ToInt32(cmd.ExecuteScalar());
                        label6.Text = total.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void totalLayanan()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM dbo.layanan";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int total = Convert.ToInt32(cmd.ExecuteScalar());
                        label7.Text = total.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void PendapatanHariIni()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT COALESCE(SUM(total_harga),0) FROM dbo.transaksi WHERE CAST(tanggal_transaksi AS DATE) = CAST(GETDATE() AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        decimal pendapatan = Convert.ToDecimal(cmd.ExecuteScalar());

                        label8.Text = pendapatan.ToString("C0", new System.Globalization.CultureInfo("id-ID"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void DGVtransaksi()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT TOP 5 t.id_transaksi,t.tanggal_transaksi,p.nama AS nama_pelanggan,t.total_harga,t.status FROM dbo.transaksi t INNER JOIN dbo.pelanggan p ON t.id_pelanggan = p.id_pelanggan ORDER BY t.id_transaksi DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transaksi transaksi = new Transaksi();
            transaksi.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataPelanggan dp = new DataPelanggan();
            dp.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataLayanan dl = new DataLayanan();
            dl.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Session.username = null;
            Session.role = null;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            statusTransaksi status = new statusTransaksi();
            status.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Laporan laporan = new Laporan();
            laporan.Show();
            this.Close();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Session.username = null;
            Session.role = null;
        }
    }
}
