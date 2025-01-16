using System;

namespace PortfolioAPI.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Technologies { get; set; } = new List<string>();
        public string GitHubUrl { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}