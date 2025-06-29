using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MyFirstApp.projek.Utilities;

namespace MyFirstApp.projek.views
{
    public partial class DashboardView : UserControl
    {
        private Label lblTitle;
        private FlowLayoutPanel statistikPanel;
        private Button btnTambahTugas, btnLihatDaftar;

        public DashboardView()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            // Judul
            lblTitle = new Label();
            lblTitle.Text = "📊 Dashboard";
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(30, 20);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            // Panel statistik
            statistikPanel = new FlowLayoutPanel();
            statistikPanel.Location = new Point(30, 90);
            statistikPanel.Size = new Size(740, 150);
            statistikPanel.BackColor = Color.Transparent;
            statistikPanel.AutoScroll = false;
            statistikPanel.WrapContents = false;
            statistikPanel.FlowDirection = FlowDirection.LeftToRight;
            this.Controls.Add(statistikPanel);

            // Tambah Tugas Button
            btnTambahTugas = new Button();
            btnTambahTugas.Text = "➕ Tambah Tugas";
            btnTambahTugas.Size = new Size(180, 45);
            btnTambahTugas.Location = new Point(30, 270);
            btnTambahTugas.BackColor = Color.FromArgb(41, 128, 185);
            btnTambahTugas.ForeColor = Color.White;
            btnTambahTugas.FlatStyle = FlatStyle.Flat;
            btnTambahTugas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTambahTugas.Click += BtnTambahTugas_Click;
            this.Controls.Add(btnTambahTugas);

            // Lihat Daftar Button
            btnLihatDaftar = new Button();
            btnLihatDaftar.Text = "📋 Lihat Daftar Tugas";
            btnLihatDaftar.Size = new Size(220, 45);
            btnLihatDaftar.Location = new Point(230, 270);
            btnLihatDaftar.BackColor = Color.FromArgb(39, 174, 96);
            btnLihatDaftar.ForeColor = Color.White;
            btnLihatDaftar.FlatStyle = FlatStyle.Flat;
            btnLihatDaftar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLihatDaftar.Click += BtnLihatDaftar_Click;
            this.Controls.Add(btnLihatDaftar);
        }

        private Panel CreateStatCard(string emoji, string label, out Label lblCount, Color background)
        {
            Panel panel = new Panel();
            panel.Size = new Size(220, 120);
            panel.BackColor = background;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.None;

            // Rounded Corner
            panel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var rect = panel.ClientRectangle;
                rect.Inflate(-1, -1);
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int radius = 20;
                    path.AddArc(0, 0, radius, radius, 180, 90);
                    path.AddArc(rect.Width - radius, 0, radius, radius, 270, 90);
                    path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
                    path.AddArc(0, rect.Height - radius, radius, radius, 90, 90);
                    path.CloseFigure();
                    panel.Region = new Region(path);
                }
            };

            lblCount = new Label();
            lblCount.Text = "0";
            lblCount.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblCount.ForeColor = Color.White;
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            lblCount.Dock = DockStyle.Top;
            lblCount.Height = 60;

            Label lblText = new Label();
            lblText.Text = $"{emoji} {label}";
            lblText.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lblText.ForeColor = Color.White;
            lblText.TextAlign = ContentAlignment.MiddleCenter;
            lblText.Dock = DockStyle.Bottom;
            lblText.Height = 40;

            panel.Controls.Add(lblCount);
            panel.Controls.Add(lblText);

            return panel;
        }

        private void LoadDashboardData()
        {
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    string totalQuery = "SELECT COUNT(*) FROM tugas";
                    string selesaiQuery = "SELECT COUNT(*) FROM tugas WHERE selesai = 1";
                    string pendingQuery = "SELECT COUNT(*) FROM tugas WHERE selesai = 0";

                    Label lblTotal, lblSelesai, lblPending;

                    // Create cards
                    var cardTotal = CreateStatCard("📌", "Total Tugas", out lblTotal, Color.FromArgb(52, 152, 219));
                    var cardSelesai = CreateStatCard("✅", "Tugas Selesai", out lblSelesai, Color.FromArgb(46, 204, 113));
                    var cardPending = CreateStatCard("⏳", "Tugas Pending", out lblPending, Color.FromArgb(231, 76, 60));

                    // Fetch data
                    using (var cmd = new MySqlCommand(totalQuery, conn))
                        lblTotal.Text = cmd.ExecuteScalar().ToString();

                    using (var cmd = new MySqlCommand(selesaiQuery, conn))
                        lblSelesai.Text = cmd.ExecuteScalar().ToString();

                    using (var cmd = new MySqlCommand(pendingQuery, conn))
                        lblPending.Text = cmd.ExecuteScalar().ToString();

                    // Add to panel
                    statistikPanel.Controls.Add(cardTotal);
                    statistikPanel.Controls.Add(cardSelesai);
                    statistikPanel.Controls.Add(cardPending);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data dashboard:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTambahTugas_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm() as MainForm;
            if (parentForm != null)
                parentForm.TampilkanKontenBaru(new TambahTugasView());
        }

        private void BtnLihatDaftar_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm() as MainForm;
            if (parentForm != null)
                parentForm.TampilkanKontenBaru(new DaftarTugasView());
        }
    }
}
