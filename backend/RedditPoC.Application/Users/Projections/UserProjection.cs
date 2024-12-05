using Marten.Events.Aggregation;
using RedditPoC.Domain.Users.Events;

namespace RedditPoC.Application.Users.Projections;

public sealed record User(Guid Id, string Email, string Username, string DisplayName);

public class UserProjection : SingleStreamProjection<User>
{
    public static User Create(UserCreated @event)
    {
        return new User(@event.UserId, @event.Email, @event.Username, @event.DisplayName);
    }

    public static User Apply(DisplayNameUpdated @event, User user)
    {
        return user with { Username = @event.DisplayName };
    }
}