using System;
namespace MyFirstApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Judul { get; set; }
        public string Deskripsi { get; set; }
        public DateTime TenggatWaktu { get; set; }
        public bool Selesai { get; set; }
    }
}
