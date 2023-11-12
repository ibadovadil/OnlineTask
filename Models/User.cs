using OnlineTask.Exceptions;

namespace OnlineTask.Models
{
    public class User
    {
        public static int IdCounter = 1;
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Any(char.IsDigit))
                {
                    throw new InvalidPasswordException("Name cannot be empty and must not contain digits.");
                }
                _name = value;
            }
        }


        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Any(char.IsDigit))
                {
                    throw new InvalidPasswordException("Surname cannot be empty and must not contain digits.");
                }
                _surname = value;
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (value.Length < 8 || !char.IsUpper(value[0]) || !value.Any(char.IsDigit))
                {
                    throw new InvalidPasswordException("Password must be at least 8 characters long, start with an uppercase letter, and contain at least 1 digit.");
                }
                _password = value;
            }
        }
        public User(string name, string surname, string password)
        {
            Id = IdCounter++;
            Name = name;
            Surname = surname;
            Password = password;
        }
        public string GetUsername()
        {
            return $"{Name}.{Surname}";
        }
    }
}
