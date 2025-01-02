using Microsoft.AspNetCore.Mvc;
using Online_Course_Enrollment_System.Models;
using Online_Course_Enrollment_System.Services;
using System.Collections;

namespace Online_Course_Enrollment_System.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService CourseService;

        public CourseController(ICourseService CourseService)
        {
            this.CourseService = CourseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(string name, string description, int duration, int capacity, int availableSeats)
        {
            Course course = new Course(name, description, duration, capacity, availableSeats);

            if (ModelState.IsValid)
            {
                CourseService.AddCourse(course);
                return RedirectToAction("GetAllCourses");
            }
            return View(course);
        }

        public IActionResult GetAllCourses()
        {
            IEnumerable courses = CourseService.GetAllCourses();
            return View(courses);
        }

        [HttpPost]
        public IActionResult DeleteCourse(int id)
        {
            CourseService.DeleteCourse(id);
            return RedirectToAction("GetAllCourses");
        }

        public IActionResult EditCourse(int id)
        {
            var course = CourseService.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public IActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseService.UpdateCourse(course);
                return RedirectToAction("GetAllCourses");
            }
            return View(course);
        }
    }
}
