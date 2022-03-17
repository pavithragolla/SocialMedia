using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.Controllers;

[ApiController]
[Route("api/post")]

public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly IPostRepository _Post;
    private readonly IUserRepository _user;
    private readonly ILikeRepository _Like;


    public PostController(ILogger<PostController> logger, IPostRepository Post, IUserRepository user, ILikeRepository Like)
    {
        _logger = logger;
        _Post = Post;
        _user = user;
        _Like = Like;
    }

    [HttpPost]
    public async Task<ActionResult<List<Post>>> CreatePost([FromBody] PostCreateDTO Data)
    {
        var user = await _user.GetById(Data.UserId);
        if (user is null)
            return NotFound("No post found with given user id");

        var toCreatePost = new Post
        {
            // Id = Data.Id,
            TypeOfPost = Data.TypeOfPost.Trim(),
            UserId = Data.UserId
        };

        var createdItem = await _Post.Create(toCreatePost);
        return StatusCode(StatusCodes.Status201Created, createdItem);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost([FromRoute] int id)
    {
        var existing = await _Post.GetById(id);
        if (existing is null)
            return NotFound("No post found with given id");

        await _user.Delete(id);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePost([FromRoute] int id, [FromBody] PostUpdateDTO Data)
    {
        var existing = await _Post.GetById(id);
        if (existing is null)
            return NotFound("No Post found to update with given id");

        var toUpdateItem = existing with
        {
            TypeOfPost = Data.TypeOfPost.Trim(),
        };
        await _Post.Update(toUpdateItem);


        return NoContent();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDTO>> GetUserById([FromRoute] int id)
    {
        var post = await _Post.GetById(id);
        if (post is null)
            return NotFound("No post is found with given id");
        var dto = post.asDto;

        dto.Like = (await _Like.GetAllForPost(id)).Select(x => x.asDto).ToList();
        //dto.Like = (await _Like.GetAllForPost(post.Id)).asDto;



        return Ok(dto);
    }


    [HttpGet]

    public async Task<ActionResult<List<PostDTO>>> GetAllLike()
    {
        var LikeList = await _Post.GetList();
        var dtoList = LikeList.Select(x => x.asDto);
        return Ok(dtoList);

    }
}
