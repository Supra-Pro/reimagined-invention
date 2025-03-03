using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Infrastructure.Persistance;

namespace ERP.Infrastructure.BaseRepositories;

public class StudentRepository: BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(ERPDbContext context) : base(context)
    {
    }
}