namespace ToDoListApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtJudul;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.DateTimePicker dtpTenggat;
        private System.Windows.Forms.CheckBox chkSelesai;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView lvTasks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtJudul = new System.Windows.Forms.TextBox();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.dtpTenggat = new System.Windows.Forms.DateTimePicker();
            this.chkSelesai = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lvTasks = new System.Windows.Forms.ListView();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();

            // TableLayoutPanel
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));

            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));

            // txtJudul
            this.txtJudul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(new System.Windows.Forms.Label() { Text = "Judul:", AutoSize = true }, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.txtJudul, 1, 0);

            // txtDeskripsi
            this.txtDeskripsi.Multiline = true;
            this.txtDeskripsi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(new System.Windows.Forms.Label() { Text = "Deskripsi:", AutoSize = true }, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.txtDeskripsi, 1, 1);

            // dtpTenggat
            this.dtpTenggat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(new System.Windows.Forms.Label() { Text = "Tenggat Waktu:", AutoSize = true }, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.dtpTenggat, 1, 2);

            // chkSelesai
            this.chkSelesai.AutoSize = true;
            this.tableLayoutPanel.Controls.Add(new System.Windows.Forms.Label() { Text = "Selesai:", AutoSize = true }, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.chkSelesai, 1, 3);

            // Buttons
            var buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
            buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonPanel.Controls.Add(this.btnAdd);
            buttonPanel.Controls.Add(this.btnEdit);
            buttonPanel.Controls.Add(this.btnDelete);

            this.btnAdd.Text = "Tambah";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Text = "Hapus";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.tableLayoutPanel.Controls.Add(buttonPanel, 1, 4);

            // ListView
            this.lvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTasks.View = System.Windows.Forms.View.Details;
            this.lvTasks.FullRowSelect = true;
            this.lvTasks.MultiSelect = false;
            this.lvTasks.SelectedIndexChanged += new System.EventHandler(this.lvTasks_SelectedIndexChanged);

            this.lvTasks.Columns.Add("ID", 40);
            this.lvTasks.Columns.Add("Judul", 120);
            this.lvTasks.Columns.Add("Deskripsi", 150);
            this.lvTasks.Columns.Add("Tanggal Dibuat", 120);
            this.lvTasks.Columns.Add("Tenggat", 120);
            this.lvTasks.Columns.Add("Selesai", 60);

            // MainForm
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "To-Do List Profesional";
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.lvTasks);
            this.Controls.Add(this.tableLayoutPanel);
        }
    }
}
