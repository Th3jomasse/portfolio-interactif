using System;

namespace PortfolioAPI.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // Frontend, Backend, DevOps
        public int Level { get; set; } // 1-5
        public string Description { get; set; } = string.Empty;
    }
}