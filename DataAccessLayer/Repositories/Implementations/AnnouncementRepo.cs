﻿
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
    public class AnnouncementRepo : Repository<Announcement>, IAnnouncementRepo
    {
        private ApplicationDbContext _context;
        public AnnouncementRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Announcement announcement)
        {
            _context.Announcements.Update(announcement);
        }
    }
}
