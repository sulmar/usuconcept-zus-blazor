namespace Auth.Api.Model;

public class UserIdentity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
}
