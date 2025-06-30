using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyFirstApp
{
    public partial class FormDaftar : Form
    {
        private Label lblTitle;
        private Label lblNama, lblUsername, lblEmail, lblNoHp, lblPassword, lblConfirmPassword;
        private TextBox txtNama, txtUsername, txtEmail, txtNoHp, txtPassword, txtConfirmPassword;
        private Button btnDaftar;

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblNama = new Label();
            this.lblUsername = new Label();
            this.lblEmail = new Label();
            this.lblNoHp = new Label();
            this.lblPassword = new Label();
            this.lblConfirmPassword = new Label();

            this.txtNama = new TextBox();
            this.txtUsername = new TextBox();
            this.txtEmail = new TextBox();
            this.txtNoHp = new TextBox();
            this.txtPassword = new TextBox();
            this.txtConfirmPassword = new TextBox();

            this.btnDaftar = new Button();
            this.SuspendLayout();

            // FORM PROPERTIES
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Form Daftar";

            Font labelFont = new Font("Segoe UI", 10);
            Font textFont = new Font("Segoe UI", 10);

            // TITLE
            this.lblTitle.Text = "📝 Daftar Akun Baru";
            this.lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(52, 58, 64);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(180, 30);

            int labelX = 80;
            int textboxX = 250;
            int baseY = 90;
            int gapY = 50;
            int boxW = 250;

            CreateLabelAndTextbox(lblNama, txtNama, "Nama Lengkap:", labelX, textboxX, baseY + 0 * gapY, boxW, labelFont, textFont);
            CreateLabelAndTextbox(lblUsername, txtUsername, "Username:", labelX, textboxX, baseY + 1 * gapY, boxW, labelFont, textFont);
            CreateLabelAndTextbox(lblEmail, txtEmail, "Email:", labelX, textboxX, baseY + 2 * gapY, boxW, labelFont, textFont);
            CreateLabelAndTextbox(lblNoHp, txtNoHp, "No HP:", labelX, textboxX, baseY + 3 * gapY, boxW, labelFont, textFont);
            CreateLabelAndTextbox(lblPassword, txtPassword, "Password:", labelX, textboxX, baseY + 4 * gapY, boxW, labelFont, textFont);
            CreateLabelAndTextbox(lblConfirmPassword, txtConfirmPassword, "Konfirmasi Password:", labelX, textboxX, baseY + 5 * gapY, boxW, labelFont, textFont);

            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            // Button
            btnDaftar.Text = "💾 Daftar Sekarang";
            btnDaftar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDaftar.BackColor = Color.FromArgb(0, 123, 255);
            btnDaftar.ForeColor = Color.White;
            btnDaftar.FlatStyle = FlatStyle.Flat;
            btnDaftar.FlatAppearance.BorderSize = 0;
            btnDaftar.Size = new Size(boxW, 40);
            btnDaftar.Location = new Point(textboxX, baseY + 6 * gapY);
            btnDaftar.Click += new EventHandler(this.btnDaftar_Click);

            // Add Controls
            this.Controls.Add(lblTitle);
            this.Controls.AddRange(new Control[]
            {
                lblNama, txtNama,
                lblUsername, txtUsername,
                lblEmail, txtEmail,
                lblNoHp, txtNoHp,
                lblPassword, txtPassword,
                lblConfirmPassword, txtConfirmPassword,
                btnDaftar
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CreateLabelAndTextbox(Label lbl, TextBox txt, string text, int lblX, int txtX, int y, int txtW, Font lblFont, Font txtFont)
        {
            lbl.Text = text;
            lbl.Font = lblFont;
            lbl.Location = new Point(lblX, y + 5);
            lbl.AutoSize = true;

            txt.Font = txtFont;
            txt.Location = new Point(txtX, y);
            txt.Size = new Size(txtW, 28);
            txt.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
