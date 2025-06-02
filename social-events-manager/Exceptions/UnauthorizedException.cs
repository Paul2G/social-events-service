namespace social_events_manager.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException() { }

    public UnauthorizedException(string message)
        : base(message) { }

    public UnauthorizedException(string message, Exception inner)
        : base(message, inner) { }
}
