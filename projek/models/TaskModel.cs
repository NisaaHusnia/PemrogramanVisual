using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MyFirstApp.projek.Utilities;

namespace MyFirstApp.projek.models
{
    public static class TaskModel
    {
        // Tambah tugas dengan user_id
        public static bool Add(TodoTask task)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO tugas 
                                (judul, deskripsi, tenggat_waktu, selesai, user_id) 
                                 VALUES (@judul, @deskripsi, @tenggat_waktu, @selesai, @user_id)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@judul", task.Title);
                    cmd.Parameters.AddWithValue("@deskripsi", task.Description);
                    cmd.Parameters.AddWithValue("@tenggat_waktu", task.Deadline);
                    cmd.Parameters.AddWithValue("@selesai", task.Status == "Selesai" ? 1 : 0);
                    cmd.Parameters.AddWithValue("@user_id", task.UserId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Update tugas milik user
        public static bool Update(string oldTitle, TodoTask task)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE tugas SET 
                                    judul = @judul, 
                                    deskripsi = @deskripsi, 
                                    tenggat_waktu = @tenggat_waktu, 
                                    selesai = @selesai 
                                 WHERE judul = @oldTitle AND user_id = @user_id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@judul", task.Title);
                    cmd.Parameters.AddWithValue("@deskripsi", task.Description);
                    cmd.Parameters.AddWithValue("@tenggat_waktu", task.Deadline);
                    cmd.Parameters.AddWithValue("@selesai", task.Status == "Selesai" ? 1 : 0);
                    cmd.Parameters.AddWithValue("@oldTitle", oldTitle);
                    cmd.Parameters.AddWithValue("@user_id", task.UserId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Hapus berdasarkan judul dan user_id
        public static bool Delete(string title, int userId)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM tugas WHERE judul = @judul AND user_id = @user_id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@judul", title);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Ambil semua tugas user tertentu
        public static List<TodoTask> GetAllByUser(int userId)
        {
            List<TodoTask> list = new List<TodoTask>();
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM tugas WHERE user_id = @user_id ORDER BY tenggat_waktu ASC";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", userId);

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
                                Status = Convert.ToInt32(reader["selesai"]) == 1 ? "Selesai" : "Belum Selesai",
                                UserId = Convert.ToInt32(reader["user_id"])
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
