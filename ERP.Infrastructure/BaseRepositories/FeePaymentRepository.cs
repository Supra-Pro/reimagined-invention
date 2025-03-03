using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Infrastructure.Persistance;

namespace ERP.Infrastructure.BaseRepositories;

public class FeePaymentRepository: BaseRepository<FeePayement>, IFeePaymentRepository
{
    public FeePaymentRepository(ERPDbContext context) : base(context)
    {
    }
}