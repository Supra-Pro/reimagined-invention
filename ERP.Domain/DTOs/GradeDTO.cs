namespace ERP.Domain.DTOs;

public class GradeDTO
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public double Score { get; set; }
    public string? ExamType { get; set; }
    public string? Remarks { get; set; }
}