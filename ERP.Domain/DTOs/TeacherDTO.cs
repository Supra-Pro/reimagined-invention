namespace ERP.Domain.DTOs;

public class TeacherDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<string> Courses { get; set; }  
}
