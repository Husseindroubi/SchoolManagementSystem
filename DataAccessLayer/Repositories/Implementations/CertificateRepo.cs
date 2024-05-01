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
    public class CertificateRepo : Repository<Certificate>, ICertificateRepo
    {
        private ApplicationDbContext _context;
        public CertificateRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Certificate certificate)
        {
            _context.Certificates.Update(certificate);
        }

    }
}