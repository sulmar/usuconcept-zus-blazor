using Sakila.Model;

namespace Sakila.Abstractions;

public interface IFilmRepository
{
    Task<List<Film>> GetAllAsync();
    Task<List<Film>> GetByTextAsync(SearchCriteria searchCriteria);
    Task<int> GetTotalItemCount();
}


public class SearchCriteria
{
    public string? SearchText { get; set; }
    public int? StartIndex { get; set; }
    public int? Count { get; set; }
}
