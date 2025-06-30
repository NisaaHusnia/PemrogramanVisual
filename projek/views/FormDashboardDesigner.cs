namespace MyFirstApp.projek.views
{
    partial class FormDashboard : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnDaftarTugas;
        private System.Windows.Forms.Button btnTambahTugas;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblAppTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnTambahTugas = new System.Windows.Forms.Button();
            this.btnDaftarTugas = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();

            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnTambahTugas);
            this.panelSidebar.Controls.Add(this.btnDaftarTugas);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.lblAppTitle);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(180, 600);
            this.panelSidebar.TabIndex = 0;

            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAppTitle.Text = "📌 ToDoList App";
            this.lblAppTitle.Height = 60;
            this.lblAppTitle.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);

            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Text = "📊 Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDashboard.Height = 40;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);

            // 
            // btnDaftarTugas
            // 
            this.btnDaftarTugas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDaftarTugas.FlatAppearance.BorderSize = 0;
            this.btnDaftarTugas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaftarTugas.ForeColor = System.Drawing.Color.White;
            this.btnDaftarTugas.Text = "📋 Daftar Tugas";
            this.btnDaftarTugas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDaftarTugas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDaftarTugas.Height = 40;
            this.btnDaftarTugas.Click += new System.EventHandler(this.btnDaftarTugas_Click);

            // 
            // btnTambahTugas
            // 
            this.btnTambahTugas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTambahTugas.FlatAppearance.BorderSize = 0;
            this.btnTambahTugas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahTugas.ForeColor = System.Drawing.Color.White;
            this.btnTambahTugas.Text = "➕ Tambah Tugas";
            this.btnTambahTugas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTambahTugas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTambahTugas.Height = 40;
            this.btnTambahTugas.Click += new System.EventHandler(this.btnTambahTugas_Click);

            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogout.Height = 40;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(180, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(820, 600);
            this.panelContent.TabIndex = 1;

            // 
            // FormDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable; // bisa resize
            this.MaximizeBox = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "FormDashboard";
            this.Text = "Dashboard";

            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
