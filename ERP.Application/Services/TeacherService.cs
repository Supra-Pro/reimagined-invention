using ERP.Application.Abstractions.IServices.IServices;
using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly ICourseRepository _courseRepository;

    public TeacherService(ITeacherRepository teacherRepository, ICourseRepository courseRepository)
    {
        _teacherRepository = teacherRepository;
        _courseRepository = courseRepository;
    }

    public async Task<Teacher> CreateTeacher(TeacherDTO teacherDto)
    {
        var teacher = new Teacher
        {
            Name = teacherDto.Name,
            Email = teacherDto.Email,
            Phone = teacherDto.Phone,
            Courses = new List<Course>()
        };

        if (teacherDto.Courses != null && teacherDto.Courses.Any())
        {
            foreach (var courseName in teacherDto.Courses)  // courseName is just a string
            {
                // Check if course already exists
                var existingCourse = await _courseRepository.GetByAny(c => c.Name == courseName);
            
                if (existingCourse != null)
                {
                    teacher.Courses.Add(existingCourse);
                }
                else
                {
                    // Create a new course if it doesn’t exist
                    var newCourse = new Course { Name = courseName };
                    var savedCourse = await _courseRepository.Create(newCourse);
                    teacher.Courses.Add(savedCourse);
                }
            }
        }

        return await _teacherRepository.Create(teacher);
    }



    public async Task<bool> UpdateTeacher(int id, TeacherDTO teacherDto)
    {
        var existingTeacher = await _teacherRepository.GetByAny(x => x.Id == id);
        if (existingTeacher == null) return false;

        existingTeacher.Name = teacherDto.Name;
        existingTeacher.Email = teacherDto.Email;
        existingTeacher.Phone = teacherDto.Phone;

        await _teacherRepository.Update(existingTeacher);
        return true;
    }

    public async Task<bool> DeleteTeacher(int id)
    {
        return await _teacherRepository.Delete(x => x.Id == id);
    }

    public async Task<Teacher?> GetById(int id)
    {
        return await _teacherRepository.GetByAny(x => x.Id == id);
    }

    public async Task<List<Teacher>> GetAll()
    {
        return (await _teacherRepository.GetAll()).ToList();
    }
}