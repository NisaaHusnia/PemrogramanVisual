using System.Drawing;

namespace MyFirstApp
{
    partial class FormDaftar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblNama = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNoHp = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();

            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNoHp = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();

            this.btnDaftar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form background and font colors
            this.BackColor = System.Drawing.Color.FromArgb(0, 0, 139); // Biru tua (DarkBlue)
            this.ForeColor = System.Drawing.Color.White;

            // Label & Textbox settings
            int labelX = 30;
            int textboxX = 180;
            int controlWidth = 300;
            int controlHeight = 28;
            int verticalSpacing = 50;

            // lblNama
            this.lblNama.Text = "Nama:";
            this.lblNama.Location = new System.Drawing.Point(labelX, 30);
            this.lblNama.AutoSize = true;
            this.lblNama.ForeColor = Color.White;

            this.txtNama.Location = new System.Drawing.Point(textboxX, 25);
            this.txtNama.Width = controlWidth;
            this.txtNama.Height = controlHeight;

            // lblUsername
            this.lblUsername.Text = "Username:";
            this.lblUsername.Location = new System.Drawing.Point(labelX, 30 + verticalSpacing);
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = Color.White;

            this.txtUsername.Location = new System.Drawing.Point(textboxX, 25 + verticalSpacing);
            this.txtUsername.Width = controlWidth;
            this.txtUsername.Height = controlHeight;

            // lblEmail
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(labelX, 30 + verticalSpacing * 2);
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = Color.White;

            this.txtEmail.Location = new System.Drawing.Point(textboxX, 25 + verticalSpacing * 2);
            this.txtEmail.Width = controlWidth;
            this.txtEmail.Height = controlHeight;

            // lblNoHp
            this.lblNoHp.Text = "No HP:";
            this.lblNoHp.Location = new System.Drawing.Point(labelX, 30 + verticalSpacing * 3);
            this.lblNoHp.AutoSize = true;
            this.lblNoHp.ForeColor = Color.White;

            this.txtNoHp.Location = new System.Drawing.Point(textboxX, 25 + verticalSpacing * 3);
            this.txtNoHp.Width = controlWidth;
            this.txtNoHp.Height = controlHeight;

            // lblPassword
            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new System.Drawing.Point(labelX, 30 + verticalSpacing * 4);
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = Color.White;

            this.txtPassword.Location = new System.Drawing.Point(textboxX, 25 + verticalSpacing * 4);
            this.txtPassword.Width = controlWidth;
            this.txtPassword.Height = controlHeight;
            this.txtPassword.PasswordChar = '*';

            // lblConfirmPassword
            this.lblConfirmPassword.Text = "Konfirmasi Password:";
            this.lblConfirmPassword.Location = new System.Drawing.Point(labelX, 30 + verticalSpacing * 5);
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.ForeColor = Color.White;

            this.txtConfirmPassword.Location = new System.Drawing.Point(textboxX, 25 + verticalSpacing * 5);
            this.txtConfirmPassword.Width = controlWidth;
            this.txtConfirmPassword.Height = controlHeight;
            this.txtConfirmPassword.PasswordChar = '*';

            // Button Daftar
            this.btnDaftar.Text = "Daftar";
            this.btnDaftar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDaftar.Location = new System.Drawing.Point(textboxX, 25 + verticalSpacing * 6 + 10);
            this.btnDaftar.Size = new System.Drawing.Size(140, 50);
            this.btnDaftar.BackColor = System.Drawing.Color.White;
            this.btnDaftar.ForeColor = System.Drawing.Color.FromArgb(0, 0, 139); // biru tua
            this.btnDaftar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaftar.Click += new System.EventHandler(this.btnDaftar_Click);

            // Tambahkan semua kontrol ke form
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblNoHp);
            this.Controls.Add(this.txtNoHp);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.btnDaftar);

            // Form settings
            this.Text = "Form Daftar";
            this.ClientSize = new System.Drawing.Size(520, 450);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNama, lblUsername, lblEmail, lblNoHp, lblPassword, lblConfirmPassword;
        private System.Windows.Forms.TextBox txtNama, txtUsername, txtEmail, txtNoHp, txtPassword, txtConfirmPassword;
        private System.Windows.Forms.Button btnDaftar;
    }
}
