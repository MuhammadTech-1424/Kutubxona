
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Kutubxona.Models;

namespace Kutubxona.Brokers
{
    class DataProcessor
    {
        public static List<Reader> RetreavingDataFromReaders()
        {
            string json = File.ReadAllText(@"Data\DataReaders.json");
            return JsonSerializer.Deserialize<List<Reader>>(json);
        }

        public static void SavingDataToReaders(Reader user)
        {
            List<Reader> users = RetreavingDataFromReaders();
            users.Add(user);
            string json = JsonSerializer.Serialize(users);
            File.WriteAllText(@"Data\DataReaders.json", json);
        }

        public static List<Book> RetreavingDataFromBooks()
        {
            string json = File.ReadAllText(@"Data\DataBooks.json");
            return JsonSerializer.Deserialize<List<Book>>(json);
        }
    }
}