namespace Backend.Exceptions;

public class ExternalServiceException : CustomApplicationException
{
    private const string DefaultMessage = "External service is currently unavailable. Please try again later.";
    private static readonly string DefaultErrorCode = "external_service_error";

    public ExternalServiceException()
        : base(DefaultMessage, DefaultErrorCode)
    {
    }
}