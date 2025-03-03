using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost("enroll")]
        public async Task<IActionResult> EnrollStudent(int studentId, int courseId)
        {
            try
            {
                var enrollment = await _enrollmentService.EnrollStudent(studentId, courseId);
                return Ok(enrollment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("unenroll")]
        public async Task<IActionResult> UnenrollStudent(int studentId, int courseId)
        {
            var result = await _enrollmentService.UnenrollStudent(studentId, courseId);
            if (result)
                return Ok("Student unenrolled successfully.");
            else
                return NotFound("Enrollment not found.");
        }

        [HttpGet("byCourse/{courseId}")]
        public async Task<IActionResult> GetEnrollmentsByCourse(int courseId)
        {
            var enrollments = await _enrollmentService.GetByCourse(courseId);
            return Ok(enrollments);
        }

        [HttpGet("byStudent/{studentId}")]
        public async Task<IActionResult> GetEnrollmentsByStudent(int studentId)
        {
            var enrollments = await _enrollmentService.GetByStudent(studentId);
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var enrollment = await _enrollmentService.GetById(id);
            if (enrollment != null)
                return Ok(enrollment);
            return NotFound("Enrollment not found.");
        }
    }
}
