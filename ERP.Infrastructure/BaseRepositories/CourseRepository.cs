using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Infrastructure.Persistance;

namespace ERP.Infrastructure.BaseRepositories;

public class CourseRepository: BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(ERPDbContext context) : base(context)
    {
    }
}