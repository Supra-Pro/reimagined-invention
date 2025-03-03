using ERP.Application.DTOs;
using ERP.Domain;

namespace ERP.Application.Abstractions.IServices.IServices;

public interface IAttendanceService
{
    Task<Attendance> CreateAttendance(AttendanceDto attendanceDto);
    Task<bool> UpdateAttendance(int id, AttendanceDto attendanceDto);
    public Task<bool> DeleteAttendance(int id);
    public Task<List<Attendance>> GetAll();
    public Task<List<Attendance>> GetByDate(string dateTime);
    public Task<List<Attendance>> GetByCourse(int courseId);
    public Task<List<Attendance>> GetByStudent(int studentId);
    public Task<Attendance?> GetById(int id);
}