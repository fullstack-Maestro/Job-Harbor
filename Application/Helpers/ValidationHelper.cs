using System.Text.RegularExpressions;

namespace Domain.Helpers;

public class ValidationHelper
{
    public static bool IsNameValid(string name)
    {
        // Check if name is empty or null
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        // Check if name contains only letters, spaces, and apostrophes
        return !Regex.IsMatch(name, @"[^a-zA-Z ']");
    }

    public static bool IsEmailValid(string email)
    {
        // Check if email is empty or null
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        // Use a regular expression to validate email format
        return Regex.IsMatch(email, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
    }

    public static bool IsPasswordValid(string password)
    {
        // Check if password is empty or null
        if (string.IsNullOrEmpty(password))
        {
            return false;
        }

        // Define minimum password length (adjust as needed)
        const int minLength = 8;
        const int maxLength = 15;

        // Check if password meets minimum length
        if (password.Length < minLength && password.Length > maxLength)
        {
            return false;
        }

        // Check if password contains at least one lowercase letter, one uppercase letter, one digit, and one special character
        return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).*$");
    }
}