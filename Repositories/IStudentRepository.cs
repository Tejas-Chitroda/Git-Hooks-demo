using StudentApi.Models;

namespace StudentApi.Repositories;

public interface IStudentRepository
{
    IEnumerable<Student> GetAll();
    Student? GetById(int id);
    Student Add(Student student);
    Student? Update(int id, Student student);
    bool Delete(int id);
}
