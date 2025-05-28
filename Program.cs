using Brokers;
using Services;
using Data;

class Program
{
    static void Main()
    {
        var dataStore = new DataStore();
        var userService = new UserService(dataStore);
        var libraryService = new LibraryService(dataStore);
        var console = new ConsoleBroker(userService, libraryService);
        console.Run();
    }
}