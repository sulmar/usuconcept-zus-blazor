using BlazorWebAssemblySakilaApp.Model;
using System.Net.Http.Json;

namespace BlazorWebAssemblySakilaApp.Services;

public class ApiAuthService(HttpClient http)
{
    public async Task<string> CreateToken(LoginModel model)
    {
        var response = await http.PostAsJsonAsync("/api/token/create", model);

        var token = await response.Content.ReadFromJsonAsync<string>();

        return token;
    }
}