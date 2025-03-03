using ERP.Application.Abstractions.IServices;
using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Services;

public class GradeService : IGradeService
{
    private readonly IGradeRepository _gradeRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;

    public GradeService(IGradeRepository gradeRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
    {
        _gradeRepository = gradeRepository;
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
    }

    public async Task<Grade> AssignGrade(GradeDTO gradeDto)
    {
        var student = await _studentRepository.GetByAny(s => s.Id == gradeDto.StudentId);
        if (student == null)
            throw new ArgumentException("Student not found.");

        var course = await _courseRepository.GetByAny(c => c.Id == gradeDto.CourseId);
        if (course == null)
            throw new ArgumentException("Course not found.");

        var grade = new Grade
        {
            StudentId = gradeDto.StudentId,
            CourseId = gradeDto.CourseId,
            Score = gradeDto.Score,
            ExamType = gradeDto.ExamType,
            Remarks = gradeDto.Remarks
        };

        return await _gradeRepository.Create(grade);
    }

    public async Task<bool> UpdateGrade(int id, GradeDTO gradeDto)
    {
        var existingGrade = await _gradeRepository.GetByAny(g => g.Id == id);
        if (existingGrade == null) return false;

        existingGrade.Score = gradeDto.Score;
        existingGrade.ExamType = gradeDto.ExamType;
        existingGrade.Remarks = gradeDto.Remarks;

        await _gradeRepository.Update(existingGrade);
        return true;
    }

    public async Task<bool> DeleteGrade(int id)
    {
        return await _gradeRepository.Delete(g => g.Id == id);
    }

    public async Task<Grade?> GetById(int id)
    {
        return await _gradeRepository.GetByAny(g => g.Id == id);
    }

    public async Task<List<Grade>> GetByCourse(int courseId)
    {
        var grades = await _gradeRepository.GetAll();
        return grades.Where(g => g.CourseId == courseId).ToList();
    }

    public async Task<List<Grade>> GetByStudent(int studentId)
    {
        var grades = await _gradeRepository.GetAll();
        return grades.Where(g => g.StudentId == studentId).ToList();
    }

    public async Task<List<Grade>> GetAll()
    {
        return (await _gradeRepository.GetAll()).ToList();
    }
}