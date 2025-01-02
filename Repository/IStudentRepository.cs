using Online_Course_Enrollment_System.Models;
using System.Collections;

namespace Online_Course_Enrollment_System.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
        Student GetStudentById(int id);
        IEnumerable GetAllStudents();
    }
}
