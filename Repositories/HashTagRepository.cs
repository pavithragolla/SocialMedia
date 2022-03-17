using SocialMedia.Controllers;
using SocialMedia.Models;
using Dapper;
using School.Repositories;

namespace SocialMedia.Repositories;

public interface IHashTagRepository
{
    Task<HashTag> Create(HashTag Item);
   Task Update(HashTag Item);
//    Task Delete(int Id);
   Task<List<HashTag>> GetAll();
   Task<HashTag> GetById(int Id);
    
}

public class HashTagRepository : BaseRepository, IHashTagRepository
{
    public HashTagRepository(IConfiguration configuration): base(configuration)
    {
        
    }

    public async Task<HashTag> Create(HashTag Item)
    {

    var createQuery = $@"INSERT INTO public.hashtag(id, name) VALUES (@Id, @Name) RETURNING *";
    using(var connection = NewConnection)
        return await connection.QuerySingleAsync<HashTag>(createQuery,Item);
    
    }



    // public async Task Delete(int Id)
    // {
    //     var deleteQuery =$@"DELETE FROM public.hashtag WHERE id = @Id";

    //     using(var connection = NewConnection)
    //     await connection.ExecuteAsync(deleteQuery, new {Id});
    // }


    public async Task<List<HashTag>> GetAll()
    {
        var getallQuery = $@"SELECT * FROM hashtag WHERE id = @Id";

        using(var connection = NewConnection)
        return (await connection.QueryAsync<HashTag>(getallQuery)).AsList();
    }

    public async Task<HashTag> GetById(int Id)
    {
        var getQuery = $@"SELECT * FROM hashtag WHERE id = @Id";

        using(var connection = NewConnection)
        return await connection.QuerySingleOrDefaultAsync<HashTag>(getQuery, new{Id});
    }

    public async Task Update(HashTag Item)
    {
        var updateQuery = $@"UPDATE hashtag SET name= @Name  WHERE id=@Id";
        using(var connection = NewConnection)
        await connection.ExecuteAsync(updateQuery, Item);
    }
}