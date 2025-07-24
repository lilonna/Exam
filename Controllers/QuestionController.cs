using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    public class QuestionController : Controller
    {


        private readonly ExamContext _context;

        public QuestionController(ExamContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var instructions = _context.Instructions
                .Include(i => i.Assessment)
                .ThenInclude(a => a.Course)
                .ToList();

            return View(instructions);
        }


        [HttpGet]
        public IActionResult Add(int instructionId)
        {
            var instruction = _context.Instructions
                .Include(i => i.Assessment)
                .FirstOrDefault(i => i.Id == instructionId);

            if (instruction == null) return NotFound();

            ViewBag.QuestionTypes = _context.QuestionTypes
                .Where(q => q.IsActive && !q.IsDeleted)
                .ToList();

            var model = new Question
            {
                InstructionId = instructionId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Add(Question question, List<string>? Options, string? CorrectOption)
        {
            if (!ModelState.IsValid)
            {
                return View(question);
            }

            question.CreatedBy = GetCurrentUserId();
            question.CreatedAt = DateTime.Now;
            question.UpdatedAt = DateTime.Now;

            _context.Questions.Add(question);
            _context.SaveChanges();

            // Save Options if MCQ
            if (question.QuestionTypeId == 1 && Options != null) // Assuming 1 = MCQ
            {
                foreach (var opt in Options)
                {
                    var option = new Option
                    {
                        QuestionId = question.Id,
                        Text = opt,
                        IsCorrect = opt == CorrectOption
                    };
                    _context.Options.Add(option);
                }
                _context.SaveChanges();
            }



            return RedirectToAction("ViewQuestions", new { instructionId = question.InstructionId });

        }
        public IActionResult ViewQuestions(int instructionId)
        {
            var questions = _context.Questions
                .Where(q => q.InstructionId == instructionId)
                .Include(q => q.QuestionType)
                .Include(q => q.Options)
                .ToList();

            ViewBag.Instruction = _context.Instructions
                .Include(i => i.Assessment)
                .ThenInclude(a => a.Course)
                .FirstOrDefault(i => i.Id == instructionId);

            return View(questions);
        }

        private int GetCurrentUserId()
        {
            return _context.Users
                .Where(u => u.Email == User.Identity.Name)
                .Select(u => u.Id)
                .FirstOrDefault();
        }
        
    }
}
