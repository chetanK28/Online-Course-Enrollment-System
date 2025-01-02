using System.Collections;
using Online_Course_Enrollment_System.Models;

namespace Online_Course_Enrollment_System.Services
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
        Student GetStudentById(int id);
        IEnumerable GetAllStudents();
    }
}
