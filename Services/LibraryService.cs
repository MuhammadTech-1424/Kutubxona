
using System;
using System.Collections.Generic;
using Kutubxona.Brokers;
using Kutubxona.Models;

namespace Kutubxona.Services
{
    class LibraryService
    {
        public static void BookList()
        {
            List<Book> bookList = DataProcessor.RetreavingDataFromBooks();
            foreach (Book book in bookList)
            {
                Console.WriteLine($"'{book.Id}': {book.Name} ({book.Author})");
            }    
        }
    }
}