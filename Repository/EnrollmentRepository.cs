using MySql.Data.MySqlClient;
using Online_Course_Enrollment_System.Models;
using System.Collections.Generic;

namespace Online_Course_Enrollment_System.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly string connectionString;

        public EnrollmentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var command = new MySqlCommand("INSERT INTO Enrollment (StudentId, CourseId) VALUES (@StudentId, @CourseId)", connection);
                command.Parameters.AddWithValue("@StudentId", enrollment.StudentId);
                command.Parameters.AddWithValue("@CourseId", enrollment.CourseId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEnrollment(int enrollmentId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var command = new MySqlCommand("DELETE FROM Enrollment WHERE EnrollmentId = @EnrollmentId", connection);
                command.Parameters.AddWithValue("@EnrollmentId", enrollmentId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Enrollment> GetAllEnrollments()
        {
            var enrollments = new List<Enrollment>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var command = new MySqlCommand("SELECT * FROM Enrollment", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        enrollments.Add(new Enrollment
                        {
                            EnrollmentId = reader.GetInt32("EnrollmentId"),
                            StudentId = reader.GetInt32("StudentId"),
                            CourseId = reader.GetInt32("CourseId")
                        });
                    }
                }
            }
            return enrollments;
        }

        public IEnumerable<Enrollment> GetEnrollmentsByStudentId(int studentId)
        {
            var enrollments = new List<Enrollment>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var command = new MySqlCommand("SELECT * FROM Enrollment WHERE StudentId = @StudentId", connection);
                command.Parameters.AddWithValue("@StudentId", studentId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        enrollments.Add(new Enrollment
                        {
                            EnrollmentId = reader.GetInt32("EnrollmentId"),
                            StudentId = reader.GetInt32("StudentId"),
                            CourseId = reader.GetInt32("CourseId")
                        });
                    }
                }
            }
            return enrollments;
        }

        public IEnumerable<Enrollment> GetEnrollmentsByCourseId(int courseId)
        {
            var enrollments = new List<Enrollment>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var command = new MySqlCommand("SELECT * FROM Enrollment WHERE CourseId = @CourseId", connection);
                command.Parameters.AddWithValue("@CourseId", courseId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        enrollments.Add(new Enrollment
                        {
                            EnrollmentId = reader.GetInt32("EnrollmentId"),
                            StudentId = reader.GetInt32("StudentId"),
                            CourseId = reader.GetInt32("CourseId")
                        });
                    }
                }
            }
            return enrollments;
        }
    }
}
