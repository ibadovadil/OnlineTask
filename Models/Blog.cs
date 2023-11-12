using System.Xml.Linq;

namespace OnlineTask.Models
{
    public class Blog
    {
        public static int IdCounter = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BlogType Type { get; set; }
        public enum BlogType
        {
            Programming,
            Educational,
            Thriller
        }
        public Blog()
        {
            Id = IdCounter++;
        }
    }
}
