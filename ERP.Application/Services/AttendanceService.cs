using ERP.Application.Abstractions.IServices;
using ERP.Application.Abstractions.IServices.IServices;
using ERP.Application.DTOs;
using ERP.Domain;

namespace ERP.Application.Abstractions.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendanceService(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    public async Task<Attendance> CreateAttendance(AttendanceDto attendanceDto)
    {
        var newAttendance = new Attendance
        {
            StudentId = attendanceDto.StudentId,
            CourseId = attendanceDto.CourseId,
            Date = attendanceDto.Date,
            Status = attendanceDto.Status
        };

        return await _attendanceRepository.Create(newAttendance);
    }

    public async Task<bool> UpdateAttendance(int id, AttendanceDto attendanceDto)
    {
        var existingAttendance = await _attendanceRepository.GetByAny(x => x.Id == id);
        if (existingAttendance == null) return false;

        existingAttendance.StudentId = attendanceDto.StudentId;
        existingAttendance.CourseId = attendanceDto.CourseId;
        existingAttendance.Date = attendanceDto.Date;
        existingAttendance.Status = attendanceDto.Status;

        await _attendanceRepository.Update(existingAttendance);
        return true;
    }

    public async Task<bool> DeleteAttendance(int id)
    {
        return await _attendanceRepository.Delete(x => x.Id == id);
    }

    public async Task<List<Attendance>> GetAll()
    {
        return (await _attendanceRepository.GetAll()).ToList();
    }

    public async Task<List<Attendance>> GetByDate(string dateTime)
    {
        var allAttendance = await _attendanceRepository.GetAll();
        return allAttendance.Where(x => x.Date == dateTime).ToList();
    }

    public async Task<List<Attendance>> GetByCourse(int courseId)
    {
        var allAttendance = await _attendanceRepository.GetAll();
        return allAttendance.Where(x => x.CourseId == courseId).ToList();
    }

    public async Task<List<Attendance>> GetByStudent(int studentId)
    {
        var allAttendance = await _attendanceRepository.GetAll();
        return allAttendance.Where(x => x.StudentId == studentId).ToList();
    }

    public async Task<Attendance?> GetById(int id)
    {
        return await _attendanceRepository.GetByAny(x => x.Id == id);
    }
}
