using Microsoft.EntityFrameworkCore;
using Exam.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ExamContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExamConnection")).EnableSensitiveDataLogging());

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
