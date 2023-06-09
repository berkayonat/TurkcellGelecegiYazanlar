﻿using FirstAssignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment.Interfaces
{
    public interface ITeacherManager
    {
        List<Teacher> Teachers { get; }
        void AddTeacher(string name);
        void RemoveTeacher(int teacherId);
        void ListTeachers();
    }
}
