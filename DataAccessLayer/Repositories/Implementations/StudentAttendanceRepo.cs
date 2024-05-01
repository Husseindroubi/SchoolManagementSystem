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
    public class StudentAttendanceRepo : Repository<StudentAttendance>, IStudentAttendanceRepo
    {
        private ApplicationDbContext _context;
        public StudentAttendanceRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(StudentAttendance StudentAttendance)
        {
            _context.StudentAttendances.Update(StudentAttendance);
        }

    }
}
