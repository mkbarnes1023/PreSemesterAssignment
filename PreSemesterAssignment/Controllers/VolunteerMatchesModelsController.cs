using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PreSemesterAssignment.Data;
using PreSemesterAssignment.Models;

namespace PreSemesterAssignment.Controllers
{
    public class VolunteerMatchesModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolunteerMatchesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VolunteerMatchesModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VolunteerMatches.Include(v => v.Opportunity).Include(v => v.Volunteer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VolunteerMatchesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteerMatchesModel = await _context.VolunteerMatches
                .Include(v => v.Opportunity)
                .Include(v => v.Volunteer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volunteerMatchesModel == null)
            {
                return NotFound();
            }

            return View(volunteerMatchesModel);
        }

        // GET: VolunteerMatchesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VolunteerMatchesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VolunteerID,OppurtunityID")] VolunteerMatchesModel volunteerMatchesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volunteerMatchesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(volunteerMatchesModel);
        }

        // GET: VolunteerMatchesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteerMatchesModel = await _context.VolunteerMatches.FindAsync(id);
            if (volunteerMatchesModel == null)
            {
                return NotFound();
            }
            ViewData["OppurtunityID"] = new SelectList(_context.Opportunities, "OppurtunityID", "OppurtunityID", volunteerMatchesModel.OppurtunityID);
            ViewData["VolunteerID"] = new SelectList(_context.Volunteers, "VolunteerID", "VolunteerID", volunteerMatchesModel.VolunteerID);
            return View(volunteerMatchesModel);
        }

        // POST: VolunteerMatchesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VolunteerID,OppurtunityID")] VolunteerMatchesModel volunteerMatchesModel)
        {
            if (id != volunteerMatchesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volunteerMatchesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolunteerMatchesModelExists(volunteerMatchesModel.Id))
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
            ViewData["OppurtunityID"] = new SelectList(_context.Opportunities, "OppurtunityID", "OppurtunityID", volunteerMatchesModel.OppurtunityID);
            ViewData["VolunteerID"] = new SelectList(_context.Volunteers, "VolunteerID", "VolunteerID", volunteerMatchesModel.VolunteerID);
            return View(volunteerMatchesModel);
        }

        // GET: VolunteerMatchesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteerMatchesModel = await _context.VolunteerMatches
                .Include(v => v.Opportunity)
                .Include(v => v.Volunteer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volunteerMatchesModel == null)
            {
                return NotFound();
            }

            return View(volunteerMatchesModel);
        }

        // POST: VolunteerMatchesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volunteerMatchesModel = await _context.VolunteerMatches.FindAsync(id);
            if (volunteerMatchesModel != null)
            {
                _context.VolunteerMatches.Remove(volunteerMatchesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolunteerMatchesModelExists(int id)
        {
            return _context.VolunteerMatches.Any(e => e.Id == id);
        }
    }
}
