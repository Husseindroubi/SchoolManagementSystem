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
    public class LibraryBookRepo : Repository<LibraryBook>, ILibraryBookRepo
    {
        private ApplicationDbContext _context;
        public LibraryBookRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(LibraryBook libraryBook)
        {
            _context.LibraryBooks.Update(libraryBook);
        }
    }
}
