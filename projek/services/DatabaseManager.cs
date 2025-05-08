using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public class DatabaseManager
    {
        private readonly MySqlConnection _conn;

        public DatabaseManager(string cs)
        {
            _conn = new MySqlConnection(cs);
            _conn.Open();
            CreateTable();
        }

        public void CreateTable()
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS tugas (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    judul VARCHAR(255) NOT NULL,
                    deskripsi TEXT,
                    tanggal_dibuat DATETIME NOT NULL,
                    tenggat_waktu DATETIME NULL,
                    selesai BOOLEAN NOT NULL DEFAULT FALSE
                );";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.ExecuteNonQuery();
        }

        public void AddTask(TaskItem t)
        {
            string sql = @"
                INSERT INTO tugas (judul, deskripsi, tanggal_dibuat, tenggat_waktu, selesai)
                VALUES (@j, @d, @td, @tw, @s);";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.Parameters.AddWithValue("@j", t.Judul);
            cmd.Parameters.AddWithValue("@d", t.Deskripsi);
            cmd.Parameters.AddWithValue("@td", t.TanggalDibuat);
            cmd.Parameters.AddWithValue("@tw", t.TenggatWaktu ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@s", t.Selesai);
            cmd.ExecuteNonQuery();
            t.Id = (int)cmd.LastInsertedId;
        }

        public List<TaskItem> LoadTasks()
        {
            var list = new List<TaskItem>();
            string sql = "SELECT * FROM tugas ORDER BY tanggal_dibuat DESC;";
            using var cmd = new MySqlCommand(sql, _conn);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new TaskItem
                {
                    Id = r.GetInt32("id"),
                    Judul = r.GetString("judul"),
                    Deskripsi = r.GetString("deskripsi"),
                    TanggalDibuat = r.GetDateTime("tanggal_dibuat"),
                    TenggatWaktu = r.IsDBNull(r.GetOrdinal("tenggat_waktu"))
                        ? (DateTime?)null
                        : r.GetDateTime("tenggat_waktu"),
                    Selesai = r.IsDBNull(r.GetOrdinal("selesai"))
                        ? false
                        : r.GetBoolean("selesai")
                });
            }
            return list;
        }

        public void UpdateTask(TaskItem t)
        {
            string sql = @"
                UPDATE tugas SET
                  judul = @j,
                  deskripsi = @d,
                  tenggat_waktu = @tw,
                  selesai = @s
                WHERE id = @id;";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.Parameters.AddWithValue("@j", t.Judul);
            cmd.Parameters.AddWithValue("@d", t.Deskripsi);
            cmd.Parameters.AddWithValue("@tw", t.TenggatWaktu ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@s", t.Selesai);
            cmd.Parameters.AddWithValue("@id", t.Id);
            cmd.ExecuteNonQuery();
        }

        public void DeleteTask(int id)
        {
            string sql = "DELETE FROM tugas WHERE id = @id;";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
