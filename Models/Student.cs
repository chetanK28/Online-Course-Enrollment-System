using System.ComponentModel.DataAnnotations;

namespace Online_Course_Enrollment_System.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public string ContactNumber { get; set; }

        public Student() { }

        public Student(string name, string email, string contactNumber)
        {
            Name = name;
            Email = email;
            ContactNumber = contactNumber;
        }

        public Student(int studentId, string name, string email, string contactNumber)
        {
            StudentId = studentId;
            Name = name;
            Email = email;
            ContactNumber = contactNumber;
        }
    }
}
