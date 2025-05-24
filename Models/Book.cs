using System;
using System.Collections.Generic;

namespace Kutubxona.Models
{
    class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public ushort TotalNumbers { get; set; }
        public ushort AvailableNumbers { get; set; }
        public List<Reader> BookReaders = new List<Reader>();
    }
}