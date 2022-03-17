using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.Controllers;

[ApiController]
[Route("api/like")]

public class LikeController : ControllerBase
{

    private readonly ILogger<LikeController> _logger;

    private readonly ILikeRepository _Like;
    private readonly IPostRepository _Post;




    public LikeController(ILogger<LikeController> logger, ILikeRepository Like, IPostRepository Post)
    {
        _logger = logger;
        _Like = Like;
        _Post = Post;

    }


    [HttpPost]
    public async Task<ActionResult<LikeDTO>> CreateLike([FromBody] LikeCreateDTO Data)
    {
        var toLike = new Like
        {
            // Id = Data.Id,
            UserId = Data.UserId,
            PostId = Data.PostId

        };

         var createdItem = await _Like.Create(toLike);
        return StatusCode(StatusCodes.Status201Created, createdItem);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLike([FromRoute] int id)
    {
        var existing = await _Like.GetById(id);
        if (existing is null)
            return NotFound("No one liked found with given id");

        await _Like.Delete(id);

        return NoContent();
    }
    [HttpGet]

    public async Task<ActionResult<List<LikeDTO>>> GetAllLike()
    {
        var LikeList = await _Post.GetList();
        var dtoList = LikeList.Select(x => x.asDto);
        return Ok(dtoList);

    }
     

    [HttpGet("{id}")]
    public async Task<ActionResult<LikeDTO>> GetUserById([FromRoute] int id)
    {
        var post = await _Post.GetById(id);
        if (post is null)
            return NotFound("No like is found with given id");
        var dto = post.asDto;

        //  dto.Like = (await _Like.GetAllForPost(id)).Select(x => x.asDto).ToList();
        //dto.Like = (await _Like.GetAllForPost(post.Id)).asDto;
        
        

        return Ok(dto);
    }
}