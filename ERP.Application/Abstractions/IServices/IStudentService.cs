using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Abstractions.IServices.IServices;

public interface IStudentService
{
    Task<Student> CreateStudent(StudentDTO studentDto);
    Task<bool> UpdateStudent(int id, Student student);
    Task<bool> DeleteStudent(int id);
    Task<Student?> GetById(int id);
    Task<List<Student>> GetAll();
    Task<List<Student>> GetByStatus(string status);
    Task<List<Student>> GetByCode(string code);
    Task<List<Student>> GetByEnrollmentDate(string date);
    Task<List<Student>> GetByCourse(int courseId);
}