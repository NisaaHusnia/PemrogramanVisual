using System;
using System.Drawing;
using System.Windows.Forms;
using MyFirstApp.projek.models;
using MyFirstApp.projek.Utilities;
using System.Collections.Generic;

namespace MyFirstApp.projek.views
{
    public partial class TambahTugasView : UserControl
    {
        private MainForm mainForm;

        private TextBox txtJudul, txtDeskripsi;
        private DateTimePicker dtpDeadline;
        private ComboBox cmbStatus;
        private ListView lvTugas;
        private Button btnSimpan, btnEdit, btnHapus;

        // ✅ Constructor yang menerima MainForm
        public TambahTugasView(MainForm parent)
        {
            mainForm = parent;
            InitializeComponent();
            LoadTasks();
        }

        // (Optional) constructor default jika tetap ingin digunakan di luar navigasi
        public TambahTugasView()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void InitializeComponent()
        {
            Label lblTitle = new Label { Text = "Tambah Tugas", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };
            Label lblJudul = new Label { Text = "Judul", Location = new Point(20, 70) };
            Label lblDeskripsi = new Label { Text = "Deskripsi", Location = new Point(20, 110) };
            Label lblDeadline = new Label { Text = "Deadline", Location = new Point(20, 190) };
            Label lblStatus = new Label { Text = "Status", Location = new Point(20, 230) };

            txtJudul = new TextBox { Location = new Point(120, 70), Width = 250 };
            txtDeskripsi = new TextBox { Location = new Point(120, 110), Width = 250, Height = 60, Multiline = true };
            dtpDeadline = new DateTimePicker { Location = new Point(120, 190), Width = 250 };
            cmbStatus = new ComboBox { Location = new Point(120, 230), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbStatus.Items.AddRange(new string[] { "Belum Selesai", "Selesai" });
            cmbStatus.SelectedIndex = 0;

            btnSimpan = new Button { Text = "Simpan", Location = new Point(120, 280), BackColor = Color.MediumSeaGreen, ForeColor = Color.White };
            btnEdit = new Button { Text = "Edit", Location = new Point(210, 280), BackColor = Color.SteelBlue, ForeColor = Color.White };
            btnHapus = new Button { Text = "Hapus", Location = new Point(300, 280), BackColor = Color.IndianRed, ForeColor = Color.White };

            btnSimpan.Click += btnSimpan_Click;
            btnEdit.Click += btnEdit_Click;
            btnHapus.Click += btnHapus_Click;

            lvTugas = new ListView
            {
                Location = new Point(20, 330),
                Width = 600,
                Height = 200,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };

            lvTugas.Columns.Add("Judul", 150);
            lvTugas.Columns.Add("Deskripsi", 200);
            lvTugas.Columns.Add("Deadline", 100);
            lvTugas.Columns.Add("Status", 120);
            lvTugas.SelectedIndexChanged += lvTugas_SelectedIndexChanged;

            Controls.AddRange(new Control[] {
                lblTitle, lblJudul, txtJudul, lblDeskripsi, txtDeskripsi, lblDeadline, dtpDeadline,
                lblStatus, cmbStatus, btnSimpan, btnEdit, btnHapus, lvTugas
            });

            this.Dock = DockStyle.Fill;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            var task = new TodoTask
            {
                UserId = SessionManager.CurrentUserId,
                Title = txtJudul.Text.Trim(),
                Description = txtDeskripsi.Text.Trim(),
                Deadline = dtpDeadline.Value,
                Status = cmbStatus.SelectedItem.ToString()
            };

            if (TaskModel.Add(task))
            {
                LoadTasks();
                ClearForm();
                MessageBox.Show("Tugas berhasil disimpan.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvTugas.SelectedItems.Count == 0) return;

            string oldTitle = lvTugas.SelectedItems[0].Text;

            var updatedTask = new TodoTask
            {
                UserId = SessionManager.CurrentUserId,
                Title = txtJudul.Text.Trim(),
                Description = txtDeskripsi.Text.Trim(),
                Deadline = dtpDeadline.Value,
                Status = cmbStatus.SelectedItem.ToString()
            };

            if (TaskModel.Update(oldTitle, updatedTask))
            {
                LoadTasks();
                ClearForm();
                MessageBox.Show("Tugas berhasil diperbarui.");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvTugas.SelectedItems.Count == 0) return;

            string selectedTitle = lvTugas.SelectedItems[0].Text;

            if (TaskModel.Delete(selectedTitle, SessionManager.CurrentUserId))
            {
                LoadTasks();
                ClearForm();
                MessageBox.Show("Tugas berhasil dihapus.");
            }
        }

        private void lvTugas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTugas.SelectedItems.Count > 0)
            {
                var item = lvTugas.SelectedItems[0];
                txtJudul.Text = item.Text;
                txtDeskripsi.Text = item.SubItems[1].Text;
                dtpDeadline.Value = DateTime.Parse(item.SubItems[2].Text);
                cmbStatus.SelectedItem = item.SubItems[3].Text;
            }
        }

        private void LoadTasks()
        {
            lvTugas.Items.Clear();
            var tasks = TaskModel.GetAllByUser(SessionManager.CurrentUserId);

            foreach (var task in tasks)
            {
                var item = new ListViewItem(task.Title);
                item.SubItems.Add(task.Description);
                item.SubItems.Add(task.Deadline.ToShortDateString());
                item.SubItems.Add(task.Status);
                lvTugas.Items.Add(item);
            }
        }

        private void ClearForm()
        {
            txtJudul.Clear();
            txtDeskripsi.Clear();
            dtpDeadline.Value = DateTime.Now;
            cmbStatus.SelectedIndex = 0;
        }
    }
}
