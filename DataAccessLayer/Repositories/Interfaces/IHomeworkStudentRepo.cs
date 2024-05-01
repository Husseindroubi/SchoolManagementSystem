﻿using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IHomeworkStudentRepo : IRepository<HomeworkStudent>
    {
        void Update(HomeworkStudent homeworkStudent);
    }
}