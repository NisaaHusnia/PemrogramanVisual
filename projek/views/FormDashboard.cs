using System;
using System.Windows.Forms;

namespace MyFirstApp.projek.views
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
            LoadDashboardView();
        }

        private void LoadView(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        private void LoadDashboardView()
        {
            var dashboardView = new DashboardView();
            LoadView(dashboardView);
        }

        private void LoadDaftarTugasView()
        {
            var daftarTugasView = new DaftarTugasView();
            LoadView(daftarTugasView);
        }

        private void LoadTambahTugasView()
        {
            var tambahTugasView = new TambahTugasView();
            LoadView(tambahTugasView);
        }

        // **Event handlers harus ada di sini supaya cocok dengan Designer.cs**
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboardView();
        }

        private void btnDaftarTugas_Click(object sender, EventArgs e)
        {
            LoadDaftarTugasView();
        }

        private void btnTambahTugas_Click(object sender, EventArgs e)
        {
            LoadTambahTugasView();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
