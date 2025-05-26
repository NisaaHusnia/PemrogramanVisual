using System;
using System.Windows.Forms;
using MyFirstApp.projek.views; // Tambahkan ini di atas


static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        FormLogin loginForm = new FormLogin();
        Application.Run(loginForm);
    }
}

