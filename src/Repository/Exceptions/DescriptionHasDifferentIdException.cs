namespace Repository.Exceptions;

public class DescriptionHasDifferentIdException : Exception
{
    private const string NoMsg = "Description is already present with a different ID.";
    private const string InnerMsg = "Description is already present with a different ID: ";

    public DescriptionHasDifferentIdException() : base(NoMsg)
    {
    }

    public DescriptionHasDifferentIdException(string message) : base(InnerMsg + message)
    {
    }

    public DescriptionHasDifferentIdException(string? message, Exception? innerException) : base(
        message is null ? NoMsg : InnerMsg + message, innerException)
    {
    }
}
