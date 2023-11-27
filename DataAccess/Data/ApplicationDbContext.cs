﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public partial class ApplicationDbContext : DbContext
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
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<StudentLocation> StudentLocations { get; set; }
        public DbSet<TutorCategory> TutorCategories { get; set; }
        public DbSet<MatchedTuition> MatchedTuitions { get; set; }
        public DbSet<MatchStatusValue> MatchStatusValues { get; set; }
        public DbSet<spGetMatchedTutor> spGetMatchedTutors { get; set; }
        public DbSet<spGetStudentRequestLog> spGetStudentRequestLogs { get; set; }
        public DbSet<spGetMatchedTutorsByFilter> spGetMatchedTutorsByFilters { get; set; }
		public DbSet<spDashboardCount> spDashboardCounts { get; set; }
        public DbSet<spTutorDashboardCount> spTutorDashboardCounts { get; set; }
        public DbSet<spGetTuitionByTutorAndStatus> spGetTuitionsByTutorAndStatus { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
		public DbSet<TutorFeedback> TutorFeedbacks { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<spGetMatchedTutor>().HasNoKey();
            modelBuilder.Entity<spGetMatchedTutorsByFilter>().HasNoKey();
			modelBuilder.Entity<spDashboardCount>().HasNoKey();
            modelBuilder.Entity<spTutorDashboardCount>().HasNoKey();
            modelBuilder.Entity<spGetStudentRequestLog>().HasNoKey();
            modelBuilder.Entity<spGetTuitionByTutorAndStatus>().HasNoKey();
			modelBuilder.Entity<spGetAllFeedback>().HasNoKey();
			OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
