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
    public class OnlineCourseRepo : Repository<OnlineCourse>, IOnlineCourseRepo
    {
        private ApplicationDbContext _context;
        public OnlineCourseRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(OnlineCourse onlineCourse)
        {
            _context.OnlineCourses.Update(onlineCourse);
        }
    }
}
