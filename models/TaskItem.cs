using System;

namespace ToDoListApp.Models
{
    public class TaskItem
    {
        public string Title { get; }
        public bool IsCompleted { get; private set; }

        public TaskItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Judul tugas tidak boleh kosong.", nameof(title));

            Title = title;
            IsCompleted = false;
        }

        public void MarkAsCompleted() => IsCompleted = true;

        public override string ToString() => $"{(IsCompleted ? "[X]" : "[ ]")} {Title}";
    }
}
