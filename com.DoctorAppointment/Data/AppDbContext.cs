using com.DoctorAppointment.Models;
using Microsoft.EntityFrameworkCore;

namespace com.DoctorAppointment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<AppointMent> AppointMent { get; set; }
    }
}
