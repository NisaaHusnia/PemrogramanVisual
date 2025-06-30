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
        private MainForm mainForm; // ✅ referensi ke MainForm

        // ✅ Tambahan constructor dengan parameter MainForm
        public DaftarTugasView(MainForm parent)
        {
            mainForm = parent;
            InitializeComponent();
            LoadDataFromDatabase();
        }

        // Constructor default jika dibutuhkan tanpa parameter
        public DaftarTugasView()
        {
            InitializeComponent();
            LoadDataFromDatabase();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            lblTitle = new Label
            {
                Text = "📋 Daftar Tugas",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = true,
                Margin = new Padding(20)
            };

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

            panelTombol = new Panel { Height = 60, Dock = DockStyle.Fill };
            btnHapus.Location = new Point(20, 10);
            btnRefresh.Location = new Point(140, 10);
            panelTombol.Controls.Add(btnHapus);
            panelTombol.Controls.Add(btnRefresh);

            layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1
            };
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));

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
                    string query = @"SELECT judul, deskripsi, tenggat_waktu, selesai 
                                     FROM tugas 
                                     WHERE user_id = @user_id 
                                     ORDER BY tenggat_waktu ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", SessionManager.CurrentUserId);

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

                                item.BackColor = statusValue == 1
                                    ? Color.Honeydew
                                    : sudahLewat ? Color.LightPink : Color.MistyRose;

                                lvDaftarTugas.Items.Add(item);
                            }
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
                        string query = "DELETE FROM tugas WHERE judul = @judul AND user_id = @user_id LIMIT 1";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@judul", judul);
                            cmd.Parameters.AddWithValue("@user_id", SessionManager.CurrentUserId);
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                MessageBox.Show("Tugas berhasil dihapus.",
                                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadDataFromDatabase();
                            }
                            else
                            {
                                MessageBox.Show("Tugas tidak ditemukan atau bukan milik Anda.",
                                    "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
