using Microsoft.EntityFrameworkCore;
using Task1MVC.Models;

namespace Task1MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog =Task1MVChosPital;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }

    }
}
