using System.Security.Cryptography;

namespace Domain.Helpers;

public class PaswordHasher
{
    [Obsolete("Obsolete")]
    public static (string Hash, byte[] Salt) GenerateHash(string password)
    {
        byte[] salt = CreateSalt(16); // 16 bytes = 128 bits

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32); // 32 bytes = 256 bits

        return (Convert.ToBase64String(hash), salt);
    }

    public static bool VerifyPassword(string password, string storedHash, byte[] storedSalt)
    {
        byte[] hashBytes = Convert.FromBase64String(storedHash);
        byte[] salt = storedSalt;

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
        byte[] newHash = pbkdf2.GetBytes(32);

        return hashBytes.Equals(newHash);
    }

    [Obsolete("Obsolete")]
    private static byte[] CreateSalt(int size)
    {
        using var rng = new RNGCryptoServiceProvider();
        byte[] salt = new byte[size];
        rng.GetBytes(salt);
        return salt;
    }
}