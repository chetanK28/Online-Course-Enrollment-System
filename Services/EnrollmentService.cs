using Online_Course_Enrollment_System.Models;
using Online_Course_Enrollment_System.Repositories;
using System.Collections.Generic;

namespace Online_Course_Enrollment_System.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            _enrollmentRepository.AddEnrollment(enrollment);
        }

        public void DeleteEnrollment(int enrollmentId)
        {
            _enrollmentRepository.DeleteEnrollment(enrollmentId);
        }

        public IEnumerable<Enrollment> GetAllEnrollments()
        {
            return _enrollmentRepository.GetAllEnrollments() ?? new List<Enrollment>();
        }
    }
}
