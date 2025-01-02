using Microsoft.AspNetCore.Mvc;
using Online_Course_Enrollment_System.Models;
using Online_Course_Enrollment_System.Services;
using System.Collections.Generic;

namespace Online_Course_Enrollment_System.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        public IActionResult Index()
        {
            // Ensure the model is initialized
            var enrollments = _enrollmentService.GetAllEnrollments() ?? new List<Enrollment>();
            return View(enrollments);
        }

        public IActionResult AddEnrollment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEnrollment(int studentId, int courseId)
        {
            if (ModelState.IsValid)
            {
                var enrollment = new Enrollment
                {
                    StudentId = studentId,
                    CourseId = courseId
                };
                _enrollmentService.AddEnrollment(enrollment);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult DeleteEnrollment(int id)
        {
            _enrollmentService.DeleteEnrollment(id);
            return RedirectToAction("Index");
        }
    }
}
