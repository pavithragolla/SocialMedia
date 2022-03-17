using System.Text.Json.Serialization;

namespace SocialMedia.DTOs;

public record class UserDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]

    public string Name { get; set; }

    [JsonPropertyName("date")]
    public DateTimeOffset DOB { get; set; }

    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }
    public List<PostDTO> Post {get; set; }
    // public List<LikeDTO> Like {get; set; }
}

public record class UserCreateDTO
{
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("date")]
    public DateTimeOffset DOB { get; set; }

    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }
}

public record class UserUpdateDTO
{


    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

 
}