namespace ERP.Domain;

public class CreateUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Name { get; set; }
}
