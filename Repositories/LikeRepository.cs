using SocialMedia.DTOs;
using SocialMedia.Models;
using Dapper;
using School.Repositories;

namespace SocialMedia.Repositories;

public interface ILikeRepository
{

    Task<Like> GetById(int Id);
    Task<Like> Create(Like Item);
    Task Update(Like Item);
    Task Delete(int Id);
    Task<List<Like>> GetAllForPost(int Id);
}

public class LikeRepository : BaseRepository, ILikeRepository
{
    public LikeRepository(IConfiguration configuration) : base(configuration)
    {

    }

    public async Task<Like> Create(Like Item)
    {
        var createQuery = $@"INSERT INTO ""like""(user_id, post_id, createdat) VALUES ( @UserId, @PostId, @CreatedAt) RETURNING *;";
        using (var connection = NewConnection)
            return await connection.QuerySingleAsync<Like>(createQuery, Item);
    }

    public async Task Delete(int Id)
    {
        var deleteQuery = $@"DELETE FROM ""like"" WHERE id = @Id;";

        using (var connection = NewConnection)
            await connection.ExecuteAsync(deleteQuery, new { Id });
    }

    public async Task<List<Like>> GetAllForPost(int Id)
    {
        var getallQuery = $@"SELECT * FROM ""like"" WHERE id = @post_id";

        using (var connection = NewConnection)
            return (await connection.QueryAsync<Like>(getallQuery, new {post_id=Id})).AsList();
            // return (await connection.QueryAsync<Like>(getallQuery)).AsList();
    }



    public async Task<Like> GetById(int Id)
    {
        var getQuery = $@"SELECT * FROM ""like"" WHERE id = @Id";

        using (var connection = NewConnection)
            return await connection.QuerySingleOrDefaultAsync<Like>(getQuery, new { Id });
    }

    public async Task Update(Like Item)
    {
        var updateQuery = $@"UPDATE ""like"" SET user_id=@UserId, post_id=@PostId, createdat = @CreatedAt WHERE id=@Id";
        using (var connection = NewConnection)
            await connection.ExecuteAsync(updateQuery, Item);
    }


}