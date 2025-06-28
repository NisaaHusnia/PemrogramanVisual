using MySql.Data.MySqlClient;
using MyFirstApp.projek.Utilities;

namespace MyFirstApp.projek.controllers
{
    public class AuthController
    {
        public bool Login(string username, string password)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM users WHERE username = @username AND password = @password";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // langsung cocokkan plaintext

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.HasRows; // login berhasil jika ada hasil
                }
            }
        }
    }
}
