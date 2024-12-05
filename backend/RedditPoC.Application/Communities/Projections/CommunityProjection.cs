using Marten.Events.Projections;
using RedditPoC.Application.Users.Projections;
using RedditPoC.Domain.Communities.Enums;
using RedditPoC.Domain.Communities.Events;

namespace RedditPoC.Application.Communities.Projections;

public sealed record Community(
    Guid Id,
    string Name,
    string Description,
    CommunityVisiblity Visiblity,
    bool IsMature,
    DateTime Created,
    string Creator);

public class CommunityProjection : EventProjection
{
    public CommunityProjection()
    {
        ProjectAsync<CommunityCreated>(async (created, operations) =>
        {
            var admin = await operations.LoadAsync<User>(created.AdminId);
            operations.Store(new Community(created.CommunityId, created.Name, created.Description, created.Visibility,
                created.IsMature, created.Timestamp, admin!.Username));
        });
    }
}