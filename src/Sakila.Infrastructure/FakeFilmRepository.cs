using Sakila.Abstractions;
using Sakila.Model;

namespace Sakila.Infrastructure;

public class FakeFilmRepository : IFilmRepository
{
    private readonly List<Film> films;

    public FakeFilmRepository()
    {
        films = new List<Film>
        {
            new() { Id =  1, Title = "Lorem", Description = "Ipsum", ReleaseYear = "2024", Rating = "PG" },
            new() { Id =  2, Title = "Lorem", Description = "Ipsum", ReleaseYear = "2024", Rating = "PG" },
            new() { Id =  3, Title = "Lorem", Description = "Ipsum", ReleaseYear = "2024", Rating = "PG" }
        };
    }

    public Task<List<Film>> GetAllAsync()
    {
        return Task.FromResult(films);
    }

    public Task<Film> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Film>> GetByTextAsync(string searchText)
    {
        var results = films.Where(f => f.Title.Contains(searchText)).ToList();

        return Task.FromResult(results);
    }

    public Task<List<Film>> GetByTextAsync(SearchCriteria searchCriteria)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetTotalItemCount()
    {
        throw new NotImplementedException();
    }
}