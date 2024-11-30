using RedditPoC.Domain.Users.Events;

namespace RedditPoC.Domain.Users.Entities;

public sealed class User
{
    public User()
    {
    }

    internal User(UserCreated @event)
    {
        Id = @event.UserId;
        Username = @event.Username;
        Email = @event.Email;
    }

    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    internal void Apply(UserCreated @event)
    {
        Id = @event.UserId;
        Username = @event.Username;
        Email = @event.Email;
    }

    internal void Apply(UsernameUpdated @event)
    {
        Username = @event.Username;
    }
}