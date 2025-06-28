using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MyFirstApp.projek.Utilities;

namespace MyFirstApp.projek.models
{
    public static class TaskModel
    {
        public static bool Add(TodoTask task)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO tugas (judul, deskripsi, tenggat_waktu, selesai) VALUES (@judul, @deskripsi, @tenggat_waktu, @selesai)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@judul", task.Title);
                    cmd.Parameters.AddWithValue("@deskripsi", task.Description);
                    cmd.Parameters.AddWithValue("@tenggat_waktu", task.Deadline);
                    cmd.Parameters.AddWithValue("@selesai", task.Status == "Selesai" ? 1 : 0);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Update(string oldTitle, TodoTask task)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "UPDATE tugas SET judul = @judul, deskripsi = @deskripsi, tenggat_waktu = @tenggat_waktu, selesai = @selesai WHERE judul = @oldTitle";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@judul", task.Title);
                    cmd.Parameters.AddWithValue("@deskripsi", task.Description);
                    cmd.Parameters.AddWithValue("@tenggat_waktu", task.Deadline);
                    cmd.Parameters.AddWithValue("@selesai", task.Status == "Selesai" ? 1 : 0);
                    cmd.Parameters.AddWithValue("@oldTitle", oldTitle);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Delete(string title)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM tugas WHERE judul = @judul";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@judul", title);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<TodoTask> GetAll()
        {
            List<TodoTask> list = new List<TodoTask>();
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM tugas ORDER BY tenggat_waktu ASC";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TodoTask
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Title = reader["judul"].ToString(),
                            Description = reader["deskripsi"].ToString(),
                            Deadline = Convert.ToDateTime(reader["tenggat_waktu"]),
                            Status = Convert.ToInt32(reader["selesai"]) == 1 ? "Selesai" : "Belum Selesai"
                        });
                    }
                }
            }
            return list;
        }
    }
}
