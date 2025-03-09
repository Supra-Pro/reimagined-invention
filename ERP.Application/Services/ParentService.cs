using ERP.Application.Abstractions.IServices;
using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Services;

public class ParentService : IParentService
{
    private readonly IParentRepository _parentRepository;

    public ParentService(IParentRepository parentRepository)
    {
        _parentRepository = parentRepository;
    }

    public async Task<Parent> AddParent(ParentDTO parentDto)
    {
        var parent = new Parent
        {
            Name = parentDto.Name,
            Phone = parentDto.Phone,
            Student = parentDto.Students?.FirstOrDefault() != null ? new Student
            {
                Id = parentDto.Students.First().Id,
                Name = parentDto.Students.First().Name,
                Phone = parentDto.Students.First().Phone
            } : null
        };

        return await _parentRepository.Create(parent);
    }

    public async Task<bool> UpdateParent(int id, ParentDTO parentDto)
    {
        var existingParent = await _parentRepository.GetByAny(x => x.Id == id);
        if (existingParent == null) return false;

        existingParent.Name = parentDto.Name;
        existingParent.Phone = parentDto.Phone;
        
        if (parentDto.Students?.FirstOrDefault() != null)
        {
            existingParent.Student ??= new Student();
            existingParent.Student.Id = parentDto.Students.First().Id;
            existingParent.Student.Name = parentDto.Students.First().Name;
            existingParent.Student.Phone = parentDto.Students.First().Phone;
        }

        await _parentRepository.Update(existingParent);
        return true;
    }

    public async Task<bool> DeleteParent(int id)
    {
        return await _parentRepository.Delete(x => x.Id == id);
    }

    public async Task<Parent?> GetById(int id)
    {
        return await _parentRepository.GetByAny(x => x.Id == id);
    }

    public async Task<List<Parent>> GetByStudent(int studentId)
    {
        var allParents = await _parentRepository.GetAll();
        return allParents.Where(x => x.Student.Id == studentId).ToList();
    }

    public async Task<List<Parent>> GetAll()
    {
        return (await _parentRepository.GetAll()).ToList();
    }
}
