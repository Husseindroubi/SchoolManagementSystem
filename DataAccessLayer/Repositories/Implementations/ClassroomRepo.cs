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
    public class ClassroomRepo : Repository<Classroom>, IClassroomRepo
    {
        private ApplicationDbContext _context;
        public ClassroomRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Classroom classroom)
        {
            _context.Classrooms.Update(classroom);
        }
    }
}
