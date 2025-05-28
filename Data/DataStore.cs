using Models;
using System.Text.Json;

namespace Data
{
    public class DataStore
    {
        private const string BooksFile = "books.json";
        private const string UsersFile = "users.json";

        public List<Book> LoadBooks() => 
            File.Exists(BooksFile) ? JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(BooksFile)) : new List<Book>();

        public void SaveBooks(List<Book> books) => 
            File.WriteAllText(BooksFile, JsonSerializer.Serialize(books));

        public List<User> LoadUsers() => 
            File.Exists(UsersFile) ? JsonSerializer.Deserialize<List<User>>(File.ReadAllText(UsersFile)) : new List<User>();

        public void SaveUsers(List<User> users) => 
            File.WriteAllText(UsersFile, JsonSerializer.Serialize(users));
    }
}
