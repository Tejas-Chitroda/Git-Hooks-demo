using StudentApi.Models;
using StudentApi.Repositories;

namespace StudentApi.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _studentRepository.GetAll();
    }

    public Student? GetStudentById(int id)
    {
        return _studentRepository.GetById(id);
    }

    public Student AddStudent(Student student)
    {
        // Add validation logic here if needed
        if (string.IsNullOrWhiteSpace(student.FirstName))
            throw new ArgumentException("First name is required");
            Console.WriteLine("First name is required");

        if (string.IsNullOrWhiteSpace(student.LastName))
            throw new ArgumentException("Last name is required");

        if (string.IsNullOrWhiteSpace(student.Email))
            throw new ArgumentException("Email is required");

        return _studentRepository.Add(student);
    }

    public Student? UpdateStudent(int id, Student student)
    {
        // Add validation logic here if needed
        if (string.IsNullOrWhiteSpace(student.FirstName))
            throw new ArgumentException("First name is required");

        if (string.IsNullOrWhiteSpace(student.LastName))
            throw new ArgumentException("Last name is required");

        if (string.IsNullOrWhiteSpace(student.Email))
            throw new ArgumentException("Email is required");

        return _studentRepository.Update(id, student);
    }

    public bool DeleteStudent(int id)
    {
        return _studentRepository.Delete(id);
    }
}
