using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ToDoListApp.Models;

namespace ToDoListApp.Database
{
    public class TaskManager
    {
        private readonly List<TaskItem> _tasks = new();

        public IReadOnlyList<TaskItem> Tasks => _tasks.AsReadOnly();

        // Add a task
        public void AddTask(TaskItem task)
        {
            _tasks.Add(task);
        }

        // Mark task as completed
        public void MarkTaskAsCompleted(int index)
        {
            if (IsValidIndex(index))
                _tasks[index].MarkAsCompleted();
        }

        // Remove a task
        public void RemoveTask(int index)
        {
            if (IsValidIndex(index))
                _tasks.RemoveAt(index);
        }

        // Edit the task title
        public void EditTaskTitle(int index, string newTitle)
        {
            if (IsValidIndex(index))
                _tasks[index].Rename(newTitle);
        }

        // Load tasks from a file
        public void LoadFromFile(string path)
        {
            if (File.Exists(path))
            {
                var tasks = JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(path));
                _tasks.Clear();
                _tasks.AddRange(tasks);
            }
        }

        // Save tasks to a file
        public void SaveToFile(string path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(path, JsonSerializer.Serialize(_tasks, options));
        }

        // Check if the index is valid
        private bool IsValidIndex(int index) => index >= 0 && index < _tasks.Count;
    }
}
