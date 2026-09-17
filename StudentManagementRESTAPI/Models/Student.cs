namespace StudentManagementRESTAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public int Year { get; set; }
        public string StudentNumber { get; set; } = string.Empty;
    }
}