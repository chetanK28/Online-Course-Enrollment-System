using Online_Course_Enrollment_System.Models;
using System.Collections;


namespace Online_Course_Enrollment_System.Repositories
{
    public interface ICourseRepository
    {

        public void AddCourse(Course course);

        public void DeleteCourse(int courseId);

        public void UpdateCourse(Course course);

        public Course GetCourseById(int id);

        public IEnumerable GetAllCourses();

    }
}

