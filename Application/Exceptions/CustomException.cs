namespace Domain.Exceptions;

public class CustomException : Exception
{
    public int StatusCode { get; }
    public new string Message { get; }
    public CustomException(string message)
    {
        this.StatusCode = 400;
        this.Message = message;
    }
}