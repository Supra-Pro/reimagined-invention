using ERP.Application.Abstractions.IServices;
using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Services;

public class ExamService : IExamService
{
    private readonly IExamRepository _examRepository;
    private readonly ICourseRepository _courseRepository;

    public ExamService(IExamRepository examRepository, ICourseRepository courseRepository)
    {
        _examRepository = examRepository;
        _courseRepository = courseRepository;
    }

    public async Task<Exam> CreateExam(ExamDto examDto)
    {
        var course = await _courseRepository.GetByAny(c => c.Id == examDto.CourseId);
        if (course == null)
            throw new ArgumentException("Course not found.");

        var newExam = new Exam
        {
            CourseId = examDto.CourseId,
            Type = examDto.Type,
            TotalMarks = examDto.TotalMarks
        };

        return await _examRepository.Create(newExam);
    }

    public async Task<bool> UpdateExam(int id, ExamDto examDto)
    {
        var existingExam = await _examRepository.GetByAny(e => e.Id == id);
        if (existingExam == null) return false;

        existingExam.Type = examDto.Type;
        existingExam.TotalMarks = examDto.TotalMarks;
        existingExam.CourseId = examDto.CourseId;

        await _examRepository.Update(existingExam);
        return true;
    }

    public async Task<bool> DeleteExam(int id)
    {
        return await _examRepository.Delete(e => e.Id == id);
    }

    public async Task<Exam?> GetById(int id)
    {
        return await _examRepository.GetByAny(e => e.Id == id);
    }

    public async Task<List<Exam>> GetByCourse(int courseId)
    {
        var exams = await _examRepository.GetAll();
        return exams.Where(e => e.CourseId == courseId).ToList();
    }

    public async Task<List<Exam>> GetAll()
    {
        return (await _examRepository.GetAll()).ToList();
    }
}