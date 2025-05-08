using System;
using System.Windows.Forms;
using ToDoListApp.Services;
using ToDoListApp.Models;

namespace ToDoListApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly TaskManager taskManager = new TaskManager();
        private int? selectedTaskId = null;

        public MainForm()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void LoadTasks()
        {
            lvTasks.Items.Clear();
            foreach (var task in taskManager.GetAll())
            {
                var item = new ListViewItem(task.Id.ToString());
                item.SubItems.Add(task.Judul);
                item.SubItems.Add(task.Deskripsi);
                item.SubItems.Add(task.TanggalDibuat.ToString("g"));
                item.SubItems.Add(task.TenggatWaktu?.ToString("g") ?? "");
                item.SubItems.Add(task.Selesai ? "✓" : "✗");
                lvTasks.Items.Add(item);
            }
            ClearFields();
        }

        private void ClearFields()
        {
            txtJudul.Text = "";
            txtDeskripsi.Text = "";
            dtpTenggat.Value = DateTime.Now;
            chkSelesai.Checked = false;
            selectedTaskId = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            taskManager.Add(txtJudul.Text, txtDeskripsi.Text, dtpTenggat.Value);
            LoadTasks();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedTaskId != null)
            {
                var task = taskManager.GetAll().Find(t => t.Id == selectedTaskId);
                if (task != null)
                {
                    task.Judul = txtJudul.Text;
                    task.Deskripsi = txtDeskripsi.Text;
                    task.TenggatWaktu = dtpTenggat.Value;
                    task.Selesai = chkSelesai.Checked;
                    taskManager.Update(task);
                    LoadTasks();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTaskId != null)
            {
                taskManager.Delete((int)selectedTaskId);
                LoadTasks();
            }
        }

        private void lvTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTasks.SelectedItems.Count > 0)
            {
                var item = lvTasks.SelectedItems[0];
                selectedTaskId = int.Parse(item.Text);

                txtJudul.Text = item.SubItems[1].Text;
                txtDeskripsi.Text = item.SubItems[2].Text;
                dtpTenggat.Value = DateTime.TryParse(item.SubItems[4].Text, out var t) ? t : DateTime.Now;
                chkSelesai.Checked = item.SubItems[5].Text == "✓";
            }
        }
    }
}
