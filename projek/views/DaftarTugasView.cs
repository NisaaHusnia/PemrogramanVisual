using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MyFirstApp.projek.Utilities;

namespace MyFirstApp.projek.views
{
    public partial class DaftarTugasView : UserControl
    {
        private Label lblTitle;
        private ListView lvDaftarTugas;
        private Button btnHapus, btnRefresh;
        private TableLayoutPanel layout;
        private Panel panelTombol;

        public DaftarTugasView()
        {
            InitializeComponent();
            LoadDataFromDatabase();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            // === LABEL ===
            lblTitle = new Label
            {
                Text = "📋 Daftar Tugas",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = true,
                Margin = new Padding(20)
            };

            // === LIST VIEW ===
            lvDaftarTugas = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                HideSelection = false,
                Font = new Font("Segoe UI", 10F)
            };

            lvDaftarTugas.Columns.Add("Judul", 200);
            lvDaftarTugas.Columns.Add("Deskripsi", 350);
            lvDaftarTugas.Columns.Add("Deadline", 150);
            lvDaftarTugas.Columns.Add("Status", 200);

            // === BUTTON HAPUS ===
            btnHapus = new Button
            {
                Text = "🗑️ Hapus",
                Size = new Size(100, 40),
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnHapus.FlatAppearance.BorderSize = 0;
            btnHapus.Click += BtnHapus_Click;

            // === BUTTON REFRESH ===
            btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                Size = new Size(100, 40),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += BtnRefresh_Click;

            // === PANEL TOMBOL ===
            panelTombol = new Panel
            {
                Height = 60,
                Dock = DockStyle.Fill
            };
            btnHapus.Location = new Point(20, 10);
            btnRefresh.Location = new Point(140, 10);
            panelTombol.Controls.Add(btnHapus);
            panelTombol.Controls.Add(btnRefresh);

            // === LAYOUT ===
            layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1
            };
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));       // Title
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // List
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F)); // Button Panel

            layout.Controls.Add(lblTitle, 0, 0);
            layout.Controls.Add(lvDaftarTugas, 0, 1);
            layout.Controls.Add(panelTombol, 0, 2);

            this.Controls.Add(layout);
        }

        private void LoadDataFromDatabase()
        {
            lvDaftarTugas.Items.Clear();

            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT judul, deskripsi, tenggat_waktu, selesai FROM tugas ORDER BY tenggat_waktu ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string judul = reader.GetString("judul");
                            string deskripsi = reader.GetString("deskripsi");
                            DateTime deadline = reader.GetDateTime("tenggat_waktu");
                            int statusValue = reader.GetInt32("selesai");

                            bool sudahLewat = deadline.Date < DateTime.Today && statusValue == 0;
                            string statusStr = statusValue == 1
                                ? "Selesai"
                                : sudahLewat ? "Belum Selesai (❗Terlambat)" : "Belum Selesai";

                            ListViewItem item = new ListViewItem(judul);
                            item.SubItems.Add(deskripsi);
                            item.SubItems.Add(deadline.ToString("dd MMM yyyy"));
                            item.SubItems.Add(statusStr);

                            // Pewarnaan
                            if (statusValue == 1)
                                item.BackColor = Color.Honeydew;
                            else if (sudahLewat)
                                item.BackColor = Color.LightPink;
                            else
                                item.BackColor = Color.MistyRose;

                            lvDaftarTugas.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data dari database.\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            if (lvDaftarTugas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih tugas yang ingin dihapus.",
                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string judul = lvDaftarTugas.SelectedItems[0].Text;

            DialogResult confirm = MessageBox.Show(
                $"Yakin ingin menghapus tugas '{judul}'?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = DatabaseManager.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM tugas WHERE judul = @judul LIMIT 1";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@judul", judul);
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                MessageBox.Show("Tugas berhasil dihapus.",
                                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadDataFromDatabase();
                            }
                            else
                            {
                                MessageBox.Show("Tugas gagal dihapus.",
                                    "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat menghapus:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
