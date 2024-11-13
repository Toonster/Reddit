using RedditPoC.Domain.Events;
using RedditPoC.Domain.Users.Events;

namespace RedditPoC.Domain.Users.Entities;

public sealed class User
{
    private User()
    {
    }

    private void Apply(UserCreated @event)
    {
        Id = @event.UserId;
        Username = @event.Username;
        Email = @event.Email;
        Password = @event.Password;
    }
    
    private void Apply(UsernameUpdated @event)
    {
        Username = @event.Username;
    }
    
    private void Apply(PasswordUpdated @event)
    {
        Password = @event.NewPassword;
    }

    public void Apply(Event @event)
    {
        switch (@event)
        {
            case UserCreated userCreated:
                Apply(userCreated);
                break;
            case UsernameUpdated usernameUpdated:
                Apply(usernameUpdated);
                break;
            case PasswordUpdated passwordUpdated:
                Apply(passwordUpdated);
                break;
        }
    }

    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
}