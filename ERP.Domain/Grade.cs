namespace ERP.Domain;

public class Grade
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = new();
    public int CourseId { get; set; }
    public Course Course { get; set; } = new();
    public string? ExamType { get; set; }
    public double Score { get; set; }
    public string Remarks { get; set; } = "Good";
}