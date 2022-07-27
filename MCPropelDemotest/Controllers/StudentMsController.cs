using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCPropelDemotest.Models;

namespace MCPropelDemotest.Controllers
{
    public class StudentMsController : Controller
    {
        private readonly SMSContext _context;

        public StudentMsController(SMSContext context)
        {
            _context = context;
        }

        // GET: StudentMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentMs.ToListAsync());
        }



        [HttpGet]
        public async Task<IActionResult> Index(string TSearch)
        {
            ViewData["GetStudentDetails"] = TSearch;
            var Tquery = from x in _context.StudentMs select x;
            if (!string.IsNullOrEmpty(TSearch))
            {
                Tquery = Tquery.Where(x => x.EmailId.Contains(TSearch));
            }
            return View(await Tquery.AsNoTracking().ToListAsync());
        }



        // GET: StudentMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentMs = await _context.StudentMs
                .FirstOrDefaultAsync(m => m.Regno == id);
            if (studentMs == null)
            {
                return NotFound();
            }

            return View(studentMs);
        }

        // GET: StudentMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Regno,StudentfullName,CourseJoining,CourseFee,BatchId,Doj,Address,MobileNumber,EmailId")] StudentMs studentMs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentMs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentMs);
        }

        // GET: StudentMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentMs = await _context.StudentMs.FindAsync(id);
            if (studentMs == null)
            {
                return NotFound();
            }
            return View(studentMs);
        }

        // POST: StudentMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Regno,StudentfullName,CourseJoining,CourseFee,BatchId,Doj,Address,MobileNumber,EmailId")] StudentMs studentMs)
        {
            if (id != studentMs.Regno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentMs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentMsExists(studentMs.Regno))
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
            return View(studentMs);
        }

        // GET: StudentMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentMs = await _context.StudentMs
                .FirstOrDefaultAsync(m => m.Regno == id);
            if (studentMs == null)
            {
                return NotFound();
            }

            return View(studentMs);
        }

        // POST: StudentMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentMs = await _context.StudentMs.FindAsync(id);
            _context.StudentMs.Remove(studentMs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentMsExists(int id)
        {
            return _context.StudentMs.Any(e => e.Regno == id);
        }
    }
}
