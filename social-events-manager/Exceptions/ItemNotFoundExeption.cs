namespace social_events_manager.Exceptions;

public class ItemNotFoundException : KeyNotFoundException
{
    public ItemNotFoundException() { }

    public ItemNotFoundException(string message)
        : base(message) { }

    public ItemNotFoundException(string message, Exception inner)
        : base(message, inner) { }
}
