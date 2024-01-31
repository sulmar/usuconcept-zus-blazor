using Sakila.Abstractions;
using Sakila.Model;
using Microsoft.EntityFrameworkCore;

namespace Sakila.Infrastructure;

public class DbFilmRepository : IFilmRepository
{
    private readonly SakilaContext context;

    public DbFilmRepository(SakilaContext context)
    {
        this.context = context;
    }

    public Task<List<Film>> GetAllAsync()
    {
        return context.Films.AsNoTracking().ToListAsync();
    }

    public Task<List<Film>> GetByTextAsync(string? searchText)
    {
        IQueryable<Film> query = context.Films.AsNoTracking().AsQueryable();

        if (!string.IsNullOrEmpty(searchText))
        {
            query = query.Where(f => f.Title.Contains(searchText));
        }

        return query.ToListAsync();  
    }
}
