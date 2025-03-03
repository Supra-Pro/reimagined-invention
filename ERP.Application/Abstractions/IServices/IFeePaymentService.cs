using ERP.Domain.DTOs;

namespace ERP.Application.Abstractions.IServices.IServices
{
    public interface IFeePaymentService
    {
        Task<FeePaymentResponseDto> CreatePayment(CreateFeePaymentDto feePaymentDto);
        Task<bool> UpdatePayment(int id, UpdateFeePaymentDto feePaymentDto);
        Task<bool> DeletePayment(int id);
        Task<FeePaymentResponseDto?> GetById(int id);
        Task<List<FeePaymentResponseDto>> GetByStudent(int studentId);
        Task<List<FeePaymentResponseDto>> GetAll();
        Task<List<FeePaymentResponseDto>> GetByMonth(string paymentMonth);
    }
}