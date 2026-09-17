using Microsoft.AspNetCore.Mvc;
using StudentManagementRESTAPI.Models;


namespace StudentManagementRESTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John", Email = "john@example.com" },
            new Student { Id = 2, Name = "Mary", Email = "mary@example.com" }
        };

        private static int nextId = 3;

        [HttpGet]
        public IActionResult GetStudents() => Ok(students);

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            student.Id = nextId++;
            students.Add(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            students.Remove(student);
            return NoContent();
        }
    }
}