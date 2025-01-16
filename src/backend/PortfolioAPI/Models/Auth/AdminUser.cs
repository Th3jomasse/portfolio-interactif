﻿using system;

namespace PortfolioAPI.Models.Auth
{
    public class AdminUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}