using Sakila.Model;

namespace Sakila.Abstractions;

public interface IFilmRepository
{
    Task<List<Film>> GetAllAsync();
}
