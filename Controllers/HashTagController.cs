using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.Controllers;

[ApiController]
[Route("api/HashTag")]


public class HashTagController : ControllerBase
{
    private readonly ILogger<HashTagController> _logger;
    private readonly IHashTagRepository _HashTag;

    private readonly IPostRepository _Post;


    public HashTagController(ILogger<HashTagController> logger, IHashTagRepository HashTag, IPostRepository Post)
    {
        _logger = logger;
        _HashTag = HashTag;
        _Post = Post;
    }

    [HttpPost]
    public async Task<ActionResult<List<HashTag>>> CreateHashTag([FromBody] HashTagCreateDTO Data)
    {
        // var user = await _HashTag.GetById(Data.Id);
        // if (user is null)
        //     return NotFound("No HashTags found with given user id");

        var toCreateHashTag = new HashTag
        {
            // Id = Data.Id,
            Name = Data.Name.Trim(),
        };

        var createdItem = await _HashTag.Create(toCreateHashTag);
        return StatusCode(StatusCodes.Status201Created);
    }


    // [HttpDelete("{id}")]
    // public async Task<ActionResult> DeleteHashTag([FromRoute] int id)
    // {
    //     var existing = await _HashTag.GetById(id);
    //     if (existing is null)
    //         return NotFound("No HashTags found with given id");

    //     await _HashTag.Delete(id);

    //     return NoContent();
    // }

    // [HttpPut("{id}")]
    // public async Task<ActionResult> UpdateHashTag([FromRoute] int id, [FromBody] HashTagUpdateDTO Data)
    // {
    //     var existing = await _HashTag.GetById(id);
    //     if (existing is null)
    //         return NotFound("No HashTag found to update with given id");

    //     var toUpdateItem = existing with
    //     {
    //         Name = Data.Name.Trim()
    //     };
    //     await _HashTag.Update(toUpdateItem);


    //     return NoContent();

    // }


    [HttpGet("{id}")]
    public async Task<ActionResult<HashTag>> GetHashTagByID([FromRoute] int id)
    {
        var HashTag = await _HashTag.GetById(id);
        if (HashTag is null)
            return NotFound("No HashTag found with given id");

        var dto = HashTag.asDto;
        dto.Post = (await _Post.GetAllForHashTag(HashTag.Id)).Select(x => x.asDto).ToList();

        return Ok(dto);

    }
     [HttpGet]
    public async Task<ActionResult<List<HashTagDTO>>> GetAllUsers()
    {
        var usersList = await _HashTag.GetAll();
        var dtoList = usersList.Select(x => x.asDto);
        return Ok(dtoList);
    }


}