using Online_Course_Enrollment_System.Models;
using System.Collections.Generic;

namespace Online_Course_Enrollment_System.Services
{
    public interface IEnrollmentService
    {
        void AddEnrollment(Enrollment enrollment);
        void DeleteEnrollment(int enrollmentId);
        IEnumerable<Enrollment> GetAllEnrollments();
    }
}
