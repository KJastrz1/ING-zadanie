namespace Backend.Exceptions;

public class CustomApplicationException : Exception
{
    public string ErrorCode { get; }

    public CustomApplicationException(string message, string errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}