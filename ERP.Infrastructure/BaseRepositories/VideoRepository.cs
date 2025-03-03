using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Infrastructure.Persistance;

namespace ERP.Infrastructure.BaseRepositories;

public class VideoRepository: BaseRepository<Video>, IVideoRepository
{
    public VideoRepository(ERPDbContext context) : base(context)
    {
    }
}