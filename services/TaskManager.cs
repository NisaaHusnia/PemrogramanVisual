using System.Collections.Generic;
using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public class TaskManager
    {
        private readonly List<TaskItem> _tasks = new();

        public IReadOnlyList<TaskItem> Tasks => _tasks.AsReadOnly();

        public void AddTask(string title)
        {
            var task = new TaskItem(title);
            _tasks.Add(task);
        }

        public void MarkTaskAsCompleted(int index)
        {
            if (IsValidIndex(index))
                _tasks[index].MarkAsCompleted();
        }

        public void RemoveTask(int index)
        {
            if (IsValidIndex(index))
                _tasks.RemoveAt(index);
        }

        private bool IsValidIndex(int index) => index >= 0 && index < _tasks.Count;
    }
}
