using ERP.Domain;

namespace ERP.Application.Abstractions.IServices.IServices;

public interface IUserService
{
    Task<User> Authenticate(string email, string password);
    Task<User> CreateUser(User user);
    public Task<string> UpdateUser(int id, User user);
    public Task<string> DeleteUser(int id);
    public Task<List<User>> GetAll();
    public Task<User> GetByEmail(string email);
    public Task<List<User>> GetByName(string fullname);
    public Task<User> GetById(int id);
    Task<string> GenerateJwtToken(User user);
}