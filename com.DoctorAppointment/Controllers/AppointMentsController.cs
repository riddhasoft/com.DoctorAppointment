using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using com.DoctorAppointment.Data;
using com.DoctorAppointment.Models;

namespace com.DoctorAppointment.Controllers
{
    public class AppointMentsController : Controller
    {
        private readonly AppDbContext _context;

        public AppointMentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AppointMents
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AppointMent.Include(a => a.Doctor).ThenInclude(x => x.Hospital);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AppointMents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AppointMent == null)
            {
                return NotFound();
            }

            var appointMent = await _context.AppointMent
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointMent == null)
            {
                return NotFound();
            }

            return View(appointMent);
        }

        // GET: AppointMents/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name");
            return View();
        }

        // POST: AppointMents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorId,AppointmentDate,Problem,PatientName,PatientContact")] AppointMent appointMent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointMent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name", appointMent.DoctorId);
            return View(appointMent);
        }

        // GET: AppointMents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AppointMent == null)
            {
                return NotFound();
            }

            var appointMent = await _context.AppointMent.FindAsync(id);
            if (appointMent == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name", appointMent.DoctorId);
            return View(appointMent);
        }

        // POST: AppointMents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,AppointmentDate,Problem,PatientName,PatientContact")] AppointMent appointMent)
        {
            if (id != appointMent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointMent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointMentExists(appointMent.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name", appointMent.DoctorId);
            return View(appointMent);
        }

        // GET: AppointMents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AppointMent == null)
            {
                return NotFound();
            }

            var appointMent = await _context.AppointMent
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointMent == null)
            {
                return NotFound();
            }

            return View(appointMent);
        }

        // POST: AppointMents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AppointMent == null)
            {
                return Problem("Entity set 'AppDbContext.AppointMent'  is null.");
            }
            var appointMent = await _context.AppointMent.FindAsync(id);
            if (appointMent != null)
            {
                _context.AppointMent.Remove(appointMent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointMentExists(int id)
        {
            return (_context.AppointMent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
