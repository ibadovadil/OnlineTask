using OnlineTask.Exceptions;
using OnlineTask.Models;

namespace OnlineTask.Services
{
    public class BlogService
    {
        public static void AddBlog(Blog blog)
        {
            BlogDatabase.Blogs.Add(blog);
        }
        public static Blog GetBlogById(int id)
        {
            var blog = BlogDatabase.Blogs.SingleOrDefault(e => e.Id == id);
            if (blog == null)
                throw new BlogNotFoundException($"Blog with ID {id} not found.");
            return blog;
        }
        public static void RemoveBlog(int id)
        {
            var blog = GetBlogById(id);
            BlogDatabase.Blogs.Remove(blog);
        }

        public static List<Blog> GetAllBlogs()
        {
            return BlogDatabase.Blogs;
        }
        public static List<Blog> GetBlogsByValue(string value)
        {
            return BlogDatabase.Blogs.FindAll(x => x.Title == value || x.Description == value);
        }

    }
}
