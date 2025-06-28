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

        public DaftarTugasView()
        {
            InitializeComponent();
            LoadDataFromDatabase();
        }

        private void InitializeComponent()
        {
            lblTitle = new Label
            {
                Text = "Daftar Tugas",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            lvDaftarTugas = new ListView
            {
                Location = new Point(20, 70),
                Size = new Size(740, 360),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                HideSelection = false
            };

            lvDaftarTugas.Columns.Add("Judul", 200);
            lvDaftarTugas.Columns.Add("Deskripsi", 300);
            lvDaftarTugas.Columns.Add("Deadline", 120);
            lvDaftarTugas.Columns.Add("Status", 100);

            btnHapus = new Button
            {
                Text = "Hapus",
                Location = new Point(20, 450),
                Size = new Size(80, 35),
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnHapus.Click += BtnHapus_Click;

            btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(120, 450),
                Size = new Size(80, 35),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnRefresh.Click += BtnRefresh_Click;

            this.Controls.Add(lblTitle);
            this.Controls.Add(lvDaftarTugas);
            this.Controls.Add(btnHapus);
            this.Controls.Add(btnRefresh);
            this.Size = new Size(800, 520);
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
                            string statusStr = statusValue == 1 ? "Selesai" : "Belum Selesai";

                            ListViewItem item = new ListViewItem(judul);
                            item.SubItems.Add(deskripsi);
                            item.SubItems.Add(deadline.ToString("dd MMM yyyy"));
                            item.SubItems.Add(statusStr);

                            // Pewarnaan
                            item.BackColor = statusValue == 1 ? Color.LightGreen : Color.LightCoral;

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
