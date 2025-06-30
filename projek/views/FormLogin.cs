using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MyFirstApp.projek.views;
using MyFirstApp.projek.Utilities;

namespace MyFirstApp.projek.views
{
    public partial class FormLogin : Form
    {
        private string connectionString = "Server=localhost;Database=todolist_db;Uid=root;Pwd=;";

        public FormLogin()
        {
            InitializeComponent();

            // Navigasi keyboard
            txtUsername.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) txtPassword.Focus();
            };
            txtPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan password harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = "SELECT id, username, password FROM users WHERE username = @username AND password = @password";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["id"]);
                    string uname = reader["username"].ToString();

                    // Simpan session
                    SessionManager.Login(userId, uname);

                    // Pindah ke dashboard
                    this.Hide();
                    FormDashboard dashboard = new FormDashboard();
                    dashboard.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username atau password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal koneksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkDaftar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormDaftar formDaftar = new FormDaftar();
            formDaftar.ShowDialog();
            this.Show();
        }
    }
}
