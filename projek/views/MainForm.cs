using System;
using System.Drawing;
using System.Windows.Forms;
using MyFirstApp.projek.views;

namespace MyFirstApp.projek.views
{
    public class MainForm : Form
    {
        private Panel sidebar;
        private Panel panelKontenUtama;
        private Button btnDashboard, btnTambahTugas, btnDaftarTugas, btnKeluar;
        private Label lblAppName;
        private Panel panelAtas, panelBawah;

        public MainForm()
        {
            InitializeComponent();
            TampilkanKontenBaru(new DashboardView()); // Kirim referensi MainForm ke Dashboard
        }

        private void InitializeComponent()
        {
            this.Text = "To-Do List App";
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;

            // === PANEL KONTEN UTAMA ===
            panelKontenUtama = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(panelKontenUtama);

            // === SIDEBAR ===
            sidebar = new Panel
            {
                Width = 220,
                Dock = DockStyle.Left,
                BackColor = ColorTranslator.FromHtml("#1A252F")
            };
            this.Controls.Add(sidebar);

            // === PANEL ATAS (Sidebar) ===
            panelAtas = new Panel
            {
                Dock = DockStyle.Top,
                Height = 300,
                BackColor = Color.Transparent
            };
            sidebar.Controls.Add(panelAtas);

            // === LABEL APLIKASI ===
            lblAppName = new Label
            {
                Text = "📝 ToDoList App",
                ForeColor = ColorTranslator.FromHtml("#F1C40F"),
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 80
            };
            panelAtas.Controls.Add(lblAppName);

            // === TOMBOL NAVIGASI ===
            btnDashboard = BuatButtonSidebar("📊 Dashboard");
            btnDashboard.Click += (s, e) => TampilkanKontenBaru(new DashboardView());

            btnTambahTugas = BuatButtonSidebar("➕ Tambah Tugas");
            btnTambahTugas.Click += (s, e) => TampilkanKontenBaru(new TambahTugasView(this));

            btnDaftarTugas = BuatButtonSidebar("📋 Daftar Tugas");
            btnDaftarTugas.Click += (s, e) => TampilkanKontenBaru(new DaftarTugasView(this));

            panelAtas.Controls.Add(btnDaftarTugas);
            panelAtas.Controls.Add(btnTambahTugas);
            panelAtas.Controls.Add(btnDashboard);
            panelAtas.Controls.SetChildIndex(lblAppName, 0);

            // === PANEL BAWAH SIDEBAR (Logout) ===
            panelBawah = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                BackColor = Color.Transparent
            };
            sidebar.Controls.Add(panelBawah);

            btnKeluar = new Button
            {
                Text = "🚪 Logout",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = ColorTranslator.FromHtml("#C0392B"),
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };
            btnKeluar.FlatAppearance.BorderSize = 0;
            btnKeluar.MouseEnter += (s, e) => btnKeluar.BackColor = ColorTranslator.FromHtml("#E74C3C");
            btnKeluar.MouseLeave += (s, e) => btnKeluar.BackColor = ColorTranslator.FromHtml("#C0392B");
            btnKeluar.Click += BtnKeluar_Click;

            panelBawah.Controls.Add(btnKeluar);
        }

        private Button BuatButtonSidebar(string text)
        {
            var btn = new Button
            {
                Text = $"  {text}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = ColorTranslator.FromHtml("#1A252F"),
                FlatStyle = FlatStyle.Flat,
                Height = 50,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#34495E");
            btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#1A252F");
            return btn;
        }

        public void TampilkanKontenBaru(UserControl konten)
        {
            panelKontenUtama.Controls.Clear();
            konten.Dock = DockStyle.Fill;
            panelKontenUtama.Controls.Add(konten);
        }

        private void BtnKeluar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                 Application.Exit();
            }
        }
    }
}
