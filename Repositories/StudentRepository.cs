using StudentApi.Models;

namespace StudentApi.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly List<Student> _students = new();
    private int _nextId = 1;

    public StudentRepository()
    {
        // Seed with some initial data
        _students.Add(new Student
        {
            Id = _nextId++,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            DateOfBirth = new DateTime(2000, 1, 15),
            PhoneNumber = "123-456-7890",
            Address = "123 Main St, City, State"
        });

        _students.Add(new Student
        {
            Id = _nextId++,
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane.smith@example.com",
            DateOfBirth = new DateTime(1999, 5, 20),
            PhoneNumber = "098-765-4321",
            Address = "456 Oak Ave, City, State"
        });

        _students.Add(new Student
        {
            Id = _nextId++,
            FirstName = "Bob",
            LastName = "Johnson",
            Email = "bob.johnson@example.com",
            DateOfBirth = new DateTime(2001, 8, 10),
            PhoneNumber = "555-123-4567",
            Address = "789 Pine Rd, City, State"
        });
    }

    public IEnumerable<Student> GetAll()
    {
        return _students.ToList();
    }

    public Student? GetById(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

    public Student Add(Student student)
    {
        student.Id = _nextId++;
        _students.Add(student);
        return student;
    }

    public Student? Update(int id, Student student)
    {
        var existingStudent = _students.FirstOrDefault(s => s.Id == id);
        if (existingStudent == null)
            return null;

        existingStudent.FirstName = student.FirstName;
        existingStudent.LastName = student.LastName;
        existingStudent.Email = student.Email;
        existingStudent.DateOfBirth = student.DateOfBirth;
        existingStudent.PhoneNumber = student.PhoneNumber;
        existingStudent.Address = student.Address;

        return existingStudent;
    }

    public bool Delete(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
            return false;

        _students.Remove(student);
        return true;
    }
}
