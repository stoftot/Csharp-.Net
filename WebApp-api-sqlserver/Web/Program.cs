using Web.Components;
using Web.DataAccess.Repositories;
using Web.Service.Repository.Interfaces;
using Web.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Load environment-specific appsettings.json, into the program configuration
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//repository's
builder.Services.AddHttpClient<IClassroomRepository, ClassroomRepository>();
builder.Services.AddHttpClient<ICourseRepository, CourseRepository>();
builder.Services.AddHttpClient<ISubjectRepository, SubjectRepository>();
builder.Services.AddHttpClient<ITeacherRepository, TeacherRepository>();

//services
builder.Services.AddScoped<IClassRoomService, ClassroomService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();