using System;
using System.Windows.Forms;
using MyFirstApp.projek.controllers;      // Gunakan controller
using MyFirstApp.projek.services;
using MyFirstApp.projek.views;
          // Untuk form lain (FormDaftar, FormDashboard)

namespace MyFirstApp.projek.views
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            // Navigasi Enter
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

            AuthController auth = new AuthController();
            bool success = false;

            try
            {
                success = auth.Login(username, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat login:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (success)
            {
                // Login berhasil
                FormDashboard dashboard = new FormDashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
