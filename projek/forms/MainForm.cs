using System;
using System.Windows.Forms;
using ToDoListApp.Services;

namespace ToDoListApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly TaskManager _taskManager = new();

        public MainForm()
        {
            InitializeComponent();
            UpdateTaskList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTaskTitle.Text.Trim();
            if (!string.IsNullOrEmpty(title))
            {
                _taskManager.AddTask(title);
                txtTaskTitle.Clear();
                UpdateTaskList();
            }
            else
            {
                MessageBox.Show("Judul tugas tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex >= 0)
            {
                _taskManager.MarkTaskAsCompleted(lstTasks.SelectedIndex);
                UpdateTaskList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex >= 0)
            {
                _taskManager.RemoveTask(lstTasks.SelectedIndex);
                UpdateTaskList();
            }
        }

        private void UpdateTaskList()
        {
            lstTasks.Items.Clear();
            foreach (var task in _taskManager.Tasks)
            {
                lstTasks.Items.Add(task.ToString());
            }
        }
    }
}
