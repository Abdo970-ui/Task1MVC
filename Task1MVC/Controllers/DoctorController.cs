using Microsoft.AspNetCore.Mvc;
using Task1MVC.Data;

namespace Task1MVC.Controllers
{
    public class DoctorController : Controller
    {
      public ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index(string searchName, string specialization, int page = 1)
        {
            int pageSize = 4;

            var doctors = _context.Doctors.AsQueryable();

            
            if (!string.IsNullOrEmpty(searchName))
                doctors = doctors.Where(d => d.Name.Contains(searchName));

           
            if (!string.IsNullOrEmpty(specialization))
                doctors = doctors.Where(d => d.Specialization.Contains(specialization));

            var totalDoctors = doctors.Count();

            var result = doctors
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalDoctors / (double)pageSize);

            return View(result);
        }
    }
}
