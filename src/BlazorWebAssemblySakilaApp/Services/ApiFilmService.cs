using Sakila.Model;
using System.Net.Http.Json;

namespace BlazorWebAssemblySakilaApp.Services;

public class ApiFilmService : IFilmService
{
    private readonly HttpClient Http;

    public ApiFilmService(HttpClient http)
    {
        Http = http;
    }

    public async Task<List<Film>> GetAllAsync()
    {
        return await Http.GetFromJsonAsync<List<Film>>("films");
    }
}