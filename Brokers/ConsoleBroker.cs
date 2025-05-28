using Models;
using Services;

namespace Brokers
{
    public class ConsoleBroker
    {
        private readonly UserService _userService;
        private readonly LibraryService _libraryService;

        public ConsoleBroker(UserService userService, LibraryService libraryService)
        {
            _userService = userService;
            _libraryService = libraryService;
        }

        public void Run()
        {
            Console.WriteLine("1. Kirish\n2. Ro'yxatdan o'tish");
            var choice = Console.ReadLine();
            User user = null;

            if (choice == "1")
            {
                Console.Write("Login: "); var login = Console.ReadLine();
                Console.Write("Parol: "); var password = Console.ReadLine();
                user = _userService.Login(login, password);
                if (user == null)
                {
                    Console.WriteLine("Login yoki parol xato"); return;
                }
            }
            else
            {
                Console.Write("Login: "); var login = Console.ReadLine();
                Console.Write("Parol: "); var password = Console.ReadLine();
                Console.Write("Ism: "); var name = Console.ReadLine();
                Console.Write("Familiya: "); var surname = Console.ReadLine();
                Console.Write("Yosh: "); int age = int.Parse(Console.ReadLine());
                user = _userService.Register(login, password, name, surname, age);
            }

            while (true)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Kitoblar ro'yxatini ko'rish");
                Console.WriteLine("2. Kitob haqida ma'lumot");
                Console.WriteLine("3. Kitob olish");
                Console.WriteLine("4. Kitobni qaytarish");
                Console.Write("Tanlang: ");

                var input = Console.ReadLine();
                if (input == "1")
                {
                    var books = _libraryService.GetBooks();
                    books.ForEach(b => Console.WriteLine($"{b.Id}. {b.Title} ({b.AvailableCount}/{b.TotalCount})"));
                }
                else if (input == "2")
                {
                    Console.Write("Kitob ID: "); int id = int.Parse(Console.ReadLine());
                    var book = _libraryService.GetBookById(id);
                    Console.WriteLine(book != null ? $"Nomi: {book.Title}, Muallifi: {book.Author}, Janri: {book.Genre}" : "Topilmadi");
                }
                else if (input == "3")
                {
                    Console.Write("Kitob ID: "); int id = int.Parse(Console.ReadLine());
                    _libraryService.BorrowBook(id, user);
                }
                else if (input == "4")
                {
                    Console.Write("Kitob ID: "); int id = int.Parse(Console.ReadLine());
                    _libraryService.ReturnBook(id, user);
                }
            }
        }
    }
} 