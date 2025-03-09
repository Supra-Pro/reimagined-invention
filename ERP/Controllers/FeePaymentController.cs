using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeePaymentController : ControllerBase
    {
        private readonly IFeePaymentService _feePaymentService;

        public FeePaymentController(IFeePaymentService feePaymentService)
        {
            _feePaymentService = feePaymentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateFeePayment(CreateFeePaymentDto feePaymentDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Console.WriteLine("Validation Errors: " + string.Join(", ", errors));
                return BadRequest(ModelState);
            }

            var result = await _feePaymentService.CreatePayment(feePaymentDto);
            return CreatedAtAction(nameof(GetFeePaymentById), new { id = result.Id }, result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateFeePayment(int id, UpdateFeePaymentDto feePaymentDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Console.WriteLine("Validation Errors: " + string.Join(", ", errors));
                return BadRequest(ModelState);
            }

            var result = await _feePaymentService.UpdatePayment(id, feePaymentDto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFeePayment(int id)
        {
            var result = await _feePaymentService.DeletePayment(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetFeePaymentById(int id)
        {
            var feePayment = await _feePaymentService.GetById(id);
            if (feePayment == null) return NotFound();
            return Ok(feePayment);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllFeePayments()
        {
            var feePayments = await _feePaymentService.GetAll();
            return Ok(feePayments);
        }

        [HttpGet("byStudent/{studentId}")]
        public async Task<IActionResult> GetFeePaymentsByStudent(int studentId)
        {
            var feePayments = await _feePaymentService.GetByStudent(studentId);
            return Ok(feePayments);
        }

        [HttpGet("byMonth/{paymentMonth}")]
        public async Task<IActionResult> GetFeePaymentsByMonth(string paymentMonth)
        {
            var feePayments = await _feePaymentService.GetByMonth(paymentMonth);
            return Ok(feePayments);
        }
    }
}
