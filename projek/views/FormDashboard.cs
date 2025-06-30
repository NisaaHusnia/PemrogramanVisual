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

        public void LoadDashboardView()
        {
            LoadView(new DashboardView());
        }

        public void LoadTambahTugasView()
        {
            LoadView(new TambahTugasView());
        }

        public void LoadDaftarTugasView()
        {
            LoadView(new DaftarTugasView());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboardView();
        }

        private void btnTambahTugas_Click(object sender, EventArgs e)
        {
            LoadTambahTugasView();
        }

        private void btnDaftarTugas_Click(object sender, EventArgs e)
        {
            LoadDaftarTugasView();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart(); // Kembali ke FormLogin
        }
    }
}
