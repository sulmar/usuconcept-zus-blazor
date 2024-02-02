using Sakila.Abstractions;
using Sakila.Model;
using Microsoft.EntityFrameworkCore;

namespace Sakila.Infrastructure;

public class DbRentalRepository(SakilaContext context) : IRentalRepository
{
    public Task<List<Rental>> GetAllAsync()
    {
        return context.Rentals.AsNoTracking()
            .Take(200)
            .OrderByDescending(p=>p.RentalDate).ToListAsync();
    }

    public async Task<Rental> GetById(int id)
    {
        return await context.Rentals.FindAsync(id);
    }
}
