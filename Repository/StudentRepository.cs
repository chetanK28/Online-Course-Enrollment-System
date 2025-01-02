using MySql.Data.MySqlClient;
using Online_Course_Enrollment_System.Models;
using System.Collections;
using System.Collections.Generic;

namespace Online_Course_Enrollment_System.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string connectionString;

        public StudentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddStudent(Student student)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("INSERT INTO Student (Name, Email, ContactNumber) VALUES (@Name, @Email, @ContactNumber)", connection);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@ContactNumber", student.ContactNumber);
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

        public void DeleteStudent(int studentId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("DELETE FROM Student WHERE StudentId = @StudentId", connection);
                    command.Parameters.AddWithValue("@StudentId", studentId);
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

        public IEnumerable GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("SELECT * FROM Student", connection);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = new Student
                            {
                                StudentId = reader.GetInt32("StudentId"),
                                Name = reader.GetString("Name"),
                                Email = reader.GetString("Email"),
                                ContactNumber = reader.GetString("ContactNumber")
                            };
                            students.Add(student);
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
            return students;
        }

        public Student GetStudentById(int id)
        {
            Student student = null;
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("SELECT * FROM Student WHERE StudentId = @StudentId", connection);
                    command.Parameters.AddWithValue("@StudentId", id);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = new Student
                            {
                                StudentId = reader.GetInt32("StudentId"),
                                Name = reader.GetString("Name"),
                                Email = reader.GetString("Email"),
                                ContactNumber = reader.GetString("ContactNumber")
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
            return student;
        }

        public void UpdateStudent(Student student)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("UPDATE Student SET Name = @Name, Email = @Email, ContactNumber = @ContactNumber WHERE StudentId = @StudentId", connection);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@ContactNumber", student.ContactNumber);
                    command.Parameters.AddWithValue("@StudentId", student.StudentId);
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
