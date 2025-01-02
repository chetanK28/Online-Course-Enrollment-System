using System.ComponentModel.DataAnnotations;

namespace Online_Course_Enrollment_System.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; } 

        [Required]
        public int Capacity { get; set; }

        [Required]
        public int AvailableSeats { get; set; }

        public Course() { }

        public Course(string name, string description, int duration, int capacity, int availableSeats)
        {
            Name = name;
            Description = description;
            Duration = duration;
            Capacity = capacity;
            AvailableSeats = availableSeats;
        }

        public Course(int courseId, string name, string description, int duration, int capacity, int availableSeats)
        {
            CourseId = courseId;
            Name = name;
            Description = description;
            Duration = duration;
            Capacity = capacity;
            AvailableSeats = availableSeats;
        }
    }
}
