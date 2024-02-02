namespace Sakila.Model;

public class Rental
{
    public int Id { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int CustomerId { get; set; }
}