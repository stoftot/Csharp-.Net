namespace Api.Service.Exceptions;

public class IdentifierDidntMatchAnyEntriesException : Exception
{
    public string? Identifier { get; }
    
    public IdentifierDidntMatchAnyEntriesException() { }

    public IdentifierDidntMatchAnyEntriesException(string message)
        : base(message) { }

    public IdentifierDidntMatchAnyEntriesException(string message, Exception inner)
        : base(message, inner) { }
    
    public IdentifierDidntMatchAnyEntriesException(string message, string identifier)
        : this(message)
    {
        Identifier = identifier;
    }
}