using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelsLayer;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentityUser>(options)
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Topic> Topics { get; set; } 
        public DbSet<DailyPlan> DailyPlans { get; set; }
        public DbSet<WeeklyPlan> WeeklyPlans { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamStudent> ExamsStudents { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<HomeworkStudent> HomeworkStudents { get; set; }
        public DbSet<LibraryBook> LibraryBooks { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }
        public DbSet<StudentClassroom> StudentClassrooms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
