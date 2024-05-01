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
    public class HomeworkStudentRepo : Repository<HomeworkStudent>, IHomeworkStudentRepo
    {
        private ApplicationDbContext _context;
        public HomeworkStudentRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(HomeworkStudent homeworkStudent)
        {
            _context.HomeworkStudents.Update(homeworkStudent);
        }
    }
}
