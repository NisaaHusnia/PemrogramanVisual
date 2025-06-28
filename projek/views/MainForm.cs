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
        private Button btnDashboard, btnTambahTugas, btnDaftarTugas;
        private Label lblAppName;

        public MainForm()
        {
            InitializeComponent();
            TampilkanKontenBaru(new DashboardView());
        }

        private void InitializeComponent()
        {
            this.Text = "To-Do List App";
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;

            // === SIDEBAR ===
            sidebar = new Panel
            {
                Width = 220,
                Dock = DockStyle.Left,
                BackColor = ColorTranslator.FromHtml("#1A252F")
            };
            this.Controls.Add(sidebar);

            // === LABEL APP ===
            lblAppName = new Label
            {
                Text = "📝 MyTasks",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 80
            };
            sidebar.Controls.Add(lblAppName);

            // === TOMBOL ===
            btnDashboard = BuatButtonSidebar("📊 Dashboard");
            btnDashboard.Click += (s, e) => TampilkanKontenBaru(new DashboardView());

            btnTambahTugas = BuatButtonSidebar("➕ Tambah Tugas");
            btnTambahTugas.Click += (s, e) => TampilkanKontenBaru(new TambahTugasView());

            btnDaftarTugas = BuatButtonSidebar("📋 Daftar Tugas");
            btnDaftarTugas.Click += (s, e) => TampilkanKontenBaru(new DaftarTugasView());

            sidebar.Controls.AddRange(new Control[] {
                btnDashboard, btnTambahTugas, btnDaftarTugas
            });

            // === PANEL KONTEN UTAMA ===
            panelKontenUtama = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(panelKontenUtama);
        }

        private Button BuatButtonSidebar(string text)
        {
            var btn = new Button
            {
                Text = $"  {text}",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = ColorTranslator.FromHtml("#1A252F"),
                FlatStyle = FlatStyle.Flat,
                Height = 50,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#3A6FA1");
            btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#1A252F");
            return btn;
        }

        public void TampilkanKontenBaru(UserControl konten)
        {
            panelKontenUtama.Controls.Clear();
            konten.Dock = DockStyle.Fill;
            panelKontenUtama.Controls.Add(konten);
        }
    }
}
