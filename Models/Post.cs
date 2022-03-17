using SocialMedia.DTOs;

namespace SocialMedia.Models;

public record Post
{
    public int Id { get; set; }
    public string TypeOfPost { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public int UserId { get; set; }

    public PostDTO asDto => new PostDTO
    {
        Id = Id,
        TypeOfPost = TypeOfPost,
        CreatedAt = CreatedAt,
        UserId = UserId
    };
}