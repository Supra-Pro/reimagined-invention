using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Infrastructure.Persistance;

namespace ERP.Infrastructure.BaseRepositories;

public class GradeRepository: BaseRepository<Grade>, IGradeRepository
{
    public GradeRepository(ERPDbContext context) : base(context)
    {
    }
}