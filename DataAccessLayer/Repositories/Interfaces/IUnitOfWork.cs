using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAnnouncementRepo Announcement { get; }
        IStudentAttendanceRepo StudentAttendance { get; }
        ICertificateRepo Certificate { get; }
        IClassroomRepo Classroom { get; }
        ITopicRepo Topic { get; }
        IExamRepo Exam { get; }
        IExamStudentRepo ExamStudent { get; }
        IHomeworkRepo Homework { get; }
        IHomeworkStudentRepo HomeworkStudent { get; }
        ILibraryBookRepo LibraryBook { get; }
        IOnlineCourseRepo OnlineCourse { get; }
        ISubjectRepo Subject { get; }

        void Save();
    }
}
