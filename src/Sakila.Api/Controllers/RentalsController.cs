using Microsoft.AspNetCore.Mvc;
using Sakila.Abstractions;
using Sakila.Model;

namespace Sakila.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RentalsController(IRentalRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Rental>>> Get()
    {
        return Ok(await repository.GetAllAsync());
    }

    // GET /rentals/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Rental>> GetById(int id)
    {
        var rental = await repository.GetById(id);

        if (rental is null)
            return NotFound();

        return Ok(rental);
    }
}
