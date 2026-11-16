namespace Repository.Exceptions;

public class InvalidIdException : Exception
{
    private const string NoMsg = "Supplied ID is not valid.";
    private const string InnerMsg = "Supplied ID is not valid: ";

    public InvalidIdException() : base(NoMsg)
    {
    }

    public InvalidIdException(string message) : base(InnerMsg + message)
    {
    }

    public InvalidIdException(string? message, Exception? innerException) : base(
        message is null ? NoMsg : InnerMsg + message, innerException)
    {
    }
}
