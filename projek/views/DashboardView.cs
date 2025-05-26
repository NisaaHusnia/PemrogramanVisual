using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyFirstApp.projek.views
{
    public partial class DashboardView : UserControl
    {
        private Label lblTitle;
        private Panel pnlTotalTugas, pnlSelesai, pnlPending;
        private Label lblTotalTugasCount, lblSelesaiCount, lblPendingCount;
        private Label lblTotalTugasText, lblSelesaiText, lblPendingText;

        private Button btnTambahTugas, btnLihatDaftar;

        public DashboardView()
        {
            InitializeComponent();
            LoadDummyData(); // Ganti dengan load data sebenarnya nanti
        }

        private void InitializeComponent()
        {
            this.Size = new Size(800, 500);
            this.BackColor = Color.White;

            // Judul
            lblTitle = new Label();
            lblTitle.Text = "Dashboard";
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblTitle.Location = new Point(30, 20);
            lblTitle.AutoSize = true;

            // Panel Total Tugas
            pnlTotalTugas = CreateInfoPanel("Total Tugas", Color.FromArgb(0, 120, 215), out lblTotalTugasCount, out lblTotalTugasText);
            pnlTotalTugas.Location = new Point(30, 90);

            // Panel Tugas Selesai
            pnlSelesai = CreateInfoPanel("Tugas Selesai", Color.FromArgb(46, 204, 113), out lblSelesaiCount, out lblSelesaiText);
            pnlSelesai.Location = new Point(280, 90);

            // Panel Tugas Pending
            pnlPending = CreateInfoPanel("Tugas Pending", Color.FromArgb(231, 76, 60), out lblPendingCount, out lblPendingText);
            pnlPending.Location = new Point(530, 90);

            // Tombol Tambah Tugas
            btnTambahTugas = new Button();
            btnTambahTugas.Text = "Tambah Tugas";
            btnTambahTugas.Size = new Size(180, 45);
            btnTambahTugas.Location = new Point(30, 250);
            btnTambahTugas.BackColor = Color.FromArgb(0, 120, 215);
            btnTambahTugas.ForeColor = Color.White;
            btnTambahTugas.FlatStyle = FlatStyle.Flat;
            btnTambahTugas.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btnTambahTugas.Click += BtnTambahTugas_Click;

            // Tombol Lihat Daftar Tugas
            btnLihatDaftar = new Button();
            btnLihatDaftar.Text = "Lihat Daftar Tugas";
            btnLihatDaftar.Size = new Size(180, 45);
            btnLihatDaftar.Location = new Point(230, 250);
            btnLihatDaftar.BackColor = Color.FromArgb(52, 152, 219);
            btnLihatDaftar.ForeColor = Color.White;
            btnLihatDaftar.FlatStyle = FlatStyle.Flat;
            btnLihatDaftar.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btnLihatDaftar.Click += BtnLihatDaftar_Click;

            // Tambahkan kontrol ke UserControl
            this.Controls.Add(lblTitle);
            this.Controls.Add(pnlTotalTugas);
            this.Controls.Add(pnlSelesai);
            this.Controls.Add(pnlPending);
            this.Controls.Add(btnTambahTugas);
            this.Controls.Add(btnLihatDaftar);
        }

        private Panel CreateInfoPanel(string title, Color color, out Label lblCount, out Label lblText)
        {
            Panel panel = new Panel();
            panel.Size = new Size(220, 130);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Padding = new Padding(10);

            lblCount = new Label();
            lblCount.Text = "0";
            lblCount.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblCount.ForeColor = color;
            lblCount.Dock = DockStyle.Top;
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            lblCount.Height = 70;

            lblText = new Label();
            lblText.Text = title;
            lblText.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            lblText.ForeColor = Color.Gray;
            lblText.Dock = DockStyle.Bottom;
            lblText.Height = 40;
            lblText.TextAlign = ContentAlignment.MiddleCenter;

            panel.Controls.Add(lblCount);
            panel.Controls.Add(lblText);

            return panel;
        }

        private void LoadDummyData()
        {
            // Contoh data dummy, ganti dengan panggilan ke database/logic nyata nanti
            lblTotalTugasCount.Text = "15";
            lblSelesaiCount.Text = "7";
            lblPendingCount.Text = "8";
        }

        // Event klik tombol tambah tugas
        private void BtnTambahTugas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigasi ke form Tambah Tugas (belum diimplementasi).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Contoh: trigger event atau navigasi ke view tambah tugas
        }

        // Event klik tombol lihat daftar tugas
        private void BtnLihatDaftar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigasi ke Daftar Tugas (belum diimplementasi).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Contoh: trigger event atau navigasi ke view daftar tugas
        }
    }
}
