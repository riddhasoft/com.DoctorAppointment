using com.DoctorAppointment.Data;
using com.DoctorAppointment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace com.DoctorAppointment.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppDbContext _context;

        public DoctorsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: DoctorsController
        public ActionResult Index()
        {

            return View(_context.Doctor.Include(x=>x.Hospital));
        }

        // GET: DoctorsController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Doctor.Include(x=>x.Hospital).Where(x=>x.Id==id).FirstOrDefault());
        }

        // GET: DoctorsController/Create
        public ActionResult Create()
        {
            ViewBag.Hospitals = new SelectList(_context.Hospital, "Id", "Name");
            return View();
        }

        // POST: DoctorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Doctor model)
        {
            try
            {
                ViewBag.Hospitals = new SelectList(_context.Hospital, "Id", "Name");

                _context.Doctor.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Doctor.Find(id));
        }

        // POST: DoctorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Doctor model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Doctor.Update(model); _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorsController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_context.Doctor.Find(id)); 
        }

        // POST: DoctorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
