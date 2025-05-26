using System;

namespace YourNamespace
{
    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }  // DateTime seharusnya dikenali di sini
        public bool Completed { get; set; }

        // Konstruktor
        public TaskItem(string title, string description, DateTime deadline, bool completed)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            Completed = completed;
        }
    }
}
