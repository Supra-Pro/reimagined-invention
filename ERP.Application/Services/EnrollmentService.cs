using ERP.Application.Abstractions.IServices;
using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;

namespace ERP.Application.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;

    public EnrollmentService(
        IEnrollmentRepository enrollmentRepository,
        ICourseRepository courseRepository,
        IStudentRepository studentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
    }

    public async Task<Enrollment> EnrollStudent(int studentId, int courseId)
    {
        var student = await _studentRepository.GetByAny(s => s.Id == studentId);
        if (student == null)
            throw new ArgumentException("Student not found.");

        var course = await _courseRepository.GetByAny(c => c.Id == courseId);
        if (course == null)
            throw new ArgumentException("Course not found.");

        var existingEnrollment = await _enrollmentRepository.GetByAny(e => e.StudentId == studentId && e.CourseId == courseId);
        if (existingEnrollment != null)
            throw new InvalidOperationException("Student is already enrolled in this course.");

        var enrollment = new Enrollment
        {
            StudentId = studentId,
            CourseId = courseId,
            EnrollDate = DateTime.Now.ToString("u"),
            Status = "Enrolled"
        };

        return await _enrollmentRepository.Create(enrollment);
    }

    public async Task<bool> UnenrollStudent(int studentId, int courseId)
    {
        var enrollment = await _enrollmentRepository.GetByAny(e => e.StudentId == studentId && e.CourseId == courseId);
        if (enrollment == null) return false;

        return await _enrollmentRepository.Delete(e => e.Id == enrollment.Id);
    }

    public async Task<List<Enrollment>> GetByCourse(int courseId)
    {
        var enrollments = await _enrollmentRepository.GetAll();
        return enrollments.Where(e => e.CourseId == courseId).ToList();
    }

    public async Task<List<Enrollment>> GetByStudent(int studentId)
    {
        var enrollments = await _enrollmentRepository.GetAll();
        return enrollments.Where(e => e.StudentId == studentId).ToList();
    }

    public async Task<Enrollment?> GetById(int id)
    {
        return await _enrollmentRepository.GetByAny(e => e.Id == id);
    }
}
