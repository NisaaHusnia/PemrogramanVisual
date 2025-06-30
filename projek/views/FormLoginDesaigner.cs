using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyFirstApp.projek.views
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private LinkLabel linkDaftar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.linkDaftar = new LinkLabel();
            this.SuspendLayout();

            // FormLogin
            this.BackColor = ColorTranslator.FromHtml("#1A252F");
            this.ClientSize = new Size(500, 350);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login";

            // lblTitle
            lblTitle.Text = "📝 ToDoList App";
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(150, 30);

            // lblUsername
            lblUsername.Text = "Username";
            lblUsername.ForeColor = Color.White;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.Location = new Point(50, 90);
            lblUsername.AutoSize = true;

            // txtUsername
            txtUsername = new TextBox();
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(50, 110);
            txtUsername.Size = new Size(400, 30);

            // lblPassword
            lblPassword.Text = "Password";
            lblPassword.ForeColor = Color.White;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(50, 160);
            lblPassword.AutoSize = true;

            // txtPassword
            txtPassword = new TextBox();
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(50, 180);
            txtPassword.Size = new Size(400, 30);
            txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            btnLogin = new Button();
            btnLogin.Text = "🔐 Login";
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.Size = new Size(400, 40);
            btnLogin.Location = new Point(50, 230);
            btnLogin.BackColor = ColorTranslator.FromHtml("#007BFF");
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // linkDaftar
            linkDaftar.Text = "Belum punya akun? Daftar di sini";
            linkDaftar.LinkColor = ColorTranslator.FromHtml("#5DADE2");
            linkDaftar.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            linkDaftar.Location = new Point(140, 290);
            linkDaftar.AutoSize = true;
            linkDaftar.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkDaftar_LinkClicked);


            // Tambah semua kontrol
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(linkDaftar);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
