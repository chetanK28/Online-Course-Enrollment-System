using Online_Course_Enrollment_System.Models;
using System.Collections.Generic;

namespace Online_Course_Enrollment_System.Repositories
{
    public interface IEnrollmentRepository
    {
        void AddEnrollment(Enrollment enrollment);
        void DeleteEnrollment(int enrollmentId);
        IEnumerable<Enrollment> GetAllEnrollments();
        IEnumerable<Enrollment> GetEnrollmentsByStudentId(int studentId);
        IEnumerable<Enrollment> GetEnrollmentsByCourseId(int courseId);
    }
}
