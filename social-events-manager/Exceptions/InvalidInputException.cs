using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Exceptions;

public class InvalidInputException : Exception
{
    public InvalidInputException() { }

    public InvalidInputException(string message)
        : base(message) { }

    public InvalidInputException(string message, Exception inner)
        : base(message, inner) { }
}
