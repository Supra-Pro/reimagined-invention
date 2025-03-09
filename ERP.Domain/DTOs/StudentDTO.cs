namespace ERP.Domain.DTOs;

public class StudentDTO
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string? Email { get; set; }

    public string? Dob { get; set; }
    public string? EnrollmentDate { get; set; }
    public List<string> Class { get; set; } = new();
}
