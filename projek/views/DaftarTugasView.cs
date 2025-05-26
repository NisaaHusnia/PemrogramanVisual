using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Pastikan sudah install MySql.Data via NuGet

namespace MyFirstApp.projek.views
{
    public partial class DaftarTugasView : UserControl
    {
        private ListView lvDaftarTugas;
        private ColumnHeader colJudul, colDeskripsi, colDeadline, colStatus;
        private Label lblTitle;

        // Ganti connectionString sesuai konfigurasi database kamu
        private string connectionString = "server=localhost;uid=root;pwd=your_password;database=todolist_db;";

        public DaftarTugasView()
        {
            InitializeComponent();
            LoadDataFromDatabase();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lvDaftarTugas = new ListView();
            this.colJudul = new ColumnHeader();
            this.colDeskripsi = new ColumnHeader();
            this.colDeadline = new ColumnHeader();
            this.colStatus = new ColumnHeader();

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Daftar Tugas";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.AutoSize = true;

            // 
            // lvDaftarTugas
            // 
            this.lvDaftarTugas.Location = new Point(20, 70);
            this.lvDaftarTugas.Size = new Size(760, 400);
            this.lvDaftarTugas.View = View.Details;
            this.lvDaftarTugas.FullRowSelect = true;
            this.lvDaftarTugas.GridLines = true;
            this.lvDaftarTugas.HideSelection = false;
            this.lvDaftarTugas.MultiSelect = false;

            this.lvDaftarTugas.Columns.AddRange(new ColumnHeader[] {
                this.colJudul, this.colDeskripsi, this.colDeadline, this.colStatus
            });

            // 
            // Columns
            // 
            this.colJudul.Text = "Judul";
            this.colJudul.Width = 200;

            this.colDeskripsi.Text = "Deskripsi";
            this.colDeskripsi.Width = 350;

            this.colDeadline.Text = "Deadline";
            this.colDeadline.Width = 120;

            this.colStatus.Text = "Status";
            this.colStatus.Width = 90;

            // 
            // DaftarTugasView (UserControl)
            // 
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvDaftarTugas);
            this.Size = new Size(800, 500);
        }

        private void LoadDataFromDatabase()
        {
            lvDaftarTugas.Items.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT judul, deskripsi, deadline, status FROM tugas ORDER BY deadline ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string judul = reader.GetString("judul");
                                string deskripsi = reader.GetString("deskripsi");
                                DateTime deadline = reader.GetDateTime("deadline");
                                string status = reader.GetString("status");

                                ListViewItem item = new ListViewItem(judul);
                                item.SubItems.Add(deskripsi);
                                item.SubItems.Add(deadline.ToString("dd MMM yyyy"));
                                item.SubItems.Add(status);

                                // Warna baris berdasarkan status
                                if (status == "Selesai")
                                {
                                    item.BackColor = Color.LightGreen;
                                }
                                else if (status == "Sedang Dikerjakan")
                                {
                                    item.BackColor = Color.LightYellow;
                                }
                                else // Belum Selesai
                                {
                                    item.BackColor = Color.LightCoral;
                                }

                                lvDaftarTugas.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data dari database.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
