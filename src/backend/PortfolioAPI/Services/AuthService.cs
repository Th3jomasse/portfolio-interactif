namespace DefaultNamespace;

public interface IAuthService
{
    string GenerateJwtToken(AdminUser user);
    bool ValidateCredentials(string username, string password);
}

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly AdminUser _adminUser; // En production, ceci viendrait d'une base de données

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
        // Pour la démo, nous créons un utilisateur admin en dur
        _adminUser = new AdminUser
        {
            Id = 1,
            Username = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123") // En production, utilisez une configuration sécurisée
        };
    }

    public string GenerateJwtToken(AdminUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT key not found"));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public bool ValidateCredentials(string username, string password)
    {
        return username == _adminUser.Username && 
               BCrypt.Net.BCrypt.Verify(password, _adminUser.PasswordHash);
    }
}