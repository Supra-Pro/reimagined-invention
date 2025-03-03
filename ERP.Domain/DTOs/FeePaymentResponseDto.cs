namespace ERP.Domain.DTOs;

public class FeePaymentResponseDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public decimal Amount { get; set; }
    public string? Date { get; set; }
    public bool Status { get; set; }
    public string? PaymentMonth { get; set; }
}