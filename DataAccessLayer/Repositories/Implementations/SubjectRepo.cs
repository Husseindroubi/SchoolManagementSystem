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
    public class SubjectRepo : Repository<Subject>, ISubjectRepo
    {
        private ApplicationDbContext _context;
        public SubjectRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Subject subject)
        {
            _context.Subjects.Update(subject);
        }
    }
}
