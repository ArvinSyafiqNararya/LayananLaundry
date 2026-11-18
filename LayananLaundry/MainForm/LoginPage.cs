using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LayananLaundry.MainForm
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text.Trim();
            string password = textBox1.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan password harus terisi");
                return;
            }
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT username,password_hash,role FROM dbo.users WHERE username = @u";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (!rdr.Read())
                            {
                                MessageBox.Show("username atau password salah");
                                return;
                            }

                            string role = rdr["role"].ToString();
                            string passwordFromDb = rdr["password_hash"].ToString();
                            bool isValid = BCrypt.Net.BCrypt.Verify(password, passwordFromDb);

                            if (!isValid)
                            {
                                MessageBox.Show("username atau password salah");
                                return;
                            }
                            else
                            {
                                Session.username = username;
                                Session.role = role;
                                Dashboard dashboard = new Dashboard();
                                dashboard.Show();
                                this.Hide();
                            }
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

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
