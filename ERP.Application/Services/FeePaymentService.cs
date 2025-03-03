using ERP.Application.Abstractions.IServices;
using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;
using ERP.Domain.DTOs;

namespace ERP.Application.Services
{
    public class FeePaymentService : IFeePaymentService
    {
        private readonly IFeePaymentRepository _feePaymentRepository;
        private readonly IStudentRepository _studentRepository;

        public FeePaymentService(IFeePaymentRepository feePaymentRepository, IStudentRepository studentRepository)
        {
            _feePaymentRepository = feePaymentRepository;
            _studentRepository = studentRepository;
        }

        public async Task<FeePaymentResponseDto> CreatePayment(CreateFeePaymentDto feePaymentDto)
        {
            var student = await _studentRepository.GetByAny(s => s.Id == feePaymentDto.StudentId);
            if (student == null)
                throw new ArgumentException("Student not found.");

            var feePayment = new FeePayement
            {
                StudentId = feePaymentDto.StudentId,
                Amount = feePaymentDto.Amount,
                Date = feePaymentDto.Date,
                Status = feePaymentDto.Status,
                PaymentMonth = feePaymentDto.PaymentMonth
            };

            var createdPayment = await _feePaymentRepository.Create(feePayment);
            return MapToDto(createdPayment);
        }

        public async Task<bool> UpdatePayment(int id, UpdateFeePaymentDto feePaymentDto)
        {
            var existingPayment = await _feePaymentRepository.GetByAny(p => p.Id == id);
            if (existingPayment == null) return false;

            existingPayment.Amount = feePaymentDto.Amount;
            existingPayment.Date = feePaymentDto.Date;
            existingPayment.Status = feePaymentDto.Status;
            existingPayment.PaymentMonth = feePaymentDto.PaymentMonth;

            await _feePaymentRepository.Update(existingPayment);
            return true;
        }

        public async Task<bool> DeletePayment(int id)
        {
            return await _feePaymentRepository.Delete(p => p.Id == id);
        }

        public async Task<FeePaymentResponseDto?> GetById(int id)
        {
            var payment = await _feePaymentRepository.GetByAny(p => p.Id == id);
            return payment == null ? null : MapToDto(payment);
        }

        public async Task<List<FeePaymentResponseDto>> GetByStudent(int studentId)
        {
            var payments = await _feePaymentRepository.GetAll();
            return payments.Where(p => p.StudentId == studentId).Select(MapToDto).ToList();
        }

        public async Task<List<FeePaymentResponseDto>> GetAll()
        {
            var payments = await _feePaymentRepository.GetAll();
            return payments.Select(MapToDto).ToList();
        }

        public async Task<List<FeePaymentResponseDto>> GetByMonth(string paymentMonth)
        {
            var payments = await _feePaymentRepository.GetAll();
            return payments.Where(p => p.PaymentMonth == paymentMonth).Select(MapToDto).ToList();
        }

        private static FeePaymentResponseDto MapToDto(FeePayement payment)
        {
            return new FeePaymentResponseDto
            {
                Id = payment.Id,
                StudentId = payment.StudentId,
                Amount = payment.Amount,
                Date = payment.Date,
                Status = payment.Status,
                PaymentMonth = payment.PaymentMonth
            };
        }
    }
}
