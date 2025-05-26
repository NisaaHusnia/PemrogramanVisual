using MySql.Data.MySqlClient;

namespace MyFirstApp
{
    public static class DatabaseManager
    {
        private static string connectionString = "server=localhost;database=todolist_db;uid=root;pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
