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
        Password = @event.Password;
    }

    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    internal void Apply(UserCreated @event)
    {
        Id = @event.UserId;
        Username = @event.Username;
        Email = @event.Email;
        Password = @event.Password;
    }

    internal void Apply(UsernameUpdated @event)
    {
        Username = @event.Username;
    }

    internal void Apply(PasswordUpdated @event)
    {
        Password = @event.Password;
    }
}