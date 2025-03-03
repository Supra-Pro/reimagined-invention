using ERP.Application.Abstractions.IServices;
using ERP.Domain;

namespace ERP.Application.Services;

public class VideoService : IVideoService
{
    private readonly IVideoRepository _videoRepository;

    public VideoService(IVideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task<Video> CreateVideo(Video video)
    {
        return await _videoRepository.Create(video);
    }

    public async Task<bool> UpdateVideo(int id, Video video)
    {
        var existingVideo = await _videoRepository.GetByAny(x => x.Id == id);
        if (existingVideo == null) return false;

        existingVideo.Title = video.Title;
        existingVideo.Description = video.Description;
        existingVideo.EmbedCode = video.EmbedCode;

        await _videoRepository.Update(existingVideo);
        return true;
    }

    public async Task<bool> DeleteVideo(int id)
    {
        return await _videoRepository.Delete(x => x.Id == id);
    }

    public async Task<Video?> GetById(int id)
    {
        return await _videoRepository.GetByAny(x => x.Id == id);
    }

    public async Task<List<Video>> GetAll()
    {
        return (await _videoRepository.GetAll()).ToList();
    }
}