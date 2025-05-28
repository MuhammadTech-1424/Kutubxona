using Models;
using Data;

namespace Services
{
    public class UserService
    {
        private readonly DataStore _dataStore;

        public UserService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public User Register(string login, string password, string firstName, string lastName, int age)
        {
            var users = _dataStore.LoadUsers();
            if (users.Any(u => u.Login == login)) return null;

            var user = new User { Id = users.Count + 1, Login = login, Password = password, FirstName = firstName, LastName = lastName, Age = age };
            users.Add(user);
            _dataStore.SaveUsers(users);
            return user;
        }

        public User Login(string login, string password)
        {
            var users = _dataStore.LoadUsers();
            return users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}