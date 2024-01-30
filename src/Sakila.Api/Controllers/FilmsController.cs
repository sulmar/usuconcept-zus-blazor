using Sakila.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Sakila.Abstractions;
using Sakila.Model;

namespace Sakila.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmsController(IFilmRepository repository) : ControllerBase
{
    // GET /films
    [HttpGet]
    public async Task<ActionResult<List<Film>>> Get()
    {
        var films = await repository.GetAllAsync();

        return Ok(films);
    }
}
