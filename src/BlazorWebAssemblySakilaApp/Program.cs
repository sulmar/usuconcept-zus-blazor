using Blazored.LocalStorage;
using BlazorWebAssemblySakilaApp;
using BlazorWebAssemblySakilaApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// dotnet add package Microsoft.Extensions.Http
builder.Services.AddHttpClient<ApiFilmService>(sp => sp.BaseAddress = new Uri("https://localhost:7131"));
builder.Services.AddHttpClient<ApiAuthService>(sp => sp.BaseAddress = new Uri("https://localhost:7119"));

builder.Services.AddAuthorizationCore();

// dotnet add package Microsoft.AspNetCore.Components.Authorization
// W pliku App.razor zamieñ RouteView na AuthorizeRouteView

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthenticationStateProvider>());


// dotnet add package Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
