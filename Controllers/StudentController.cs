using Microsoft.AspNetCore.Mvc;
using Online_Course_Enrollment_System.Models;
using Online_Course_Enrollment_System.Services;
using System.Collections;

namespace Online_Course_Enrollment_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService StudentService;

        public StudentController(IStudentService studentService)
        {
            StudentService = studentService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetAllStudents");
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(string name, string email, string contactNumber)
        {
            Student student = new Student(name, email, contactNumber);

            if (ModelState.IsValid)
            {
                StudentService.AddStudent(student);
                return RedirectToAction("GetAllStudents");
            }
            return View(student);
        }

        public IActionResult GetAllStudents()
        {
            IEnumerable students = StudentService.GetAllStudents();
            return View(students);
        }

        [HttpPost]
        public IActionResult DeleteStudent(int id)
        {
            StudentService.DeleteStudent(id);
            return RedirectToAction("GetAllStudents");
        }

        public IActionResult EditStudent(int id)
        {
            var student = StudentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentService.UpdateStudent(student);
                return RedirectToAction("GetAllStudents");
            }
            return View(student);
        }
    }
}
