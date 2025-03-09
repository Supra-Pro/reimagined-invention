namespace ERP.Domain.DTOs
{
    public class EnrollmentResponseDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string? EnrollDate { get; set; }
        public string Status { get; set; }
    }
}