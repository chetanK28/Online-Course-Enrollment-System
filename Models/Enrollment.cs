using System.ComponentModel.DataAnnotations;

namespace Online_Course_Enrollment_System.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        // Navigation properties
        public Student Student { get; set; }
        public Course Course { get; set; }

        public Enrollment() { }

        public Enrollment(int studentId, int courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }

        public Enrollment(int enrollmentId, int studentId, int courseId)
        {
            EnrollmentId = enrollmentId;
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
