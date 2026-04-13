using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Services;

namespace StudentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly ILogger<StudentsController> _logger;

    public StudentsController(IStudentService studentService, ILogger<StudentsController> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }

    /// <summary>
    /// Get all students
    /// </summary>
    /// <returns>List of all students</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAllStudents()
    {
        try
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving all students");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get a student by ID
    /// </summary>
    /// <param name="id">Student ID</param>
    /// <returns>Student details</returns>
    [HttpGet("{id}")]
    public ActionResult<Student> GetStudentById(int id)
    {
        try
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
                return NotFound($"Student with ID {id} not found");

            return Ok(student);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving student with ID {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Add a new student
    /// </summary>
    /// <param name="student">Student details</param>
    /// <returns>Created student</returns>
    [HttpPost]
    public ActionResult<Student> AddStudent([FromBody] Student student)
    {
        try
        {
            var createdStudent = _studentService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding student");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Update an existing student
    /// </summary>
    /// <param name="id">Student ID</param>
    /// <param name="student">Updated student details</param>
    /// <returns>Updated student</returns>
    [HttpPut("{id}")]
    public ActionResult<Student> UpdateStudent(int id, [FromBody] Student student)
    {
        try
        {
            var updatedStudent = _studentService.UpdateStudent(id, student);
            if (updatedStudent == null)
                return NotFound($"Student with ID {id} not found");

            return Ok(updatedStudent);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating student with ID {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Delete a student
    /// </summary>
    /// <param name="id">Student ID</param>
    /// <returns>No content</returns>
    [HttpDelete("{id}")]
    public ActionResult DeleteStudent(int id)
    {
        try
        {
            var result = _studentService.DeleteStudent(id);
            if (!result)
                return NotFound($"Student with ID {id} not found");

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting student with ID {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }
}
