using BlazorSSRSakilaApp.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorSSRSakilaApp.Components.Pages.Film;

[StreamRendering]
public partial class List
{
    private List<Model.Film> films;

    [Inject]
    public SakilaContext context { get; set; }

    protected override async Task OnInitializedAsync()
    {
        films = await context.Films.ToListAsync();
    }
}
