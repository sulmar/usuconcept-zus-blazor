using Sakila.Model;
using System.Net.Http.Json;

namespace BlazorWebAssemblySakilaApp.Services;

public class ApiFilmService(HttpClient http)
{
    public async Task<List<Film>> GetAllAsync()
    {
        return await http.GetFromJsonAsync<List<Film>>("films");
    }

    public async Task<List<Film>> GetByFilter(string filter)
    {
        return await http.GetFromJsonAsync<List<Film>>($"films?filter={filter}");
    }
}
