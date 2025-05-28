using System.Collections.Generic;

namespace Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int TotalCount { get; set; }
        public int AvailableCount { get; set; }
        public List<string> ReadingUsers { get; set; } = new List<string>();
    }
}