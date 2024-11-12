namespace RedditPoC.Domain.Events;

public abstract record Event
{
    public abstract Guid StreamId { get; }
    public DateTime Timestamp { get; } = DateTime.Now;
}