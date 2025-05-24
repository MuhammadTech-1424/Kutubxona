using System;
using System.Collections.Generic;

namespace Kutubxona.Models
{
    class Reader
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ushort Age { get; set; }
        public ushort NumberRecieved { get; set; }
        public List<Book> Books = new List<Book>();
    }
}