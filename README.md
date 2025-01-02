
# **Online Course Enrollment System**

An ASP.NET Core MVC-based web application for managing courses, students, and enrollments. The system allows administrators to manage course data, student information, and student-course enrollments efficiently.

## **Features**

### **Course Management**
- Add new courses.
- View a list of all courses.
- Update course details.
- Delete courses.

### **Student Management**
- Add new students.
- View a list of all students.
- Update student details.
- Delete student records.

### **Enrollment Management**
- Enroll students into courses.
- View all enrollments.
- Remove enrollments.

---

## **Technologies Used**
- **Frontend**: Razor Views, Bootstrap 5 for responsive UI.
- **Backend**: ASP.NET Core MVC.
- **Database**: MySQL for data storage.
- **ORM**: ADO.NET for database interaction.
- **Language**: C#.

---

## **Getting Started**

### **Prerequisites**
1. Install [.NET SDK](https://dotnet.microsoft.com/download).
2. Install [MySQL](https://www.mysql.com/downloads/).
3. Install an IDE such as [Visual Studio](https://visualstudio.microsoft.com/).

### **Setup Instructions**
1. **Clone the Repository**:
   ```bash
   git clone  https://github.com/chetanK28/-Online-Course-Enrollment-System.git
   cd OnlineCourseEnrollmentSystem
   ```

2. **Database Setup**:
   - Create a MySQL database:
     ```sql
     CREATE DATABASE onlinecourseenrollment;
     ```
   - Create required tables:
     ```sql
     CREATE TABLE Course (
         CourseId INT PRIMARY KEY AUTO_INCREMENT,
         Name VARCHAR(100) NOT NULL,
         Description TEXT,
         Duration INT NOT NULL,
         Capacity INT NOT NULL,
         AvailableSeats INT NOT NULL
     );

     CREATE TABLE Student (
         StudentId INT PRIMARY KEY AUTO_INCREMENT,
         Name VARCHAR(100) NOT NULL,
         Email VARCHAR(100) NOT NULL UNIQUE,
         ContactNumber VARCHAR(15) NOT NULL
     );

     CREATE TABLE Enrollment (
         EnrollmentId INT PRIMARY KEY AUTO_INCREMENT,
         StudentId INT NOT NULL,
         CourseId INT NOT NULL,
         FOREIGN KEY (StudentId) REFERENCES Student(StudentId) ON DELETE CASCADE,
         FOREIGN KEY (CourseId) REFERENCES Course(CourseId) ON DELETE CASCADE
     );
     ```

3. **Configure Connection String**:
   - Update the `appsettings.json` file with your MySQL connection string:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "server=localhost;database=onlinecourseenrollment;user=root;password=yourpassword;"
       }
     }
     ```

4. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```

5. **Run the Application**:
   ```bash
   dotnet run
   ```

6. **Access the Application**:
   Open your browser and navigate to `http://localhost:5000`.

---

## **Project Structure**
- **Controllers**:
  - `CourseController`: Handles course-related operations.
  - `StudentController`: Handles student-related operations.
  - `EnrollmentController`: Manages enrollments.

- **Models**:
  - `Course`: Represents course data.
  - `Student`: Represents student data.
  - `Enrollment`: Represents student-course relationships.

- **Views**:
  - Razor views for Courses, Students, and Enrollments.
  - Bootstrap for responsive design.

- **Repositories**:
  - Data access layer for interaction with MySQL.

- **Services**:
  - Business logic layer for course, student, and enrollment operations.

---

## **Usage**
1. **Manage Courses**:
   - Navigate to `/Course`.
   - Add, view, edit, or delete courses.

2. **Manage Students**:
   - Navigate to `/Student`.
   - Add, view, edit, or delete students.

3. **Manage Enrollments**:
   - Navigate to `/Enrollment`.
   - Add new enrollments by selecting a student and course.
   - View all enrollments.
   - Delete enrollments.

---

## **Screenshots**
### **Dashboard**
![Dashboard](https://via.placeholder.com/800x400.png?text=Screenshot+Dashboard)

### **Course Management**
![Course Management](https://via.placeholder.com/800x400.png?text=Screenshot+Course+Management)

### **Student Management**
![Student Management](https://via.placeholder.com/800x400.png?text=Screenshot+Student+Management)

### **Enrollment Management**
![Enrollment Management](https://via.placeholder.com/800x400.png?text=Screenshot+Enrollment+Management)

---

## **Future Enhancements**
- Add authentication for different user roles (e.g., admin, student).
- Implement search and filter functionality for courses and students.
- Integrate email notifications for successful enrollments.
- Enhance UI with custom themes and animations.

---

## **Contributing**
1. Fork the repository.
2. Create a new feature branch:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add feature description"
   ```
4. Push to your branch:
   ```bash
   git push origin feature-name
   ```
5. Create a pull request.

---
