using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;

        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateParent(ParentDTO parentDto)
        {
            var result = await _parentService.AddParent(parentDto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateParent(int id, ParentDTO parentDto)
        {
            var result = await _parentService.UpdateParent(id, parentDto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var result = await _parentService.DeleteParent(id);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetParentById(int id)
        {
            var parent = await _parentService.GetById(id);
            return Ok(parent);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllParents()
        {
            var parents = await _parentService.GetAll();
            return Ok(parents);
        }

        [HttpGet("byStudent/{studentId}")]
        public async Task<IActionResult> GetParentsByStudent(int studentId)
        {
            var parents = await _parentService.GetByStudent(studentId);
            return Ok(parents);
        }
    }
}