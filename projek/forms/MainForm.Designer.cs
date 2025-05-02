using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ToDoListApp.Forms
{
    partial class MainForm
    {
        private IContainer components = null;

        // Semua kontrol dideklarasikan di sini
        private TextBox txtTaskTitle;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnComplete;
        private Button btnDelete;
        private ListBox lstTasks;
        private DateTimePicker dtpDeadline;
        private Label lblTime;

        /// <summary>
        /// Membersihkan sumber daya yang sedang digunakan.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Metode yang diperlukan untuk dukungan Desainer – jangan modifikasi
        /// isi metode ini dengan editor kode.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();

            // txtTaskTitle
            this.txtTaskTitle = new TextBox();
            this.txtTaskTitle.Location = new Point(12, 12);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new Size(260, 20);
            this.txtTaskTitle.TabIndex = 0;

            // dtpDeadline
            this.dtpDeadline = new DateTimePicker();
            this.dtpDeadline.Location = new Point(12, 38);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Format = DateTimePickerFormat.Short;
            this.dtpDeadline.Size = new Size(260, 20);
            this.dtpDeadline.TabIndex = 1;

            // btnAdd
            this.btnAdd = new Button();
            this.btnAdd.Location = new Point(278, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Tambah";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit = new Button();
            this.btnEdit.Location = new Point(278, 38);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            // lstTasks
            this.lstTasks = new ListBox();
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new Point(12, 64);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new Size(341, 156);
            this.lstTasks.TabIndex = 4;

            // btnComplete
            this.btnComplete = new Button();
            this.btnComplete.Location = new Point(12, 226);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new Size(75, 23);
            this.btnComplete.TabIndex = 5;
            this.btnComplete.Text = "Selesai";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new EventHandler(this.btnComplete_Click);

            // btnDelete
            this.btnDelete = new Button();
            this.btnDelete.Location = new Point(93, 226);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Hapus";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            // lblTime
            this.lblTime = new Label();
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new Point(12, 254);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new Size(49, 13);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "00:00:00";

            // MainForm
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(365, 281);
            this.Controls.Add(this.txtTaskTitle);
            this.Controls.Add(this.dtpDeadline);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblTime);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Aplikasi To-Do List";
            this.Load += new EventHandler(this.MainForm_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
