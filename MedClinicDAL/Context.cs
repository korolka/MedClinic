using MedClinicDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedClinicDAL
{
    public class Context : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
		public DbSet<Roles> Roles { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MedClinicDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
       
    }
}