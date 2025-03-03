using ERP.Application.Abstractions.IServices;
using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Course> CreateCourse(CourseDTO courseDto)
    {
        var course = new Course
        {
            Name = courseDto.Name,
            Code = courseDto.Code,
            Credits = courseDto.Credits,
            Description = courseDto.Description
        };

        return await _courseRepository.Create(course);
    }

    public async Task<bool> UpdateCourse(int id, CourseDTO courseDto)
    {
        var existingCourse = await _courseRepository.GetByAny(x => x.Id == id);
        if (existingCourse == null) return false;

        existingCourse.Name = courseDto.Name;
        existingCourse.Code = courseDto.Code;
        existingCourse.Credits = courseDto.Credits;
        existingCourse.Description = courseDto.Description;

        await _courseRepository.Update(existingCourse);
        return true;
    }

    public async Task<bool> DeleteCourse(int id)
    {
        return await _courseRepository.Delete(x => x.Id == id);
    }

    public async Task<Course?> GetById(int id)
    {
        return await _courseRepository.GetByAny(x => x.Id == id);
    }

    public async Task<List<Course>> GetAll()
    {
        return (await _courseRepository.GetAll()).ToList();
    }

    public async Task<List<Course>> GetByStudent(int studentId)
    {
        var allCourses = await _courseRepository.GetAll();
        return allCourses.Where(x => x.Enrollments.Any(e => e.StudentId == studentId)).ToList();
    }

    public async Task<List<Course>> SearchCourses(string keyword)
    {
        var allCourses = await _courseRepository.GetAll();
        return allCourses.Where(x => x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                     x.Code.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                     x.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                         .ToList();
    }
}
