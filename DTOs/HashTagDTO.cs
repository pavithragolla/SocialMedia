using System.Text.Json.Serialization;

namespace SocialMedia.DTOs;

public record HashTagDTO
{
    [JsonPropertyName("id")]

   public int Id { get; set; }

    [JsonPropertyName("name")]
    
    public string Name { get; set; }

    public List<PostDTO> Post {get; set; }
    public List<LikeDTO> Like {get; set; }
}

public record HashTagCreateDTO
{
    [JsonPropertyName("id")]
   public int Id { get; set; }

    [JsonPropertyName("name")]

    public string Name { get; set; }
}