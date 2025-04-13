using System;
using Microsoft.Data.SqlClient;  // Ganti dengan Microsoft.Data.SqlClient
using System.Windows.Forms;

namespace ToDoListApp.Database
{
    public class DatabaseConnector
    {
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=tododb;Trusted_Connection=True;";

        public void TestConnection()
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);  // Perubahan di sini
                connection.Open();
                MessageBox.Show("Koneksi ke database berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal terkoneksi ke database:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
