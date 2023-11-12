using OnlineTask.Exceptions;
using OnlineTask.Models;

namespace OnlineTask.Services
{
    public class UserService
    {
        public static bool Login(string username, string password)
        {
            User result = UserDatabase.Users.Find(x => x.GetUsername() == username && x.Password == password);
            if (result == null)
            {
                return false;
            }
            return true;
        }
        public static void Register(string name, string surname, string password)
        {
            try
            {
                User user = new User(name, surname, password);
                UserDatabase.Users.Add(user);
                Console.WriteLine("User registered successfully!");
            }
            catch (InvalidNameException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidSurnameException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidPasswordException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
