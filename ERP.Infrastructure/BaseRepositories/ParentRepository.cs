using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Infrastructure.Persistance;

namespace ERP.Infrastructure.BaseRepositories;

public class ParentRepository: BaseRepository<Parent>, IParentRepository
{
    public ParentRepository(ERPDbContext context) : base(context)
    {
    }
}