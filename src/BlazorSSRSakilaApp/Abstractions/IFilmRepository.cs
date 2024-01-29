using BlazorSSRSakilaApp.Model;

namespace BlazorSSRSakilaApp.Abstractions;

public interface IFilmRepository
{
    Task<List<Film>> GetAllAsync();
}
