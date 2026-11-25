using LayananLaundry.PopUpForm;
using Microsoft.Data.Sql;
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
    public partial class Transaksi : Form
    {
        public Transaksi()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo cl = new CultureInfo("id-ID");
            label3.Text = DateTime.Now.ToString("dddd,dd MMMM yyyy", cl);
            label4.Text = DateTime.Now.ToString("HH:mm:ss", cl);
        }

        private void Transaksi_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Tanggal();
            kasir();
            pelanggan();
            idTransaksi();
            layanan();
            total();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        void Tanggal()
        {
            CultureInfo cl = new CultureInfo("id-ID");
            textBox2.Text = DateTime.Now.ToString("dddd,dd MMMM yyyy", cl);
        }

        void kasir()
        {
            textBox3.Text = Session.username;
        }

        void pelanggan()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT id_pelanggan,nama FROM dbo.pelanggan WHERE status_aktif = 1";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        da.Fill(dt);
                        comboBox1.DataSource = dt;
                        comboBox1.DisplayMember = "nama";
                        comboBox1.ValueMember = "id_pelanggan";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error di data pelanggan\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PopUpTambahPelanggan popUp = new PopUpTambahPelanggan();

            if (popUp.ShowDialog() == DialogResult.OK)
            {
                pelanggan();

                comboBox1.SelectedValue = popUp.idPelangganBaru;
            }
        }

        void idTransaksi()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT ISNULL(MAX(id_transaksi),0) + 1 FROM dbo.transaksi";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int id = Convert.ToInt32(cmd.ExecuteScalar());

                        textBox1.Text = "TRX" + id.ToString("D4");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat mengambil idtransaksi\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem is DataRowView row)
            {
                textBox4.Text = Convert.ToDecimal(row["harga"]).ToString("N0");
                textBox7.Text = row["satuan"].ToString();
            }
            else
            {
                textBox4.Clear();
                textBox7.Clear();
            }
        }

        void layanan()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT id_layanan,jenis,harga,satuan FROM layanan WHERE status_aktif = 1";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        da.Fill(dt);

                        comboBox2.DataSource = dt;
                        comboBox2.DisplayMember = "jenis";
                        comboBox2.ValueMember = "id_layanan";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal saat mengambil data layanan\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox5.Text.Trim()) || string.IsNullOrWhiteSpace(textBox4.Text.Trim()))
            {
                textBox6.Clear();
                return;
            }

            decimal harga = Convert.ToDecimal(textBox4.Text);
            decimal jumlah = Convert.ToDecimal(textBox5.Text);
            decimal subtotal = harga * jumlah;
            textBox6.Text = subtotal.ToString("N0");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Pilih layanan terlebih dahulu");
                return;
            }

            if (!decimal.TryParse(textBox5.Text, out decimal jumlah) || jumlah <= 0)
            {
                MessageBox.Show("Masukan jumlah yang benar");
                return;
            }

            DataRowView row = (DataRowView)comboBox2.SelectedItem;

            int idLayanan = Convert.ToInt32(row["id_layanan"]);
            string jenis = row["jenis"].ToString();
            decimal harga = Convert.ToDecimal(row["harga"]);
            string satuan = row["satuan"].ToString();

            decimal subtotal = harga * jumlah;

            dataGridView1.Rows.Add
                (
                    idLayanan, jenis, harga, satuan, jumlah, subtotal
                );
            total();

            comboBox2.SelectedIndex = -1;
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("pilih data yang ingin dihapus terlebih dahulu");
                return;
            }

            DialogResult dg = MessageBox.Show("Yakin ingin menghapus data ini?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.No) { return; }
            else
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                total();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus terlebih dahulu");
                return;
            }

            DialogResult dg = MessageBox.Show("Yakin ingin menghapus semua data di tabel?", "Konfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.No) { return; }
            else { dataGridView1.Rows.Clear(); total(); }
        }

        void total()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToDecimal(row.Cells["subtotal"].Value);
            }

            label15.Text = "Rp" + total.ToString("N0");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Yakin ingin membatalkan transaksi ini?", "Konfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.No) { return; }
            else { dataGridView1.Rows.Clear(); total(); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //cek pelanggan
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Pelanggan tidak ditemukan! Pilih pelanggan dari daftar.");
                comboBox1.Focus();
                return;
            }

            //cek dgv
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Tambahkan layanan terlebih dahulu");
                return;
            }

            int idPelanggan = Convert.ToInt32(comboBox1.SelectedValue);
            decimal totalHarga = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                totalHarga += Convert.ToDecimal(row.Cells[5].Value);
            }
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            string queryUser = "SELECT id_users FROM dbo.users WHERE username = @u";
                            string queryTransaksi = "INSERT INTO dbo.transaksi(id_pelanggan,id_users,total_harga,kode_transaksi) VALUES (@p,@u,@t,@k) SELECT CAST(SCOPE_IDENTITY() AS INT)";
                            string queryDetail = "INSERT INTO detail_transaksi(id_transaksi,id_layanan,qty,harga_satuan,subtotal) VALUES(@idT,@l,@qty,@h,@s)";
                            int idUser;
                            int idtransaksiTerbaru;

                            //users atau kasir
                            using (SqlCommand cmdUsers = new SqlCommand(queryUser, conn, trans))
                            {
                                cmdUsers.Parameters.AddWithValue("@u", Session.username);
                                idUser = Convert.ToInt32(cmdUsers.ExecuteScalar());
                            }

                            //transaksiTerbaru
                            using (SqlCommand cmdTransaksi = new SqlCommand(queryTransaksi, conn, trans))
                            {
                                cmdTransaksi.Parameters.AddWithValue("@p", idPelanggan);
                                cmdTransaksi.Parameters.AddWithValue("@u", idUser);
                                cmdTransaksi.Parameters.AddWithValue("@t", totalHarga);
                                cmdTransaksi.Parameters.AddWithValue("@k", textBox1.Text);

                                idtransaksiTerbaru = Convert.ToInt32(cmdTransaksi.ExecuteScalar());

                            }

                            //simpan detail transaksi dari dgv

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.IsNewRow) continue;

                                using (SqlCommand cmdDetail = new SqlCommand(queryDetail, conn, trans))
                                {
                                    cmdDetail.Parameters.AddWithValue("@idT", idtransaksiTerbaru);
                                    cmdDetail.Parameters.AddWithValue("@l", Convert.ToInt32(row.Cells[0].Value));
                                    cmdDetail.Parameters.AddWithValue("@qty", Convert.ToDecimal(row.Cells[4].Value));
                                    cmdDetail.Parameters.AddWithValue("@h", Convert.ToDecimal(row.Cells[2].Value));
                                    cmdDetail.Parameters.AddWithValue("@s", Convert.ToDecimal(row.Cells[5].Value));
                                    cmdDetail.ExecuteNonQuery();
                                }
                            }

                            trans.Commit();

                            MessageBox.Show("Transaksi berhasil disimpan");
                            dataGridView1.Rows.Clear();
                            total();
                            idTransaksi();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambahkan data transaksi ke database\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Session.username = null;
            Session.role = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            statusTransaksi statusTransaksi = new statusTransaksi();
            statusTransaksi.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataLayanan layanan = new DataLayanan();
            layanan.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataPelanggan dp = new DataPelanggan();
            dp.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Laporan laporan = new Laporan();
            laporan.Show();
            this.Close();
        }
    }
}
