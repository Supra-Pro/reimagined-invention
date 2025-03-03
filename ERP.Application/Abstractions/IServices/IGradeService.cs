using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Abstractions.IServices.IServices;

public interface IGradeService
{
    Task<Grade> AssignGrade(GradeDTO gradeDto);
    Task<bool> UpdateGrade(int id, GradeDTO gradeDto);
    Task<bool> DeleteGrade(int id);
    Task<Grade?> GetById(int id);
    Task<List<Grade>> GetByCourse(int courseId);
    Task<List<Grade>> GetByStudent(int studentId);
    Task<List<Grade>> GetAll();
}