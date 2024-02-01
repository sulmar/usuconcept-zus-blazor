using Sakila.Model;

namespace Sakila.Abstractions;

public interface IFilmRepository
{
    Task<List<Film>> GetAllAsync();
    Task<List<Film>> GetByTextAsync(SearchCriteria searchCriteria);
    Task<int> GetTotalItemCount();
    Task<Film> GetByIdAsync(int id);
}


public class SearchCriteria
{
    public string? SearchText { get; set; }
    public int? StartIndex { get; set; }
    public int? Count { get; set; }
}
