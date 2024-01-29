using BlazorSSRSakilaApp.Abstractions;
using BlazorSSRSakilaApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorSSRSakilaApp.Infrastructure;

public class DbFilmRepository : IFilmRepository
{
    private readonly SakilaContext context;

    public DbFilmRepository(SakilaContext context)
    {
        this.context = context;
    }

    public Task<List<Film>> GetAllAsync()
    {
        return context.Films.ToListAsync();
    }
}


public class FakeFilmRepository : IFilmRepository
{
    public Task<List<Film>> GetAllAsync()
    {
        var films = new List<Film>
        {
            new() { Id =  1, Title = "Lorem", Description = "Ipsum", ReleaseYear = "2024", Rating = "PG" },
            new() { Id =  2, Title = "Lorem", Description = "Ipsum", ReleaseYear = "2024", Rating = "PG" },
            new() { Id =  3, Title = "Lorem", Description = "Ipsum", ReleaseYear = "2024", Rating = "PG" }
        };

        return Task.FromResult(films);
    }
}