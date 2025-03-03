using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Infrastructure.Persistance;

namespace ERP.Infrastructure.BaseRepositories;

public class TeacherRepository: BaseRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(ERPDbContext context) : base(context)
    {
    }
}