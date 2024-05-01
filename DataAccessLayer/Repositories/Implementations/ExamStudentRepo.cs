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
    public class ExamStudentRepo : Repository<ExamStudent>, IExamStudentRepo
    {
        private ApplicationDbContext _context;
        public ExamStudentRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(ExamStudent examStudent)
        {
            _context.ExamsStudents.Update(examStudent);
        }
    }
}
