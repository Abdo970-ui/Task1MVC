using Microsoft.AspNetCore.Mvc;
using Task1MVC.Data;
using Task1MVC.Models;

namespace Task1MVC.Controllers
{
    public class AppointmentController : Controller
    {
        public ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Create(int doctorId)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == doctorId);
            if (doctor == null)
                return NotFound();

            ViewBag.Doctor = doctor;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var appointments = _context.Appointments
                .Select(a => new
                {
                    a.PatientName,
                    a.Date,
                    a.Time,
                    DoctorName = a.Doctor.Name,
                    Specialization = a.Doctor.Specialization
                })
                .ToList();

            return View(appointments);
        }
    }
}
