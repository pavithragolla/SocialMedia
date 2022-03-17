using System.Text.Json.Serialization;

namespace SocialMedia.DTOs;

public record LikeDTO
{
    [JsonPropertyName("id")]

   public int Id { get; set; }


    // [JsonPropertyName("createdat")]
    // public DateTimeOffset CreatedAt  { get; set; }
    [JsonPropertyName("post_id")]

    public int PostId { get; set; }
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
}

public record LikeCreateDTO
{
//     [JsonPropertyName("id")]

//    public int Id { get; set; }

    // [JsonPropertyName("createdat")]

    // public DateTimeOffset CreatedAt  { get; set; }

    [JsonPropertyName("post_id")]
    public int PostId { get; set; }
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
}

