using Sakila.Model;

namespace Sakila.Abstractions;

public interface IFilmRepository
{
    Task<List<Film>> GetAllAsync();
    Task<List<Film>> GetByTextAsync(string? searchText);
}
