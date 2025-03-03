using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignGrade(GradeDTO gradeDto)
        {
            var result = await _gradeService.AssignGrade(gradeDto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateGrade(int id, GradeDTO gradeDto)
        {
            var result = await _gradeService.UpdateGrade(id, gradeDto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var result = await _gradeService.DeleteGrade(id);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetGradeById(int id)
        {
            var grade = await _gradeService.GetById(id);
            return Ok(grade);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllGrades()
        {
            var grades = await _gradeService.GetAll();
            return Ok(grades);
        }

        [HttpGet("byCourse/{courseId}")]
        public async Task<IActionResult> GetGradesByCourse(int courseId)
        {
            var grades = await _gradeService.GetByCourse(courseId);
            return Ok(grades);
        }

        [HttpGet("byStudent/{studentId}")]
        public async Task<IActionResult> GetGradesByStudent(int studentId)
        {
            var grades = await _gradeService.GetByStudent(studentId);
            return Ok(grades);
        }
    }
}