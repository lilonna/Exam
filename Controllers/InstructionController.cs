using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    public class InstructionController : Controller
    {
        private readonly ExamContext _context;

        public InstructionController(ExamContext context)
        {
            _context = context;
        }

        public IActionResult Index(int assessmentId)
        {
            var assessment = _context.Assessments
                .Include(a => a.Course)
                .Include(a => a.Instructions)
                .FirstOrDefault(a => a.Id == assessmentId);

            if (assessment == null) return NotFound();

            return View(assessment);
        }

        [HttpGet]
        public IActionResult Create(int assessmentId)
        {
            ViewBag.AssessmentId = assessmentId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Instruction model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.IsActive = true;
            model.IsDeleted = false;
            //model.CreatedAt = DateTime.Now;
            //model.UpdatedAt = DateTime.Now;

            _context.Instructions.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { assessmentId = model.AssessmentId });
        }
    }
}
