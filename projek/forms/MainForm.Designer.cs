using System.Windows.Forms;

namespace ToDoListApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtTaskTitle;
        private Button btnAdd;
        private Button btnComplete;
        private Button btnDelete;
        private Button btnTestDb;
        private ListBox lstTasks;

        /// <summary>
        /// Membersihkan sumber daya yang sedang digunakan.
        /// </summary>
        /// <param name="disposing">true jika sumber daya yang dikelola harus dibuang; jika tidak, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Metode yang diperlukan untuk dukungan Desainer - jangan modifikasi
        /// isi metode ini dengan editor kode.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnTestDb = new System.Windows.Forms.Button();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtTaskTitle
            // 
            this.txtTaskTitle.Location = new System.Drawing.Point(12, 12);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(260, 20);
            this.txtTaskTitle.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(278, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Tambah";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(12, 226);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(75, 23);
            this.btnComplete.TabIndex = 2;
            this.btnComplete.Text = "Selesai";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(93, 226);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Hapus";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnTestDb
            // 
            this.btnTestDb.Location = new System.Drawing.Point(174, 226);
            this.btnTestDb.Name = "btnTestDb";
            this.btnTestDb.Size = new System.Drawing.Size(100, 23);
            this.btnTestDb.TabIndex = 4;
            this.btnTestDb.Text = "Test Koneksi DB";
            this.btnTestDb.UseVisualStyleBackColor = true;
            this.btnTestDb.Click += new System.EventHandler(this.btnTestDb_Click);
            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(12, 38);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(341, 173);
            this.lstTasks.TabIndex = 5;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(365, 261);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.btnTestDb);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtTaskTitle);
            this.Name = "MainForm";
            this.Text = "Aplikasi To-Do List";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
