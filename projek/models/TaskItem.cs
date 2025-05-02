using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ToDoListApp.Models
{
    public class TaskItem : INotifyPropertyChanged
    {
        // Unique identifier for each task
        [JsonInclude]
        public Guid Id { get; private set; } = Guid.NewGuid();

        private string title;
        [JsonInclude]
        public string Title
        {
            get => title;
            private set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isCompleted;
        [JsonInclude]
        public bool IsCompleted
        {
            get => isCompleted;
            private set
            {
                if (isCompleted != value)
                {
                    isCompleted = value;
                    if (isCompleted)
                        CompletedAt = DateTime.Now;
                    else
                        CompletedAt = null;
                    OnPropertyChanged();
                }
            }
        }

        [JsonInclude]
        public DateTime CreatedAt { get; private set; }

        [JsonInclude]
        public DateTime? Deadline { get; set; }

        [JsonInclude]
        public DateTime? CompletedAt { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        // Method to raise the PropertyChanged event
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        // Constructor to initialize a TaskItem
        public TaskItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Judul tugas tidak boleh kosong.", nameof(title));

            Title = title;
            CreatedAt = DateTime.Now;
            isCompleted = false;
        }

        // Rename method to change the task title
        public void Rename(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Judul tugas tidak boleh kosong.", nameof(newTitle));
            Title = newTitle;
        }

        // Mark task as completed
        public void MarkAsCompleted() => IsCompleted = true;

        // Mark task as pending (not completed)
        public void MarkAsPending() => IsCompleted = false;

        // Override ToString to display task details
        public override string ToString()
            => $"{(IsCompleted ? "[X]" : "[ ]")} {Title} | Created: {CreatedAt:dd/MM/yyyy HH:mm} | Deadline: {(Deadline.HasValue ? Deadline.Value.ToString("dd/MM/yyyy") : "None")}";
    }
}
