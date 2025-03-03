using ERP.Domain;

namespace ERP.Application.Abstractions.IServices.IServices;

public interface IEnrollmentService
{
    Task<Enrollment> EnrollStudent(int studentId, int courseId); 
    Task<bool> UnenrollStudent(int studentId, int courseId); 
    Task<List<Enrollment>> GetByCourse(int courseId); 
    Task<List<Enrollment>> GetByStudent(int studentId); 
    Task<Enrollment?> GetById(int id); 
}
