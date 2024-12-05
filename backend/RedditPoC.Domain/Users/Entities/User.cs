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
        DisplayName = @event.DisplayName;
    }

    public Guid Id { get; set; }
    public string Username { get; set; }
    public string DisplayName { get; set; }
    public string Email { get; set; }

    internal void Apply(DisplayNameUpdated @event)
    {
        DisplayName = @event.DisplayName;
    }
}