using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Abstractions.IServices.IServices;

public interface ITeacherService
{
    Task<Teacher> CreateTeacher(TeacherDTO teacherDto);
    Task<bool> UpdateTeacher(int id, TeacherDTO teacherDto);
    Task<bool> DeleteTeacher(int id);
    Task<Teacher?> GetById(int id);
    Task<List<Teacher>> GetAll();
}