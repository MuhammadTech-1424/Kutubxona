using System.Collections.Generic;

namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Janri { get; set; }
        public string Muallifi { get; set; }
        public int Jami { get; set; }
        public int Qolgan { get; set; }
        public List<string> Oquvchilar { get; set; } = new List<string>();
    }
}