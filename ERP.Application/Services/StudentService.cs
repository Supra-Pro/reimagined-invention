using ERP.Application.Abstractions.IServices.IServices;
using ERP.Application.Abstractions.IServices;
using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;

    public StudentService(IStudentRepository studentRepository, IEnrollmentRepository enrollmentRepository)
    {
        _studentRepository = studentRepository;
        _enrollmentRepository = enrollmentRepository;
    }

    public async Task<Student> CreateStudent(StudentDTO studentDto)
    {
        var student = new Student
        {
            Name = studentDto.Name,
            Code = studentDto.Code,
            Phone = studentDto.Phone,
            Dob = studentDto.Dob,
            Email = studentDto.Email,
            EnrollmentDate = studentDto.EnrollmentDate,
            Status = "Active"
        };
        return await _studentRepository.Create(student);
    }


    public async Task<bool> UpdateStudent(int id, Student studentDto)
    {
        var existingStudent = await _studentRepository.GetByAny(x => x.Id == id);
        if (existingStudent == null) return false;

        existingStudent.Name = studentDto.Name;
        existingStudent.Code = studentDto.Code;
        existingStudent.Phone = studentDto.Phone;
        existingStudent.Dob = studentDto.Dob;
        existingStudent.Email = studentDto.Email;
        existingStudent.EnrollmentDate = studentDto.EnrollmentDate;

        await _studentRepository.Update(existingStudent);
        return true;
    }

    public async Task<bool> DeleteStudent(int id)
    {
        return await _studentRepository.Delete(x => x.Id == id);
    }

    public async Task<Student?> GetById(int id)
    {
        return await _studentRepository.GetByAny(x => x.Id == id);
    }

    public async Task<List<Student>> GetAll()
    {
        return (await _studentRepository.GetAll()).ToList();
    }

    public async Task<List<Student>> GetByEnrollmentDate(string date)
    {
        var allStudents = await _studentRepository.GetAll();
        return allStudents.Where(x => x.EnrollmentDate == date).ToList();
    }

    public async Task<List<Student>> GetByStatus(string status)
    {
        var allStudents = await _studentRepository.GetAll();
        return allStudents.Where(x => x.Status == status).ToList();
    }

    public async Task<List<Student>> GetByCode(string code)
    {
        var allStudents = await _studentRepository.GetAll();
        return allStudents.Where(x => x.Code == code).ToList();
    }

    public async Task<List<Student>> GetByCourse(int courseId)
    {
        var enrollments = await _enrollmentRepository.GetAll();
        var studentIds = enrollments.Where(e => e.CourseId == courseId).Select(e => e.StudentId).ToList();
        var students = await _studentRepository.GetAll();
        return students.Where(s => studentIds.Contains(s.Id)).ToList();
    }
}
