using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set;}
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<TutorSubject> TutorSubjects { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OtherLocation> OtherLocations { get; set; }
        public DbSet<TutorLocation> TutorLocations { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<TutorQualification> TutorQualifications { get; set; }
    }
}
