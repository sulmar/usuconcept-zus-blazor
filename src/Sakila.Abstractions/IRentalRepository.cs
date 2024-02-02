using Sakila.Model;

namespace Sakila.Abstractions;

public interface IRentalRepository
{
    Task<List<Rental>> GetAllAsync();
    Task<Rental> GetById(int id);
}