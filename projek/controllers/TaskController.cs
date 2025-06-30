using System;
using System.Collections.Generic;
using MyFirstApp.projek.models;
using MyFirstApp.projek.Utilities;

namespace MyFirstApp.projek.controllers
{
    public class TaskController
    {
        public void SimpanTugas(TodoTask task)
        {
            // Tambahkan userId dari session ke task
            task.UserId = SessionManager.CurrentUserId;
            TaskModel.Add(task);
        }

        public bool EditTugas(string oldTitle, TodoTask updatedTask)
        {
            // Pastikan user yang mengedit adalah user yang login
            updatedTask.UserId = SessionManager.CurrentUserId;
            return TaskModel.Update(oldTitle, updatedTask);
        }

        public bool HapusTugas(string title)
        {
            // Kirim userId untuk validasi penghapusan berdasarkan user
            return TaskModel.Delete(title, SessionManager.CurrentUserId);
        }

        public List<TodoTask> AmbilSemuaTugas()
        {
            // Hanya ambil tugas milik user yang sedang login
            return TaskModel.GetAllByUser(SessionManager.CurrentUserId);
        }
    }
}
