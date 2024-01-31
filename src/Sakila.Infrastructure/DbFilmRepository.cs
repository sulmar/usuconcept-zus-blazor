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

    public Task<List<Film>> GetByTextAsync(SearchCriteria searchCriteria)
    {
        IQueryable<Film> query = context.Films.AsNoTracking().AsQueryable();

        if (!string.IsNullOrEmpty(searchCriteria.SearchText))
        {
            query = query.Where(f => f.Title.Contains(searchCriteria.SearchText));
        }

        if (searchCriteria.StartIndex.HasValue)
        {
            query = query.Skip(searchCriteria.StartIndex.Value);
        }

        if (searchCriteria.Count.HasValue)
        {
            query = query.Take(searchCriteria.Count.Value);
        }

        return query.ToListAsync();
    }

    public Task<int> GetTotalItemCount()
    {
        return context.Films.AsNoTracking().CountAsync();
    }
}
