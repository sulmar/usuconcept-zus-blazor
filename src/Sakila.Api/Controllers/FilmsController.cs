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
    public async Task<ActionResult<List<Film>>> Get([FromQuery] SearchCriteria searchCriteria)
    {       
        var films = await repository.GetByTextAsync(searchCriteria);

        var totalItemCount = await repository.GetTotalItemCount();

        HttpContext.Response.Headers.Add("x-total-item-count", totalItemCount.ToString());

        return Ok(films);
    }
}
