using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MyFirstApp
{
    public partial class FormDaftar : Form
    {
        private string connectionString = "Server=localhost;Database=todolist_db;Uid=root;Pwd=;";

        public FormDaftar()
        {
            InitializeComponent();
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Semua field harus diisi!");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password dan konfirmasi password tidak cocok!");
                return;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO users (username, password) VALUES (@username, @password)";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Registrasi berhasil! Silakan login.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
        }
    }
}
