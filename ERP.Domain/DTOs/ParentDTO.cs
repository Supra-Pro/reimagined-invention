namespace ERP.Domain.DTOs;

public class ParentDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public List<StudentDTO> Students { get; set; }
}