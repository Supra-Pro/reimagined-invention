using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;
using ERP.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateExam([FromBody] ExamDto examDto)
        {
            var result = await _examService.CreateExam(examDto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateExam(int id, [FromBody] ExamDto examDto)
        {
            var result = await _examService.UpdateExam(id, examDto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var result = await _examService.DeleteExam(id);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
            var exam = await _examService.GetById(id);
            return Ok(exam);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllExams()
        {
            var exams = await _examService.GetAll();
            return Ok(exams);
        }
    }
}