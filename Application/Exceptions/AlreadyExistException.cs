namespace Domain.Exceptions;

#pragma warning disable
public class AlreadyExistException<T> : Exception
{
    public int StatusCode { get; }
    public string Message { get; }
    public AlreadyExistException()
    {
        this.StatusCode = 400;
        this.Message = $"{typeof(T)} already exists";
    }
}
