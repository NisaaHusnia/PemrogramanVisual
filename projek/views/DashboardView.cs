using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MyFirstApp.projek.Utilities;

namespace MyFirstApp.projek.views
{
    public partial class DashboardView : UserControl
    {
        private Label lblJudulAplikasi, lblSubJudul;
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

            lblJudulAplikasi = new Label
            {
                Text = "📌 ToDoList App",
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = Color.FromArgb(231, 76, 60),
                Location = new Point(30, 20),
                AutoSize = true
            };
            this.Controls.Add(lblJudulAplikasi);

            lblSubJudul = new Label
            {
                Text = "Dashboard",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(30, 70),
                AutoSize = true
            };
            this.Controls.Add(lblSubJudul);

            statistikPanel = new FlowLayoutPanel
            {
                Location = new Point(30, 130),
                Size = new Size(900, 150),
                BackColor = Color.Transparent,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight
            };
            this.Controls.Add(statistikPanel);

            btnTambahTugas = new Button
            {
                Text = "➕ Tambah Tugas",
                Size = new Size(180, 45),
                Location = new Point(30, 300),
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            btnTambahTugas.FlatAppearance.BorderSize = 0;
            btnTambahTugas.Click += (s, e) =>
            {
                var form = this.FindForm() as FormDashboard;
                form?.LoadTambahTugasView();
            };
            this.Controls.Add(btnTambahTugas);

            btnLihatDaftar = new Button
            {
                Text = "📋 Lihat Daftar Tugas",
                Size = new Size(220, 45),
                Location = new Point(230, 300),
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            btnLihatDaftar.FlatAppearance.BorderSize = 0;
            btnLihatDaftar.Click += (s, e) =>
            {
                var form = this.FindForm() as FormDashboard;
                form?.LoadDaftarTugasView();
            };
            this.Controls.Add(btnLihatDaftar);
        }

        private Panel CreateStatCard(string emoji, string label, out Label lblCount, Color bgColor)
        {
            Panel panel = new Panel
            {
                Size = new Size(220, 120),
                BackColor = bgColor,
                Margin = new Padding(10),
                Padding = new Padding(10)
            };

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

            lblCount = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 26F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };

            Label lblText = new Label
            {
                Text = $"{emoji} {label}",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Height = 40
            };

            panel.Controls.Add(lblCount);
            panel.Controls.Add(lblText);
            return panel;
        }

        private void LoadDashboardData()
        {
            statistikPanel.Controls.Clear();

            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    int userId = SessionManager.CurrentUserId;

                    string totalQuery = "SELECT COUNT(*) FROM tugas WHERE user_id = @user_id";
                    string selesaiQuery = "SELECT COUNT(*) FROM tugas WHERE user_id = @user_id AND selesai = 1";
                    string pendingQuery = "SELECT COUNT(*) FROM tugas WHERE user_id = @user_id AND selesai = 0";

                    Label lblTotal, lblSelesai, lblPending;

                    var cardTotal = CreateStatCard("📊", "Total Tugas", out lblTotal, Color.FromArgb(52, 152, 219));
                    var cardSelesai = CreateStatCard("✅", "Tugas Selesai", out lblSelesai, Color.FromArgb(46, 204, 113));
                    var cardPending = CreateStatCard("⏳", "Tugas Pending", out lblPending, Color.FromArgb(231, 76, 60));

                    using (var cmd = new MySqlCommand(totalQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        lblTotal.Text = cmd.ExecuteScalar().ToString();
                    }

                    using (var cmd = new MySqlCommand(selesaiQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        lblSelesai.Text = cmd.ExecuteScalar().ToString();
                    }

                    using (var cmd = new MySqlCommand(pendingQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        lblPending.Text = cmd.ExecuteScalar().ToString();
                    }

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
    }
}
