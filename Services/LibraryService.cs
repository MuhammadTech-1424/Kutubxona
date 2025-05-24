using System;
using Kutubxona.Brokers;

namespace Kutubxona.Services
{
    class LibraryService
    {
        Data LibraryData = new Data();

        public bool SignIn()
        {
            Console.Write("Login: ");
            string login = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            return login == "admin" && password == "admin";
        }

        public bool SignUp()
        {
            Console.Write("Login: ");
            string login = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            return login == "admin" && password == "admin";
        }
        
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\t 1. Kitoblar ro'yxatini ko'rish" + "\n\t 2. Kitob haqida ma'lumot" + "\n\t 3. Kitobni olish" + "\n\t 4. Kitobni qaytarish" + "\n\t 5. Chiqish" + "\t Tanlang: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Kitoblar ro'yxati");

                        foreach (var book in LibraryData.Books)
                        {

                        }
                        break;
                }              
            }
        }

        public bool Exit(bool exit)
        {
            Console.WriteLine("Chiqish qilindi!");
            return exit = false;
        }
    }
}