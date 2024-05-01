using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface ICertificateRepo : IRepository<Certificate>
    {
        void Update(Certificate certificate);
    }
}