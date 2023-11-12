using OnlineTask.Exceptions;
using OnlineTask.Models;
using OnlineTask.Services;

namespace OnlineTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("<======== Menu ========>");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("0. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Surname: ");
                        string surname = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();
                        UserService.Register(name, surname, password);
                        break;
                    case "2":
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string loginPassword = Console.ReadLine();
                        bool loginResult = UserService.Login(username, loginPassword);
                        if (loginResult)
                        {
                            Console.WriteLine("Login successful!");
                            ShowBlogMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password. Please try again.");
                        }
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static void ShowBlogMenu()
        {
            while (true)
            {
                Console.WriteLine("<======== Blog Menu ========>");
                Console.WriteLine("1. Add Blog");
                Console.WriteLine("2. Remove Blog");
                Console.WriteLine("3. Blog Details");
                Console.WriteLine("4. Show All Blogs");
                Console.WriteLine("5. Filter Blogs");
                Console.WriteLine("0. Back to Main Menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Description: ");
                        string description = Console.ReadLine();
                        Console.WriteLine("Select Blog Type: ");
                        Console.WriteLine("1. Programming");
                        Console.WriteLine("2. Educational");
                        Console.WriteLine("3. Thriller");
                        int blogTypeChoice = Convert.ToInt32(Console.ReadLine());
                        Blog.BlogType selectedType = (Blog.BlogType)(blogTypeChoice);
                        Blog newBlog = new Blog { Title = title, Description = description, Type = selectedType };
                        BlogService.AddBlog(newBlog);
                        break;
                    case "2":
                        Console.Write("Enter Blog ID to remove: ");
                        int blogIdToRemove = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            BlogService.RemoveBlog(blogIdToRemove);
                            Console.WriteLine("Blog removed successfully.");
                        }
                        catch (BlogNotFoundException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        Console.WriteLine("Blog removed successfully.");
                        break;
                    case "3":
                        Console.Write("Enter Blog ID to view details: ");
                        int viewblog = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            Blog blog = BlogService.GetBlogById(viewblog);
                            Console.WriteLine($"Title: {blog.Title}");
                            Console.WriteLine($"Description: {blog.Description}");
                            Console.WriteLine($"Type: {blog.Type}");
                        }
                        catch (BlogNotFoundException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "4":
                        Console.Write("See all blogs: ");
                        var blogs = BlogService.GetAllBlogs();
                        foreach (var blog in blogs)
                        {
                            Console.WriteLine($"ID: {blog.Id}, Title: {blog.Title}, Description: {blog.Description}, Type: {blog.Type}");
                        }
                        break;
                    case "5":
                        Console.WriteLine("");
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}