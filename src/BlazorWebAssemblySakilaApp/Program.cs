using Blazored.LocalStorage;
using BlazorWebAssemblySakilaApp;
using BlazorWebAssemblySakilaApp.Authorization;
using BlazorWebAssemblySakilaApp.Model;
using BlazorWebAssemblySakilaApp.Services;
using Fluxor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// dotnet add package Microsoft.Extensions.Http
builder.Services.AddHttpClient<ApiFilmService>(sp => sp.BaseAddress = new Uri("https://localhost:7131"));
builder.Services.AddHttpClient<ApiRentalService>(sp => sp.BaseAddress = new Uri("https://localhost:7131"));
builder.Services.AddHttpClient<ApiAuthService>(sp => sp.BaseAddress = new Uri("https://localhost:7119"));

builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("Adult", Policies.AdultPolicy());
    options.AddPolicy("ReturnPolicy", policy => policy.Requirements.Add(new OwnerRequirement()));
});

builder.Services.AddScoped<IAuthorizationHandler, AgeAuthorizationHandler>();
builder.Services.AddScoped<IAuthorizationHandler, RentalAuthorizationHandler>();

// dotnet add package Microsoft.AspNetCore.Components.Authorization
// W pliku App.razor zamieñ RouteView na AuthorizeRouteView

builder.Services.AddCascadingAuthenticationState();

// Globalna rejestracja parametru kaskadowego
// builder.Services.AddCascadingValue(sp => new MyContext { Count = 10 });

builder.Services.AddCascadingValue(sp =>
{
    var context = new MyContext { Count = 10 };
    var source = new CascadingValueSource<MyContext>(context, isFixed: false);
    return source;
});

builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthenticationStateProvider>());


// dotnet add package Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();


// dotnet add package Fluxor
// dotnet add package Fluxor.Blazor.Web
// dotnet add package Fluxor.Blazor.Web.ReduxDevTools

builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(Program).Assembly);
    options.UseReduxDevTools(o =>
    {
        o.Name = "SakilaApp";
    });
});

await builder.Build().RunAsync();
