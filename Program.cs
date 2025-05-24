using System;
using System.Reflection.Metadata;
using Kutubxona.Services;

LibraryService MyLibrary = new LibraryService();

while (true)
{
    Console.WriteLine(" \t <<< KUTUBXONA >>> \n ");
    Console.WriteLine("Assalom a'laykum, Kutubxonamizga xush kelibsiz!");
    Console.WriteLine("\n1. Kirish" + "\n2. Ro'yxatdan o'tish" + "\t Tanlang: ");

    string key = Console.ReadLine();
    switch (key)
    {
        case "1":
            MyLibrary.SignIn();
            Console.WriteLine();

            bool exit = true;
            while (exit)
            {
                Console.WriteLine(" \t <<< KUTUBXONA >>> \n ");
                Console.WriteLine("\n1. Ro'yxat" + "\n2. CHIQISH" + "\t Tanlang: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        MyLibrary.Menu();
                        Console.WriteLine();
                        break;
                    case "2":
                        MyLibrary.Exit(exit);
                        break;
                    default:
                        Console.WriteLine("Noto'g'ri ma'lumot kiritildi!");
                        Console.WriteLine();
                        break;
                }
            }
            break;

        case "2":
            MyLibrary.SignUp();
            Console.WriteLine();
            break;

        default:
            Console.WriteLine("Noto'g'ri ma'lumot kiritildi!");
            Console.WriteLine();
            break;
    }
}