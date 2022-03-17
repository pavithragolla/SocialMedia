using SocialMedia.DTOs;
using SocialMedia.Models;
using Dapper;
using School.Repositories;

namespace SocialMedia.Repositories;

public interface IPostRepository
{
    Task<Post> GetById(int Id);
    Task<Post> Create(Post Item);
    Task Update(Post Item);
    Task Delete(int Id);
    Task<List<Post>> GetAllForUser(int Id);
    Task<List<Post>> GetList();
    Task<List<Post>> GetAllForHashTag(int id);
}

public class PostRepository : BaseRepository, IPostRepository
{
    public PostRepository(IConfiguration configuration) : base(configuration)
    {

    }

    public async Task<Post> Create(Post Item)
    {

        var createQuery = $@"INSERT INTO public.Post( type_of_post, user_id) VALUES (@TypeOfPost, @UserId) RETURNING *;";
        using (var connection = NewConnection)
            return await connection.QuerySingleAsync<Post>(createQuery, Item);

    }

    public async Task Delete(int Id)
    {
        var deleteQuery = $@"DELETE FROM Post WHERE id =@Id";

        using (var connection = NewConnection)
            await connection.ExecuteAsync(deleteQuery, new { Id });
    }



    public async Task<List<Post>> GetAllForUser(int Id)
    {
        var getallQuery = $@"SELECT * FROM Post WHERE user_id = @Id";

        using (var connection = NewConnection)
            return (await connection.QueryAsync<Post>(getallQuery, new { Id })).AsList();
    }

    public async Task<Post> GetById(int Id)
    {
        var getQuery = $@"SELECT * FROM Post WHERE id = @Id";

        using (var connection = NewConnection)
            return await connection.QuerySingleOrDefaultAsync<Post>(getQuery, new { Id });
    }

    public async Task<List<Post>> GetList()
    {
        var getQuery = $@"SELECT * FROM Post";
        var connection = NewConnection;
        var res = (await connection.QueryAsync<Post>(getQuery)).AsList();
        await connection.CloseAsync();
        return res;
    }

    public async Task Update(Post Item)
    {
        var updateQuery = $@"UPDATE Post SET type_of_post = @TypeOfPost WHERE id=@Id";
        using (var connection = NewConnection)
            await connection.ExecuteAsync(updateQuery, Item);
    }


    public async Task<List<Post>> GetAllForHashTag(int HashTagId)
    {
        var query = $@"SELECT * FROM post_hashtag ph 
        LEFT JOIN Post p ON p.id = ph.post_id WHERE HashTag_id =@HashTagId";

        using (var connection = NewConnection)
            return (await connection.QueryAsync<Post>(query, new { HashTagId })).AsList();
            // return (await connection.QueryAsync<Post>(query)).AsList();

    }




}