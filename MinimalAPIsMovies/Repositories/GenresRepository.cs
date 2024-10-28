using Dapper;
using Microsoft.Data.SqlClient;
using MinimalAPIsMovies.Entities;

namespace MinimalAPIsMovies.Repositories;

public class GenresRepository : IGenresRepository
{
    private readonly SqlConnection _connection;

    public GenresRepository(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
       _connection= new SqlConnection(connectionString);
    }

    public async Task<List<Genre>> GetGenresAsync()
    {
       const string query = """

                    SELECT * FROM GENRES;
                    """;
       var result = await _connection.QueryAsync<Genre>(query);
       return  result.ToList();
    }

    public async  Task<int> CreateAsync(Genre genre)
    {
     
        const string query = """

                             INSERT INTO GENRES (Name) VALUES (@Name);
                             SELECT SCOPE_IDENTITY();
                             """;

        var id = await _connection.QuerySingleAsync<int>(query,genre);
        genre.Id = id;
        return id;
    }

    public Task<int> UpdateAsync(Genre genre)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Genre?> GetAsync(int id)
    {
        const string query = """
                    
                        SELECT * FROM GENRES WHERE Id=(@Id);
                    """;
        var result = await _connection.QueryFirstOrDefaultAsync<Genre>(query,new{ Id=id });
        return result;
    }
}