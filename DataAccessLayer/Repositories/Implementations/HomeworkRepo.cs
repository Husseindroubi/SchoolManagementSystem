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
    public class HomeworkRepo : Repository<Homework>, IHomeworkRepo
    {
        private ApplicationDbContext _context;
        public HomeworkRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Homework homework)
        {
            _context.Homeworks.Update(homework);
        }
    }
}
