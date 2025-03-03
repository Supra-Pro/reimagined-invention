using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using ERP.Application.Abstractions.IServices;
using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ERP.Application.Abstractions.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepository userRepo, IConfiguration configuration)
    {
        _userRepo = userRepo;
        _configuration = configuration;
    }

    public async Task<User> Authenticate(string email, string password)
    {
        var user = await _userRepo.GetByAny(x => x.Email == email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            return null;

        return user;
    }

    public async Task<User> CreateUser(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        var createdUser = await _userRepo.Create(user);
        return createdUser;
    }

    public async Task<string> UpdateUser(int id, User user)
    {
        var existingUser = await _userRepo.GetByAny(x => x.Id == id);
        if (existingUser == null) return "User not found";

        // Check if the new email already exists (only if email is being changed)
        if (existingUser.Email != user.Email)
        {
            var emailExists = await _userRepo.GetByAny(x => x.Email == user.Email && x.Id != id) != null;
            if (emailExists) return "Email already exists";
        }

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        existingUser.Role = user.Role;

        if (!string.IsNullOrEmpty(user.Password))
            existingUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        await _userRepo.Update(existingUser);
        return "Updated";
    }

    public async Task<string> DeleteUser(int id)
    {
        var result = await _userRepo.Delete(x => x.Id == id);
        return result ? "Deleted" : "Failed";
    }

    public async Task<List<User>> GetAll()
    {
        var users = await _userRepo.GetAll();
        return users.Select(x => new User
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            Role = x.Role
        }).ToList();
    }

    public async Task<User> GetByEmail(string email)
    {
        var user = await _userRepo.GetByAny(x => x.Email == email);
        if (user == null) return null;

        return new User
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        };
    }

    public async Task<List<User>> GetByName(string fullname)
    {
        var users = await _userRepo.GetAll();
        return users.Where(x => x.Name == fullname)
                    .Select(x => new User
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email,
                        Role = x.Role
                    }).ToList();
    }

    public async Task<User> GetById(int id)
    {
        var user = await _userRepo.GetByAny(x => x.Id == id);
        if (user == null) return null;

        return new User
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        };
    }

    public async Task<(User user, string token)> LoginUser(string email, string password)
    {
        var user = await _userRepo.GetByAny(x => x.Email == email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            return (null, null);

        string token = await GenerateJwtToken(user);
        return (user, token);
    }

    public async Task<string> GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role) // Add role claim
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}