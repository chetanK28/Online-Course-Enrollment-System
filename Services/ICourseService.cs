using System.Collections;
using System.Collections.Generic;
using Online_Course_Enrollment_System.Models;

namespace Online_Course_Enrollment_System.Services
{
    public interface ICourseService
    {
        public void AddCourse(Course course);
        public void DeleteCourse(int courseId);
        public void UpdateCourse(Course course);
        public Course GetCourseById(int id);
        public IEnumerable GetAllCourses();
    }
}
