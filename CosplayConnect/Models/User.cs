public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public required string Role { get; set; } // photographer or cosplayer
    public string? Bio { get; set; }
    public List<string> Tags { get; set; } = new();
    public List<string> Events { get; set; } = new();
    public List<string> Photos { get; set; } = new();
    public Dictionary<string, object> SocialLinks { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string PasswordHash { get; set; } = null!;
}