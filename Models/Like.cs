using SocialMedia.DTOs;

namespace SocialMedia.Models;

public record Like
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public int PostId { get; set; }
    public int UserId { get; set; }

    public LikeDTO asDto => new LikeDTO
    {
        Id = Id,
        // CreatedAt = CreatedAt,
        PostId = PostId,
        UserId = UserId
    };
}