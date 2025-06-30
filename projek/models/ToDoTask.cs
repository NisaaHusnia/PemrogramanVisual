using System;

namespace MyFirstApp.projek.models
{
    public class TodoTask
    {
        public int Id { get; set; }  // optional
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }

        // Tambahkan ini
        public int UserId { get; set; }
    }
}
