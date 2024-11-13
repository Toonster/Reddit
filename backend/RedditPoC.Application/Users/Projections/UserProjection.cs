using Marten.Events.Aggregation;
using RedditPoC.Domain.Users.Entities;
using RedditPoC.Domain.Users.Events;

namespace RedditPoC.Application.Users.Projections;

public class UserProjection : SingleStreamProjection<User>
{
    public User Create(UserCreated @event)
    {
        var user = new User
        {
            Id = @event.UserId,
            Email = @event.Email,
            Username = @event.Username,
            Password = @event.Password
        };

        return user;
    }

    public void Apply(UsernameUpdated @event, User user)
    {
        user.Username = @event.Username;
    }

    public void Apply(PasswordUpdated @event, User user)
    {
        user.Password = @event.Password;
    }
}