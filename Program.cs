using System;
using Kutubxona.Services;

while (true)
{
    Console.WriteLine(" \t Kutubxonamizga xush kelibsiz! \n");
    Console.WriteLine("1. Kirish" + "\n2. Ro'yxatdan o'tish");
    Console.Write(" \t Bo'limni tanlang: ");

    string choice1 = Console.ReadLine();
    switch (choice1)
    {
        case "1":
        Console.Write(" \t Loginni kiriting: ");
        string login1 = Console.ReadLine();
        Console.Write(" \t Parolni kiriting: ");
        string password1 = Console.ReadLine();

            if (Register.SignIn(login1, password1))
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine(" \t <<< KUTUBXONA >>> ");
                    Console.WriteLine(" \t Menu: ");
                    LibraryService.BookList();

                    Console.Write(" \t Kitobni tanlang: ");
                    string bookId = Console.ReadLine();
                    
                }
            }
            Console.WriteLine();
            break;

        case "2":
            Console.Write(" \t Loginni kiriting: ");
            string login2 = Console.ReadLine();
            Console.Write(" \t Parolni kiriting: ");
            string password2 = Console.ReadLine();   

            if (Register.SignUp(login2, password2))
            {
                Console.WriteLine("Tizimga qayta kiring!");
            }
            Console.WriteLine();
            break;

        default:
            Console.WriteLine("Noto'g'ri ma'lumot kiritildi!");
            Console.WriteLine();
            break;
    }
}