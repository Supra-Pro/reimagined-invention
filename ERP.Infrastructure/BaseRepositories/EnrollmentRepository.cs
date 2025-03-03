using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Infrastructure.Persistance;

namespace ERP.Infrastructure.BaseRepositories;

public class EnrollmentRepository: BaseRepository<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(ERPDbContext context) : base(context)
    {
    }
}