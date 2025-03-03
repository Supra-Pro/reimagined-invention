using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Infrastructure.Persistance;

namespace ERP.Infrastructure.BaseRepositories;

public class AttendanceRepository: BaseRepository<Attendance>, IAttendanceRepository
{
    public AttendanceRepository(ERPDbContext context) : base(context)
    {
    }
}