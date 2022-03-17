using SocialMedia.DTOs;

namespace SocialMedia.Models;

public record HashTag
{
   public int Id { get; set; }
    public string Name { get; set; }

 public HashTagDTO asDto => new HashTagDTO
 {
    Id = Id,
    Name = Name 
 };
}