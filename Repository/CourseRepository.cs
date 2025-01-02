using MySql.Data.MySqlClient;
using Online_Course_Enrollment_System.Models;
using Online_Course_Enrollment_System.Repositories;
using System.Collections;
using System.Collections.Generic;

namespace Online_Course_Enrollment_System.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly string connectionString;

        public CourseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddCourse(Course course)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("INSERT INTO Course (Name, Description, Duration, Capacity, AvailableSeats) VALUES (@name, @description, @duration, @capacity, @availableSeats)", connection);
                    command.Parameters.AddWithValue("@name", course.Name);
                    command.Parameters.AddWithValue("@description", course.Description);
                    command.Parameters.AddWithValue("@duration", course.Duration);
                    command.Parameters.AddWithValue("@capacity", course.Capacity);
                    command.Parameters.AddWithValue("@availableSeats", course.AvailableSeats);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeleteCourse(int courseId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("DELETE FROM Course WHERE CourseId = @courseId", connection);
                    command.Parameters.AddWithValue("@courseId", courseId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("SELECT * FROM Course", connection);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Course course = new Course
                            {
                                CourseId = reader.GetInt32("CourseId"),
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description"),
                                Duration = reader.GetInt32("Duration"),
                                Capacity = reader.GetInt32("Capacity"),
                                AvailableSeats = reader.GetInt32("AvailableSeats")
                            };
                            courses.Add(course);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
            return courses;
        }

        public Course GetCourseById(int id)
        {
            Course course = null;
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("SELECT * FROM Course WHERE CourseId = @courseId", connection);
                    command.Parameters.AddWithValue("@courseId", id);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            course = new Course
                            {
                                CourseId = reader.GetInt32("CourseId"),
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description"),
                                Duration = reader.GetInt32("Duration"),
                                Capacity = reader.GetInt32("Capacity"),
                                AvailableSeats = reader.GetInt32("AvailableSeats")
                            };
                        }
                    }
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
            return course;
        }

        public void UpdateCourse(Course course)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("UPDATE Course SET Name = @name, Description = @description, Duration = @duration, Capacity = @capacity, AvailableSeats = @availableSeats WHERE CourseId = @courseId", connection);
                    command.Parameters.AddWithValue("@name", course.Name);
                    command.Parameters.AddWithValue("@description", course.Description);
                    command.Parameters.AddWithValue("@duration", course.Duration);
                    command.Parameters.AddWithValue("@capacity", course.Capacity);
                    command.Parameters.AddWithValue("@availableSeats", course.AvailableSeats);
                    command.Parameters.AddWithValue("@courseId", course.CourseId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
