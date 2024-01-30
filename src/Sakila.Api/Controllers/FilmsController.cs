using Sakila.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Sakila.Abstractions;
using Sakila.Model;

namespace Sakila.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IFilmRepository repository;

    public FilmsController(IFilmRepository repository)
    {
        this.repository = repository;
    }

    // GET /films
    [HttpGet]
    public async Task<ActionResult<List<Film>>> Get()
    {
        var films = await repository.GetAllAsync();

        return Ok(films);
    }
}
