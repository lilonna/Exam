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
    public class AcademicProgramsController : Controller
    {
        private readonly ExamContext _context;

        public AcademicProgramsController(ExamContext context)
        {
            _context = context;
        }

        // GET: AcademicPrograms
        public async Task<IActionResult> Index()
        {
            return View(await _context.AcademicPrograms.ToListAsync());
        }

        // GET: AcademicPrograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicProgram = await _context.AcademicPrograms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicProgram == null)
            {
                return NotFound();
            }

            return View(academicProgram);
        }

        // GET: AcademicPrograms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademicPrograms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AcademicProgramGuid,Title,Program,IsActive,IsDeleted")] AcademicProgram academicProgram)
        {
            Console.WriteLine("POST /Courses/Create was called");
            if (ModelState.IsValid)
            {
                _context.Add(academicProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicProgram);
        }

        // GET: AcademicPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicProgram = await _context.AcademicPrograms.FindAsync(id);
            if (academicProgram == null)
            {
                return NotFound();
            }
            return View(academicProgram);
        }

        // POST: AcademicPrograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AcademicProgramGuid,Title,Program,IsActive,IsDeleted")] AcademicProgram academicProgram)
        {
            if (id != academicProgram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicProgramExists(academicProgram.Id))
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
            return View(academicProgram);
        }

        // GET: AcademicPrograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicProgram = await _context.AcademicPrograms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicProgram == null)
            {
                return NotFound();
            }

            return View(academicProgram);
        }

        // POST: AcademicPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicProgram = await _context.AcademicPrograms.FindAsync(id);
            if (academicProgram != null)
            {
                _context.AcademicPrograms.Remove(academicProgram);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicProgramExists(int id)
        {
            return _context.AcademicPrograms.Any(e => e.Id == id);
        }
    }
}
