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
    public class TopicRepo : Repository<Topic>, ITopicRepo
    {
        private ApplicationDbContext _context;
        public TopicRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Topic Topic)
        {
            _context.Topics.Update(Topic);
        }

    }
}
