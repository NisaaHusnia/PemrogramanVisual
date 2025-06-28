using System;
using MySql.Data.MySqlClient;

namespace MyFirstApp.projek.Utilities
{
    public static class DatabaseManager
    {
        private static string _connectionString;

        public static void Initialize(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static MySqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new InvalidOperationException("DatabaseManager belum diinisialisasi.");

            return new MySqlConnection(_connectionString);
        }
    }
}
