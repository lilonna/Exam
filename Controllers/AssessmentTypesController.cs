using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exam.Models;

namespace Exam.Controllers
{
    public class AssessmentTypesController : Controller
    {
        private readonly ExamContext _context;

        public AssessmentTypesController(ExamContext context)
        {
            _context = context;
        }

        // GET: AssessmentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssessmentTypes.ToListAsync());
        }

        // GET: AssessmentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentType = await _context.AssessmentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assessmentType == null)
            {
                return NotFound();
            }

            return View(assessmentType);
        }

        // GET: AssessmentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssessmentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsActive,IsDeleted")] AssessmentType assessmentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assessmentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assessmentType);
        }

        // GET: AssessmentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentType = await _context.AssessmentTypes.FindAsync(id);
            if (assessmentType == null)
            {
                return NotFound();
            }
            return View(assessmentType);
        }

        // POST: AssessmentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsActive,IsDeleted")] AssessmentType assessmentType)
        {
            if (id != assessmentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assessmentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentTypeExists(assessmentType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(assessmentType);
        }

        // GET: AssessmentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentType = await _context.AssessmentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assessmentType == null)
            {
                return NotFound();
            }

            return View(assessmentType);
        }

        // POST: AssessmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assessmentType = await _context.AssessmentTypes.FindAsync(id);
            if (assessmentType != null)
            {
                _context.AssessmentTypes.Remove(assessmentType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssessmentTypeExists(int id)
        {
            return _context.AssessmentTypes.Any(e => e.Id == id);
        }
    }
}
