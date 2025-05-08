using System;

namespace ToDoListApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Judul { get; set; }
        public string Deskripsi { get; set; }
        public DateTime TanggalDibuat { get; set; }
        public DateTime? TenggatWaktu { get; set; }
        public bool Selesai { get; set; }
    }
}
