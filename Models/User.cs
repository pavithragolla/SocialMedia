using SocialMedia.DTOs;

namespace SocialMedia.Models;

public record class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset DOB { get; set; }
    public long Mobile { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }

    public UserDTO asDto => new UserDTO
    {
        Id = Id,
        Name = Name,
        DOB = DOB,
        Mobile = Mobile,
        Email =Email,
        Gender =Gender

    };
}