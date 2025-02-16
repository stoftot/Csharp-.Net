namespace Api.Service.Exceptions;

public class MultipleEntriesWhitSameIdentifierException : Exception
{
    public string? Identifier { get; }
    
    public MultipleEntriesWhitSameIdentifierException() { }

    public MultipleEntriesWhitSameIdentifierException(string message)
        : base(message) { }

    public MultipleEntriesWhitSameIdentifierException(string message, Exception inner)
        : base(message, inner) { }

    public MultipleEntriesWhitSameIdentifierException(string message, string identifier)
        : this(message)
    {
        Identifier = identifier;
    }
    
    public MultipleEntriesWhitSameIdentifierException(string message, string identifier, Exception inner)
        : this(message, inner)
    {
        Identifier = identifier;
    }
}