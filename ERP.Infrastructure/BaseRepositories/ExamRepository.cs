using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Infrastructure.Persistance;

namespace ERP.Infrastructure.BaseRepositories;

public class ExamRepository: BaseRepository<Exam>, IExamRepository
{
    public ExamRepository(ERPDbContext context) : base(context)
    {
    }
}