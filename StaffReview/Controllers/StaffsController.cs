using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaffReview.Models;

namespace StaffReview.Controllers
{
    public class StaffsController : Controller
    {
        private readonly StaffReviewContext _context;

        public StaffsController(StaffReviewContext context)
        {
            _context = context;    
        }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string JobTitle, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> ratingQuery = from m in _context.Staff
                                            orderby m.JobTitle
                                            select m.JobTitle;

            var staffs = from m in _context.Staff
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                staffs = staffs.Where(s => s.FirstName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(JobTitle))
            {
                staffs = staffs.Where(x => x.JobTitle == JobTitle);
            }

            var JobTitleVM = new JobTitleViewModel();
            JobTitleVM.JobTitles = new SelectList(await ratingQuery.Distinct().ToListAsync());
            JobTitleVM.staffs = await staffs.ToListAsync();

            return View(JobTitleVM);
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .SingleOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,JobTitle,Rating,Review")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.SingleOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,JobTitle,Rating,Review")] Staff staff)
        {
            if (id != staff.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .SingleOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staff.SingleOrDefaultAsync(m => m.ID == id);
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.ID == id);
        }
    }
}
