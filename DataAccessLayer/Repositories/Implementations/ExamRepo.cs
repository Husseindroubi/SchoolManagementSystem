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
    public class ExamRepo : Repository<Exam>, IExamRepo
    {
        private ApplicationDbContext _context;
        public ExamRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Exam exam)
        {
            _context.Exams.Update(exam);
        }
    }
}
