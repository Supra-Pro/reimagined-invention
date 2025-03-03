using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeacher(TeacherDTO teacherDto)
        {
            var result = await _teacherService.CreateTeacher(teacherDto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, TeacherDTO teacherDto)
        {
            var result = await _teacherService.UpdateTeacher(id, teacherDto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var result = await _teacherService.DeleteTeacher(id);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _teacherService.GetById(id);
            return Ok(teacher);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAll();
            return Ok(teachers);
        }
    }
}