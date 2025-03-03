using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.BaseRepositories;

public class UserRepository: BaseRepository<User>, IUserRepository
{
    public UserRepository(ERPDbContext context) : base(context)
    {
    }
}