using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IAnnouncementRepo : IRepository<Announcement>
    {
        void Update(Announcement announcement);
    }
}
