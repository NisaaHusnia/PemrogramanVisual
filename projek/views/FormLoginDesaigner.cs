using System;
using System.Windows.Forms;

namespace MyFirstApp.projek.views
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private LinkLabel linkDaftar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.linkDaftar = new LinkLabel();
            this.SuspendLayout();

            // Form Background and Font Color
            this.BackColor = System.Drawing.Color.DarkBlue;

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(40, 40);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            this.lblUsername.ForeColor = System.Drawing.Color.White;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 90);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(75, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            this.lblPassword.ForeColor = System.Drawing.Color.White;

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(120, 35);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(320, 20);
            this.txtUsername.TabIndex = 2;

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(120, 85);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(320, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(120, 125);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(320, 40);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // linkDaftar
            this.linkDaftar.AutoSize = true;
            this.linkDaftar.Location = new System.Drawing.Point(120, 180);
            this.linkDaftar.Name = "linkDaftar";
            this.linkDaftar.Size = new System.Drawing.Size(100, 13);
            this.linkDaftar.TabIndex = 5;
            this.linkDaftar.TabStop = true;
            this.linkDaftar.Text = "Daftar akun baru";
            this.linkDaftar.LinkColor = System.Drawing.Color.White;
            this.linkDaftar.ActiveLinkColor = System.Drawing.Color.LightBlue;
            this.linkDaftar.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkDaftar_LinkClicked);

            // FormLogin
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.linkDaftar);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
