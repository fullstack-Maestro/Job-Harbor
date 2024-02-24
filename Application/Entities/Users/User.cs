namespace Domain.Entities.Users;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Hash { get; set; } = null!;
    public byte[] Salt { get; set; } = null!;
}