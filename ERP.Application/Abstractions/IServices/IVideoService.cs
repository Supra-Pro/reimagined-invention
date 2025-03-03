using ERP.Domain;

namespace ERP.Application.Abstractions.IServices;

public interface IVideoService
{
    Task<Video> CreateVideo(Video video);
    Task<bool> UpdateVideo(int id, Video video);
    Task<bool> DeleteVideo(int id);
    Task<Video?> GetById(int id);
    Task<List<Video>> GetAll();
}