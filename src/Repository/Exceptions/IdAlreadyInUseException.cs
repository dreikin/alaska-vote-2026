namespace Repository.Exceptions;

public class IdAlreadyInUseException : Exception
{
    private const string NoMsg = "Supplied ID is already in use.";
    private const string InnerMsg = "Supplied ID is already in use: ";

    public IdAlreadyInUseException() : base(NoMsg)
    {
    }

    public IdAlreadyInUseException(string message) : base(InnerMsg + message)
    {
    }

    public IdAlreadyInUseException(string? message, Exception? innerException) : base(
        message is null ? NoMsg : InnerMsg + message, innerException)
    {
    }
}
