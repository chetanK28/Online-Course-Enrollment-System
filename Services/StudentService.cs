using Online_Course_Enrollment_System.Models;
using Online_Course_Enrollment_System.Repositories;
using System.Collections;

namespace Online_Course_Enrollment_System.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void AddStudent(Student student)
        {
            studentRepository.AddStudent(student);
        }

        public void DeleteStudent(int studentId)
        {
            studentRepository.DeleteStudent(studentId);
        }

        public IEnumerable GetAllStudents()
        {
            return studentRepository.GetAllStudents();
        }

        public Student GetStudentById(int id)
        {
            return studentRepository.GetStudentById(id);
        }

        public void UpdateStudent(Student student)
        {
            studentRepository.UpdateStudent(student);
        }
    }
}
