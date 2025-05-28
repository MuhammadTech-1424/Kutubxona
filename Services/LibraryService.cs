using Models;
using Data;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class LibraryService
    {
        private readonly DataStore _dataStore;

        public LibraryService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Book> GetBooks() => _dataStore.LoadBooks();

        public Book GetBookById(int id) => GetBooks().FirstOrDefault(b => b.Id == id);

        public void BorrowBook(int bookId, User user)
        {
            var books = _dataStore.LoadBooks();
            var book = books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && book.AvailableCount > 0)
            {
                book.AvailableCount--;
                book.ReadingUsers.Add(user.FirstName);
                _dataStore.SaveBooks(books);

                var users = _dataStore.LoadUsers();
                var currentUser = users.FirstOrDefault(u => u.Id == user.Id);
                currentUser?.BorrowedBooks.Add(book.Title);
                _dataStore.SaveUsers(users);
            }
        }

        public void ReturnBook(int bookId, User user)
        {
            var books = _dataStore.LoadBooks();
            var book = books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && user.BorrowedBooks.Contains(book.Title))
            {
                book.AvailableCount++;
                book.ReadingUsers.Remove(user.FirstName);
                _dataStore.SaveBooks(books);

                var users = _dataStore.LoadUsers();
                var currentUser = users.FirstOrDefault(u => u.Id == user.Id);
                currentUser?.BorrowedBooks.Remove(book.Title);
                _dataStore.SaveUsers(users);
            }
        }
    }
}