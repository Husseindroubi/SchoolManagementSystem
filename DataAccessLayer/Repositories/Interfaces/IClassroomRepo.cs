﻿using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IClassroomRepo : IRepository<Classroom>
    {
        void Update(Classroom classroom);
    }
}