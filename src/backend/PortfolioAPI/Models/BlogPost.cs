using system;

namespace PortfolioAPI.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();
        public DateTime PublishedDate { get; set; }
        public List<Comment> Comments { get; set; } = new();
    }
}