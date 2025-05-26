using System;
using System.Windows.Forms;

namespace ToDoListApp.Forms
{
    public partial class TaskListForm : Form
    {
        public TaskListForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.listBoxTasks = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxTasks
            // 
            this.listBoxTasks.FormattingEnabled = true;
            this.listBoxTasks.Location = new System.Drawing.Point(12, 12);
            this.listBoxTasks.Name = "listBoxTasks";
            this.listBoxTasks.Size = new System.Drawing.Size(260, 199);
            this.listBoxTasks.TabIndex = 0;
            // 
            // TaskListForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.listBoxTasks);
            this.Name = "TaskListForm";
            this.Text = "Task List";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox listBoxTasks;
    }
}
