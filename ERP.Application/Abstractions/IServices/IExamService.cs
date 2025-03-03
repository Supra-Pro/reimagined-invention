using ERP.Application.DTOs;
using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Abstractions.IServices.IServices
{
    public interface IExamService
    {
        Task<Exam> CreateExam(ExamDto examDto);
        Task<bool> UpdateExam(int id, ExamDto examDto);
        Task<bool> DeleteExam(int id);
        Task<Exam?> GetById(int id);
        Task<List<Exam>> GetByCourse(int courseId);
        Task<List<Exam>> GetAll();
    }
}