using System;
using System.Collections.Generic; // <-- WAJIB untuk List<>
using MyFirstApp.projek.models;

namespace MyFirstApp.projek.controllers
{
    public class TaskController
    {
        public void SimpanTugas(TodoTask task)
        {
            TaskModel.Add(task);
        }

        public bool EditTugas(string oldTitle, TodoTask updatedTask)
        {
            return TaskModel.Update(oldTitle, updatedTask);
        }

        public bool HapusTugas(string title)
        {
            return TaskModel.Delete(title);
        }

        public List<TodoTask> AmbilSemuaTugas()
        {
            return TaskModel.GetAll();
        }
    }
}
