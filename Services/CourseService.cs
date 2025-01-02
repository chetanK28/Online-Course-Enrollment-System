using Online_Course_Enrollment_System.Models;
using Online_Course_Enrollment_System.Repositories;
using Online_Course_Enrollment_System.Services;
using System.Collections;
using System.Collections.Generic;

namespace Online_Course_Enrollment_System.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public void AddCourse(Course course)
        {
            courseRepository.AddCourse(course);
        }

        public void DeleteCourse(int courseId)
        {
            courseRepository.DeleteCourse(courseId);
        }

        public IEnumerable GetAllCourses()
        {
            return courseRepository.GetAllCourses();
        }

        public Course GetCourseById(int id)
        {
            return courseRepository.GetCourseById(id);
        }

        public void UpdateCourse(Course course)
        {
            courseRepository.UpdateCourse(course);
        }
    }
}
