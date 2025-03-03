namespace ERP.Domain;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = new();
    public int CourseId { get; set; }
    public Course Course { get; set; } = new();
    public string? EnrollDate { get; set; }
    public string Status { get; set; } = "Enrolled";

}