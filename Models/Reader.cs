using System.Collections.Generic;

namespace LibraryApp.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Parol { get; set; }
        public string Ism { get; set; }
        public string Familya { get; set; }
        public int Yosh { get; set; }
        public int OlinganKitoblarSoni => OlinganKitoblar.Count;
        public List<string> OlinganKitoblar { get; set; } = new List<string>();
    }
}