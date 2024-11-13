using Marten.Events.Aggregation;
using RedditPoC.Domain.Users.Entities;
using RedditPoC.Domain.Users.Events;

namespace RedditPoC.Application.Users.Projections;

public class UserProjection : SingleStreamProjection<User>
{
    public User Create(UserCreated @event)
    {
        var user = new User();
        user.Apply(@event);
        return user;
    }

    public void Apply(UserCreated @event, User user)
    {
        user.Id = @event.UserId;
        user.Username = @event.Username;
        user.Email = @event.Email;
        user.Password = @event.Password;
    }

    public void Apply(UsernameUpdated @event, User user)
    {
        user.Username = @event.Username;
    }

    public void Apply(PasswordUpdated @event, User user)
    {
        user.Password = @event.NewPassword;
    }
}