using Sakila.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Sakila.Abstractions;
using Sakila.Model;

namespace Sakila.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmsController(IFilmRepository repository) : ControllerBase
{
    // GET /films?filter={filter}
    [HttpGet]
    public async Task<ActionResult<List<Film>>> Get(string? filter)
    {       
        var films = await repository.GetByTextAsync(filter);

        return Ok(films);
    }
}
