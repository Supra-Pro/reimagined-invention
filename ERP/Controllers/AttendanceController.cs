using ERP.Application.Abstractions.IServices.IServices;
using ERP.Application.DTOs;
using ERP.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Attendance>>> GetAll()
        {
            var attendanceRecords = await _attendanceService.GetAll();
            return Ok(attendanceRecords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetById(int id)
        {
            var attendance = await _attendanceService.GetById(id);
            if (attendance == null)
                return NotFound();
            return Ok(attendance);
        }

        [HttpPost]
        public async Task<ActionResult<Attendance>> CreateAttendance([FromBody] AttendanceDto attendanceDto)
        {
            var createdAttendance = await _attendanceService.CreateAttendance(attendanceDto);
            return CreatedAtAction(nameof(GetById), new { id = createdAttendance.Id }, createdAttendance);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAttendance(int id, [FromBody] AttendanceDto attendanceDto)
        {
            var updated = await _attendanceService.UpdateAttendance(id, attendanceDto);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAttendance(int id)
        {
            var deleted = await _attendanceService.DeleteAttendance(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}