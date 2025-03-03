namespace ERP.Domain;

public class Student
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Dob { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? EnrollmentDate { get; set; }
    public string Status { get; set; } = "Active";
    public List<Enrollment> Enrollments { get; set; } = new();
}