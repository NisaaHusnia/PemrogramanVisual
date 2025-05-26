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
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(180, 450);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 410);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 40);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnTambahTugas
            // 
            this.btnTambahTugas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTambahTugas.FlatAppearance.BorderSize = 0;
            this.btnTambahTugas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahTugas.ForeColor = System.Drawing.Color.White;
            this.btnTambahTugas.Location = new System.Drawing.Point(0, 120);
            this.btnTambahTugas.Name = "btnTambahTugas";
            this.btnTambahTugas.Size = new System.Drawing.Size(180, 40);
            this.btnTambahTugas.TabIndex = 2;
            this.btnTambahTugas.Text = "Tambah Tugas";
            this.btnTambahTugas.UseVisualStyleBackColor = true;
            this.btnTambahTugas.Click += new System.EventHandler(this.btnTambahTugas_Click);
            // 
            // btnDaftarTugas
            // 
            this.btnDaftarTugas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDaftarTugas.FlatAppearance.BorderSize = 0;
            this.btnDaftarTugas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaftarTugas.ForeColor = System.Drawing.Color.White;
            this.btnDaftarTugas.Location = new System.Drawing.Point(0, 80);
            this.btnDaftarTugas.Name = "btnDaftarTugas";
            this.btnDaftarTugas.Size = new System.Drawing.Size(180, 40);
            this.btnDaftarTugas.TabIndex = 1;
            this.btnDaftarTugas.Text = "Daftar Tugas";
            this.btnDaftarTugas.UseVisualStyleBackColor = true;
            this.btnDaftarTugas.Click += new System.EventHandler(this.btnDaftarTugas_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(180, 80);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(180, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(620, 450);
            this.panelContent.TabIndex = 1;
            // 
            // FormDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.Name = "FormDashboard";
            this.Text = "Dashboard";
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
