using System;
using System.Windows.Forms;
using MyFirstApp.projek.Utilities;
using MyFirstApp.projek.views;

namespace MyFirstApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inisialisasi koneksi database
            DatabaseManager.Initialize("server=localhost;uid=root;pwd=;database=todolist_db");

            // Tampilkan form login
            using (FormLogin loginForm = new FormLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm()); // Masuk ke MainForm jika login berhasil
                }
                else
                {
                    Application.Exit(); // Keluar jika login dibatalkan
                }
            }
        }
    }
}
