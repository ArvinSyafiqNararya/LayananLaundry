using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using ClosedXML.Excel;

namespace LayananLaundry.MainForm
{
    public partial class Laporan : Form
    {
        public Laporan()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo cl = new CultureInfo("id-ID");
            label3.Text = DateTime.Now.ToString("dddd,dd MMMM yyyy", cl);
            label4.Text = DateTime.Now.ToString("HH:mm:ss", cl);
        }

        private void Laporan_Load(object sender, EventArgs e)
        {
            timer1.Start();
            pilihTanggal();


            comboBox1.Items.AddRange(new string[] { "Diterima", "Diproses", "Siap Diambil", "Sudah Diambil", "Semua status" });

            comboBox1.SelectedIndex = 4;
            dgvLaporan();
            ringkasan();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvLaporan();
            ringkasan();
        }

        private void dgvLaporan()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT t.kode_transaksi AS [Kode Transaksi],p.nama AS [Nama Pelanggan],u.username AS [Nama Kasir],t.tanggal_transaksi AS [Tanggal Transaksi],t.total_harga AS [Total Harga],t.status
                                     FROM transaksi t JOIN pelanggan p ON t.id_pelanggan = p.id_pelanggan JOIN users u ON t.id_users = u.id_users WHERE t.tanggal_transaksi >=@tawal AND t.tanggal_transaksi < DATEADD(DAY, 1,@takhir)";

                    if (comboBox1.Text != "Semua status")
                    {
                        query += "AND status = @s";
                    }
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tawal", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@takhir", dateTimePicker2.Value.Date);
                        if (comboBox1.Text != "Semua status")
                        {
                            cmd.Parameters.AddWithValue("@s", comboBox1.Text);
                        }

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
                MessageBox.Show("Terjadi kesalahan saat mengambil data DGV\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        void pilihTanggal()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MMMM yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd MMMM yyyy";

            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("id-ID");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("id-ID");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dgvLaporan();
            ringkasan();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dgvLaporan();
            ringkasan();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Yakin ingin mereset pencarian?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.No) return;

            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            comboBox1.SelectedIndex = 4;
            dgvLaporan();
            ringkasan();
        }

        void ringkasan()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) AS [total transaksi],ISNULL(SUM(total_harga),0) AS pendapatan,SUM(CASE WHEN status = 'Sudah Diambil' THEN 1 ELSE 0 END) AS selesai,SUM(CASE WHEN status = 'Diproses' THEN 1 ELSE 0 END)AS proses FROM transaksi WHERE tanggal_transaksi >=@tawal AND tanggal_transaksi < DATEADD(DAY,1,@takhir)";
                    if (comboBox1.Text != "Semua status")
                    {
                        query += "AND status = @s";
                    }
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tawal", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@takhir", dateTimePicker2.Value.Date);
                        if (comboBox1.Text != "Semua status")
                        {
                            cmd.Parameters.AddWithValue("@s", comboBox1.Text);
                        }

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                label10.Text = "Rp" + Convert.ToDecimal(rdr["pendapatan"]).ToString("N0");
                                label14.Text = rdr["total transaksi"].ToString();
                                label15.Text = rdr["selesai"].ToString();
                                label16.Text = rdr["proses"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengambil data ringkasan laporan\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "Excel Woorkbook|*.xlsx";
            save.FileName = "Laporan Layanan Laundry.xlsx";

            if (save.ShowDialog() != DialogResult.OK) return;

            using (XLWorkbook wb = new XLWorkbook())
            {
                var sheet = wb.Worksheets.Add("Laporan");

                //Header Column

                int kolom = 1;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (!dataGridView1.Columns[i].Visible) continue;

                    sheet.Cell(1, kolom).Value = dataGridView1.Columns[i].HeaderText;

                    kolom++;
                }

                //isi data

                int baris = 2;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    kolom = 1;

                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        if (!dataGridView1.Columns[i].Visible) continue;

                        sheet.Cell(baris, kolom).Value = row.Cells[i].FormattedValue?.ToString() ?? "";

                        kolom++;
                    }
                    baris++;
                }

                //format header
                var header = sheet.Range(1, 1, 1, kolom - 1);
                header.Style.Font.Bold = true;
                header.Style.Fill.BackgroundColor = XLColor.LightBlue;

                //Rapihkan kolom

                sheet.Columns().AdjustToContents();

                //aktifkan filter
                sheet.RangeUsed().SetAutoFilter();

                //simpan
                wb.SaveAs(save.FileName);

                MessageBox.Show("Laporan berhasil diekspor ke Excel");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transaksi transaksi = new Transaksi();
            transaksi.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataPelanggan dataPelanggan = new DataPelanggan();
            dataPelanggan.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataLayanan data = new DataLayanan();
            data.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            statusTransaksi status = new statusTransaksi();
            status.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
