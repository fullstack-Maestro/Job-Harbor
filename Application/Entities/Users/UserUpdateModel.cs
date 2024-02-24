using Domain.Enums;

namespace Domain.Entities.Users;

public class UserUpdateModel
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Role Role { get; set; }
    public string Hash { get; set; } = null!;
    public byte[] Salt { get; set; } = null!;
}