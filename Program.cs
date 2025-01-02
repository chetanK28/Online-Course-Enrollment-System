using Online_Course_Enrollment_System.Repositories;
using Online_Course_Enrollment_System.Repository;
using Online_Course_Enrollment_System.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICourseRepository,CourseRepository>(provider =>
    new CourseRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICourseService, CourseService>();


builder.Services.AddScoped<IStudentRepository, StudentRepository>(provider =>
    new StudentRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IStudentService, StudentService>();



builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>(provider =>
    new EnrollmentRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
