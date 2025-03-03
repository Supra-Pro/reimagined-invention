namespace ERP.Domain;

public class Course
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public int Credits { get; set; }
    public string? Description { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new();
}