using FirstAssignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment.Interfaces
{
    internal interface ISchoolClassManager
    {
        void AddClass(string name, int teacherId);
        void AddStudentToClass(int studentId, int classId);
        public void RemoveStudentFromClass(int studentId, int classId);
        void ListStudentsInClass(SchoolClass schoolClass);
        public void ListSchoolClasses();
        SchoolClass GetClassById(int classIdForList);
        public void RemoveClass(int classId);
    }
}
