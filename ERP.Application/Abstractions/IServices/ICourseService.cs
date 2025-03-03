using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Abstractions.IServices.IServices;

public interface ICourseService
{
    Task<Course> CreateCourse(CourseDTO courseDto);
    Task<bool> UpdateCourse(int id, CourseDTO courseDto);
    Task<bool> DeleteCourse(int id); 
    Task<Course?> GetById(int id); 
    Task<List<Course>> GetAll(); 
    Task<List<Course>> GetByStudent(int studentId); 
    Task<List<Course>> SearchCourses(string keyword); 
}