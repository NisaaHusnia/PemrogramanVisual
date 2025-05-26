using MyFirstApp.projek.services;
using MySql.Data.MySqlClient;

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
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            SessionManager.IsLoggedIn = true;
                            SessionManager.Username = username;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
