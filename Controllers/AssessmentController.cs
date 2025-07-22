using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exam.Controllers
{
    public class AssessmentController : Controller
    {
        private readonly ExamContext _context;

        public AssessmentController(ExamContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = new SelectList(_context.Courses, "Id", "Name");
            ViewBag.AssessmentTypes = new SelectList(_context.AssessmentTypes, "Id", "Name");
            ViewBag.Sections = new SelectList(_context.Sections, "Id", "Title");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Assessment model, int Duration)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.DurationMinutes = DateTime.Today.AddMinutes(Duration);
            //model.CreatedAt = DateTime.Now;
           /* model.CreatedBy = GetCurrentUserId();*/ // Implement this method based on logged-in user
            model.IsActive = true;
            model.IsDeleted = false;

            _context.Assessments.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index"); // or redirect to add questions
        }


    }
}
