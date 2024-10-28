using MinimalAPIsMovies.Entities;

namespace MinimalAPIsMovies.Repositories;

public interface IGenresRepository
{
    Task<List<Genre>> GetGenresAsync();
    Task<int> CreateAsync(Genre genre);
    Task<int> UpdateAsync(Genre genre);
    Task<int> DeleteAsync(int id);
    Task<Genre?> GetAsync(int id);


}