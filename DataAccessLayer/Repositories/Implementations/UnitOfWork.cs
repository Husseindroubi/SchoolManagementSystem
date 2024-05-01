using DataAccessLayer.Data;
using DataAccessLayer.Repositories.Interfaces;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IAnnouncementRepo Announcement { get; private set; }
        public IStudentAttendanceRepo StudentAttendance { get; private set; }
        public ICertificateRepo Certificate { get; private set; }
        public IClassroomRepo Classroom { get; private set; }
        public ITopicRepo Topic { get; private set; }
        public IExamRepo Exam { get; private set; }
        public IExamStudentRepo ExamStudent { get; private set; }
        public IHomeworkRepo Homework { get; private set; }
        public IHomeworkStudentRepo HomeworkStudent { get; private set; }
        public ILibraryBookRepo LibraryBook { get; private set; }
        public IOnlineCourseRepo OnlineCourse { get; private set; }
        public ISubjectRepo Subject { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Announcement = new AnnouncementRepo(context);
            StudentAttendance = new StudentAttendanceRepo(context);
            Certificate = new CertificateRepo(context);
            Classroom = new ClassroomRepo(context);
            Topic = new TopicRepo(context);
            Exam = new ExamRepo(context);
            ExamStudent = new ExamStudentRepo(context);
            Homework = new HomeworkRepo(context);
            HomeworkStudent = new HomeworkStudentRepo(context);
            LibraryBook = new LibraryBookRepo(context);
            OnlineCourse = new OnlineCourseRepo(context);
            Subject = new SubjectRepo(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
