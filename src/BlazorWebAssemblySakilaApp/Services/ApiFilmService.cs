using Sakila.Model;
using System.Net.Http.Json;
using System.Linq;

namespace BlazorWebAssemblySakilaApp.Services;

public class FilmsResponse
{
    public List<Film> Films { get; set; }
    public int TotalItemCount { get; set; }

    public FilmsResponse(List<Film> films, int totalItemCount)
    {
        Films = films;
        TotalItemCount = totalItemCount;
    }
}

public class ApiFilmService(HttpClient http)
{
    public async Task<Film> GetById(int id)
    {
        return await http.GetFromJsonAsync<Film>($"films/{id}");
    }

    public async Task<List<Film>> GetAllAsync()
    {
        return await http.GetFromJsonAsync<List<Film>>("films");
    }

    public async Task<List<Film>> GetByFilter(string filter)
    {
        return await http.GetFromJsonAsync<List<Film>>($"films?filter={filter}");
    }

    public async Task<FilmsResponse> GetAllAsync(int startIndex, int count)
    {
        // var films = await http.GetFromJsonAsync<List<Film>>($"films?startIndex={startIndex}&count={count}");

        List<Film> films = null;
        int totalItemCount = 0;

        var response = await http.GetAsync($"films?startIndex={startIndex}&count={count}");

        if (response.IsSuccessStatusCode)
        {
            films = await response.Content.ReadFromJsonAsync<List<Film>>();

            response.Headers.TryGetValues("x-total-item-count", out IEnumerable<string> totalItemCounts);

            totalItemCount = int.Parse(totalItemCounts.Single());
        }

        return new FilmsResponse(films, totalItemCount);
    }
}
