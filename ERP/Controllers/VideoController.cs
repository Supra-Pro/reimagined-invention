using ERP.Application.Abstractions.IServices;
using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateVideo(Video video)
        {
            var result = await _videoService.CreateVideo(video);
            return CreatedAtAction(nameof(GetVideoById), new { id = result.Id }, result); 
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateVideo(int id, Video video)
        {
            var result = await _videoService.UpdateVideo(id, video);
            if (result == null) 
            {
                return NotFound();
            }
            return NoContent(); 
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var result = await _videoService.DeleteVideo(id);
            if (!result) 
            {
                return NotFound();
            }
            return NoContent(); 
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetVideoById(int id)
        {
            var video = await _videoService.GetById(id);
            if (video == null)
            {
                return NotFound();
            }
            return Ok(video); 
        }
    }
}