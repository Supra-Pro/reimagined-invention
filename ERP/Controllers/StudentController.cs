using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;
using ERP.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var students = await _studentService.GetByStatus(status);
            return Ok(students);
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var students = await _studentService.GetByCode(code);
            return Ok(students);
        }

        [HttpGet("course/{courseId:int}")]
        public async Task<IActionResult> GetByCourse(int courseId)
        {
            var students = await _studentService.GetByCourse(courseId);
            return Ok(students);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent(StudentDTO studentDto)
        {
            if (studentDto == null) return BadRequest("Invalid student data.");

            var result = await _studentService.CreateStudent(studentDto);
            if (result == null) return BadRequest("Could not create student.");

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (student == null) return BadRequest("Invalid student data.");

            var result = await _studentService.UpdateStudent(id, student);
            if (!result) return NotFound("Student not found.");

            return Ok("Student updated successfully.");
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudent(id);
            if (!result) return NotFound("Student not found.");

            return Ok("Student deleted successfully.");
        }
    }
}
