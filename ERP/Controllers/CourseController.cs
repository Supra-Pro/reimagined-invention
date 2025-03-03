using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCourse(CourseDTO courseDto)
        {
            var result = await _courseService.CreateCourse(courseDto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseDTO courseDto)
        {
            var result = await _courseService.UpdateCourse(id, courseDto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourse(id);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetById(id);
            return Ok(course);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAll();
            return Ok(courses);
        }
    }
}