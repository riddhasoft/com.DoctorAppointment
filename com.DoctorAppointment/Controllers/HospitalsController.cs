﻿using System;
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
    public class HospitalsController : Controller
    {
        private readonly AppDbContext _context;

        public HospitalsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Hospitals
        public async Task<IActionResult> Index()
        {
              return _context.Hospital != null ? 
                          View(await _context.Hospital.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Hospital'  is null.");
        }

        // GET: Hospitals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }

        // GET: Hospitals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,NameNep,PAN,ContactPerson,ContactNo,Email")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospital);
        }

        // GET: Hospitals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital);
        }

        // POST: Hospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,NameNep,PAN,ContactPerson,ContactNo,Email")] Hospital hospital)
        {
            if (id != hospital.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalExists(hospital.Id))
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
            return View(hospital);
        }

        // GET: Hospitals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hospital == null)
            {
                return Problem("Entity set 'AppDbContext.Hospital'  is null.");
            }
            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital != null)
            {
                _context.Hospital.Remove(hospital);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospitalExists(int id)
        {
          return (_context.Hospital?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
