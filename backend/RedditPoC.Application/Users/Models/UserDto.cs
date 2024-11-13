using RedditPoC.Domain.Users.Entities;

namespace RedditPoC.Application.Users.Models;

public record UserDto(Guid Id, string Username, string Email, DateTime CreatedOn)
{
    public static UserDto FromUser(User user)
    {
        return new UserDto(user.Id, user.Username, user.Email, DateTime.Now);
    }
}