using LayananLaundry.PopUpForm;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

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
        private string nama;
        private string noHP;
        private string alamat;

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
            button9.Enabled = false;
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

                    string query = "UPDATE dbo.pelanggan SET status_aktif = 0 WHERE id_pelanggan = @id";

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
                nama = dataGridView1.Rows[e.RowIndex].Cells["nama"].Value.ToString();
                noHP = dataGridView1.Rows[e.RowIndex].Cells["no_hp"].Value.ToString();
                alamat = dataGridView1.Rows[e.RowIndex].Cells["alamat"].Value.ToString();

                button9.Enabled = true;

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
            if (idPelanggan == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }

            DialogResult dg = MessageBox.Show("Yakin mau aktifkan data ini?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE dbo.pelanggan SET status_aktif = 1 WHERE id_pelanggan = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idPelanggan);
                        int result = cmd.ExecuteNonQuery();
                        if (result >= 1)
                        {
                            MessageBox.Show("Data berhasil di aktifkan");
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

        private void button10_Click(object sender, EventArgs e)
        {
            PopUpTambahPelanggan pelanggan = new PopUpTambahPelanggan();

            pelanggan.ShowDialog();
            DGVPelanggan();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (idPelanggan == 0)
            {
                MessageBox.Show("pilih data terlebih dahulu");
                return;
            }

            PopUpEditPelanggan popUp = new PopUpEditPelanggan(idPelanggan, nama, noHP, alamat, status_aktif);

            popUp.ShowDialog();

            DGVPelanggan();
            idPelanggan = 0;
            button6.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyWord = textBox1.Text.Trim();

            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM dbo.pelanggan WHERE nama LIKE @key OR no_hp LIKE @key";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@key", "%" + keyWord + "%");

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
                MessageBox.Show("Error" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void button4_Click(object sender, EventArgs e)
        {
            DataLayanan dl = new DataLayanan();
            dl.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Session.username = null;
            Session.role = null;
        }
    }
}
