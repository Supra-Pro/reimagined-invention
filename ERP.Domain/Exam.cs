namespace ERP.Domain;

public class Exam
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; } = new();
    public string? Type { get; set; }
    public int TotalMarks { get; set; }
}