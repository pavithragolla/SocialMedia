using System.Text.Json.Serialization;

namespace SocialMedia.DTOs;

public record PostDTO
{
    [JsonPropertyName("id")]

    public int Id { get; set; }
    [JsonPropertyName("type_of_post")]

    public string  TypeOfPost { get; set; }
    // [JsonPropertyName("createdt")]

    // public DateTimeOffset CreatedAt { get; set; }
    [JsonPropertyName("user_id")]

    public int UserId { get; set; }

    public List<LikeDTO> Like {get; set; }

}

public record PostCreateDTO
{
    // [JsonPropertyName("id")]

    // public int Id { get; set; }
    [JsonPropertyName("type_of_post")]
    public string  TypeOfPost { get; set; }

    // [JsonPropertyName("created")]
    // public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
}
public record PostUpdateDTO
{
    [JsonPropertyName("type_of_post")]
    // public int Id { get; set; }

    public string  TypeOfPost { get; set; }

}