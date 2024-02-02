using Sakila.Model;
using System.Net.Http.Json;

namespace BlazorWebAssemblySakilaApp.Services;

public class ApiRentalService(HttpClient http)
{
    public async Task<List<Rental>> GetAllAsync()
    {
        return await http.GetFromJsonAsync<List<Rental>>("rentals");
    }

    public async Task<Rental> GetById(int id)
    {
        return await http.GetFromJsonAsync<Rental>($"rentals/{id}");
    }

}
