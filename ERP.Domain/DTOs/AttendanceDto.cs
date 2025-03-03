namespace ERP.Application.DTOs
{
    public class AttendanceDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string? Date { get; set; }
        public string Status { get; set; } = "Present";
    }
}