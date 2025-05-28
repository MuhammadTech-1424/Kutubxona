
using System;
using System.Collections.Generic;
using Kutubxona.Brokers;
using Kutubxona.Models;

namespace Kutubxona.Services
{
    class Register
    {
        public static bool SignIn(string login, string password)
        {
            List<Reader> users = DataProcessor.RetreavingDataFromReaders();
            foreach (Reader user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    Console.WriteLine("Tizimga muvaffaqiyatli kirdingiz!");
                    return true;
                }
            }
            Console.WriteLine("Parol yoki login xato!");
            return false;
        }

        public static bool SignUp(string login, string password)
        {
            List<Reader> users = DataProcessor.RetreavingDataFromReaders();
            foreach (Reader user in users)
            {
                if (user.Login == login)
                {
                    Console.WriteLine("Bunday foydalanuvchi mavjud!");
                    return false;
                }
            }

            Reader newUser = new Reader(login, password);
            DataProcessor.SavingDataToReaders(newUser);
            Console.WriteLine("Ro'yxatdan muvaffaqiyatli o'tildi!");
            return true;
        }
    }
}