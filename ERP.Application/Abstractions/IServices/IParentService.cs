using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Abstractions.IServices.IServices;

public interface IParentService
{
    Task<Parent> AddParent(ParentDTO parentDto);
    Task<bool> UpdateParent(int id, ParentDTO parentDto);
    Task<bool> DeleteParent(int id);
    Task<Parent?> GetById(int id);
    Task<List<Parent>> GetByStudent(int studentId);
    Task<List<Parent>> GetAll();
}