using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using LibraryApp.Models;

string booksFile = "Data/books.json";
string readersFile = "Data/readers.json";
List<Book> books = LoadBooks();
List<Reader> readers = LoadReaders();
Reader? currentReader = null;

// Boshlanish
Console.WriteLine("Kutubxonaga xush kelibsiz!");
Console.Write("1. Kirish\n2. Ro'yxatdan o'tish\nTanlang: ");
string tanlov = Console.ReadLine() ?? "1";
if (tanlov == "2") Register();
else Login();

if (currentReader != null)
    ShowMenu();

void ShowMenu()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== MENU ===");
        Console.WriteLine("1. Kitoblar ro'yxatini ko'rish");
        Console.WriteLine("2. Kitob haqida ma'lumot olish");
        Console.WriteLine("3. Kitob olish");
        Console.WriteLine("4. Kitobni qaytarish");
        Console.WriteLine("0. Chiqish");
        Console.Write("Tanlovingiz: ");
        var input = Console.ReadLine();
        switch (input)
        {
            case "1": ShowBooks(); break;
            case "2": ShowBookInfo(); break;
            case "3": TakeBook(); break;
            case "4": ReturnBook(); break;
            case "0": SaveData(); return;
        }
    }
}

void ShowBooks()
{
    Console.Clear();
    Console.WriteLine("=== Kitoblar ro'yxati ===");
    foreach (var book in books)
        Console.WriteLine($"{book.Id}. {book.Nomi} ({book.Qolgan}/{book.Jami})");
    Console.WriteLine("Davom etish uchun ENTER bosing...");
    Console.ReadLine();
}

void ShowBookInfo()
{
    ShowBooks();
    Console.Write("Qaysi kitob? ID kiriting: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            Console.WriteLine($"Nomi: {book.Nomi}\nJanr: {book.Janri}\nMuallif: {book.Muallifi}\nQolgan: {book.Qolgan}/{book.Jami}");
            Console.WriteLine("O'qiyotganlar: " + string.Join(", ", book.Oquvchilar));
        }
    }
    Console.WriteLine("Davom etish uchun ENTER bosing...");
    Console.ReadLine();
}

void TakeBook()
{
    ShowBooks();
    Console.Write("Olish uchun kitob ID sini kiriting: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book != null && book.Qolgan > 0)
        {
            if (!currentReader.OlinganKitoblar.Contains(book.Nomi))
            {
                book.Qolgan--;
                book.Oquvchilar.Add(currentReader.Ism);
                currentReader.OlinganKitoblar.Add(book.Nomi);
                Console.WriteLine("Kitob olindi!");
            }
            else Console.WriteLine("Bu kitob sizda mavjud.");
        }
        else Console.WriteLine("Kitob mavjud emas.");
    }
    Console.ReadLine();
}

void ReturnBook()
{
    Console.WriteLine("Sizda mavjud kitoblar:");
    for (int i = 0; i < currentReader.OlinganKitoblar.Count; i++)
        Console.WriteLine($"{i + 1}. {currentReader.OlinganKitoblar[i]}");
    Console.Write("Qaysi kitobni qaytarmoqchisiz? Raqamini kiriting: ");
    if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= currentReader.OlinganKitoblar.Count)
    {
        string bookName = currentReader.OlinganKitoblar[index - 1];
        var book = books.FirstOrDefault(b => b.Nomi == bookName);
        if (book != null)
        {
            book.Qolgan++;
            book.Oquvchilar.Remove(currentReader.Ism);
            currentReader.OlinganKitoblar.Remove(bookName);
            Console.WriteLine("Kitob qaytarildi.");
        }
    }
    Console.ReadLine();
}

void Login()
{
    Console.Write("Login: ");
    string login = Console.ReadLine() ?? "";
    Console.Write("Parol: ");
    string parol = Console.ReadLine() ?? "";
    currentReader = readers.FirstOrDefault(r => r.Login == login && r.Parol == parol);
    if (currentReader == null)
    {
        Console.WriteLine("Noto'g'ri login yoki parol!");
        Environment.Exit(0);
    }
}

void Register()
{
    Reader r = new();
    r.Id = readers.Count + 1;
    Console.Write("Yangi login: ");
    r.Login = Console.ReadLine() ?? "";
    Console.Write("Parol: ");
    r.Parol = Console.ReadLine() ?? "";
    Console.Write("Ism: ");
    r.Ism = Console.ReadLine() ?? "";
    Console.Write("Familya: ");
    r.Familya = Console.ReadLine() ?? "";
    Console.Write("Yosh: ");
    r.Yosh = int.Parse(Console.ReadLine() ?? "0");
    readers.Add(r);
    currentReader = r;
    SaveData();
}

List<Book> LoadBooks()
{
    if (!File.Exists(booksFile)) return new List<Book>();
    return JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(booksFile)) ?? new List<Book>();
}

List<Reader> LoadReaders()
{
    if (!File.Exists(readersFile)) return new List<Reader>();
    return JsonSerializer.Deserialize<List<Reader>>(File.ReadAllText(readersFile)) ?? new List<Reader>();
}

void SaveData()
{
    File.WriteAllText(booksFile, JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true }));
    File.WriteAllText(readersFile, JsonSerializer.Serialize(readers, new JsonSerializerOptions { WriteIndented = true }));
}
