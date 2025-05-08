using System;
using System.Collections.Generic;
using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public class TaskManager
    {
        private readonly DatabaseManager _db;

        public TaskManager()
        {
            var cs = "server=localhost;user=root;password=;database=todolist_db;";
            _db = new DatabaseManager(cs);
        }

        public void Add(string judul, string deskripsi, DateTime? tenggat)
        {
            var t = new TaskItem
            {
                Judul = judul,
                Deskripsi = deskripsi,
                TanggalDibuat = DateTime.Now,
                TenggatWaktu = tenggat,
                Selesai = false
            };
            _db.AddTask(t);
        }

        public List<TaskItem> GetAll() => _db.LoadTasks();

        public void Update(TaskItem t) => _db.UpdateTask(t);

        public void Delete(int id) => _db.DeleteTask(id);
    }
}
