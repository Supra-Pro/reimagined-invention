namespace ERP.Domain;

public class Parent
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Relation { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = new();
}