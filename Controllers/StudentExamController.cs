using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    public class StudentExamController : Controller
    {
        private readonly ExamContext _context;

        public StudentExamController(ExamContext context)
        {
            _context = context;
        }
        public IActionResult Available()
        {
            int studentId = GetCurrentStudentId();

            
            var courseIds = _context.CourseRegistrations
                .Where(r => r.StudentId == studentId)
                .Select(r => r.CourseAllocation.CourseId)
                .Distinct()
                .ToList();

          
            var exams = _context.Assessments
                .Where(a => courseIds.Contains(a.CourseId)
                    && a.IsActive
                    && !a.IsDeleted
                    && DateTime.Now >= a.StartDate
                    && DateTime.Now <= a.EndDate)
                .Include(a => a.Course)
                .Include(a => a.AssessmentType)
                .ToList();

            return View(exams);
        }


        private int GetCurrentStudentId()
        {
            return _context.Students
                .Where(s => s.User.Email == User.Identity.Name)
                .Select(s => s.Id)
                .FirstOrDefault();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
