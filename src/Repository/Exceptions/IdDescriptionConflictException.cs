namespace Repository.Exceptions;

public class IdDescriptionConflictException : Exception
{
    private const string noMsg = "ID+Description conflict occurred.";
    private const string innerMsg = "ID+Description conflict occurred: ";

    public IdDescriptionConflictException() : base(noMsg)
    {
    }

    public IdDescriptionConflictException(string message) : base(innerMsg + message)
    {
    }

    public IdDescriptionConflictException(string? message, Exception? innerException) : base(
        message is null ? noMsg : innerMsg + message, innerException)
    {
    }
}
