using System;
using System.Windows.Forms;
using ToDoListApp.Database;
using ToDoListApp.Models;

namespace ToDoListApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly TaskManager _taskManager = new();

        public MainForm()
        {
            InitializeComponent();
            InitializeTimer();
        }

        // Initialize the timer for updating the clock
        private void InitializeTimer()
        {
            var timer = new Timer { Interval = 1000 }; // Update every second
            timer.Tick += (s, e) => lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();
        }

        // Load existing tasks on form load
        private void MainForm_Load(object sender, EventArgs e)
        {
            _taskManager.LoadFromFile("tasks.json");
            UpdateTaskList();
        }

        // Add a new task
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var title = txtTaskTitle.Text.Trim();
            if (!string.IsNullOrEmpty(title))
            {
                var task = new TaskItem(title) { Deadline = dtpDeadline.Value };
                _taskManager.AddTask(task);
                txtTaskTitle.Clear();
                UpdateTaskList();
            }
            else
            {
                MessageBox.Show("Judul tugas tidak boleh kosong.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Edit selected task
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int idx = lstTasks.SelectedIndex;
            if (idx >= 0)
            {
                var newTitle = Prompt.ShowDialog("Edit Judul", "Masukkan judul baru:",
                    _taskManager.Tasks[idx].Title);
                if (!string.IsNullOrWhiteSpace(newTitle))
                {
                    _taskManager.EditTaskTitle(idx, newTitle);
                    _taskManager.Tasks[idx].Deadline = dtpDeadline.Value;
                    UpdateTaskList();
                }
            }
        }

        // Mark selected task as completed
        private void btnComplete_Click(object sender, EventArgs e)
        {
            int idx = lstTasks.SelectedIndex;
            if (idx >= 0)
            {
                _taskManager.MarkTaskAsCompleted(idx);
                UpdateTaskList();
            }
        }

        // Delete selected task
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idx = lstTasks.SelectedIndex;
            if (idx >= 0)
            {
                _taskManager.RemoveTask(idx);
                UpdateTaskList();
            }
        }

        // Update list box
        private void UpdateTaskList()
        {
            lstTasks.Items.Clear();
            foreach (var task in _taskManager.Tasks)
            {
                var status = task.IsCompleted ? "[X]" : "[ ]";
                var dl = task.Deadline.HasValue
                    ? task.Deadline.Value.ToString("dd/MM/yyyy")
                    : "No deadline";
                lstTasks.Items.Add(
                    $"{status} {task.Title} | Created: {task.CreatedAt:dd/MM/yyyy HH:mm} | Deadline: {dl}"
                );
            }
        }

        // Save tasks when closing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _taskManager.SaveToFile("tasks.json");
            base.OnFormClosing(e);
        }
    }
}
