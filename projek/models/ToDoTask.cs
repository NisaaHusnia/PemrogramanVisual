using System;

namespace MyFirstApp.projek.models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; } // Untuk 'tenggat_waktu'
        public string Status { get; set; }     // Tampilkan "Selesai"/"Belum Selesai"
    }
}
