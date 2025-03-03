namespace ERP.Domain;

public class Attendance
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = new();
    public int CourseId { get; set; }
    public Course Course { get; set; } = new();
    public string? Date { get; set; }
    public string Status { get; set; } = "Present";
}