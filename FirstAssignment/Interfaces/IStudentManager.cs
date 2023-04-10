using FirstAssignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment.Interfaces
{
    public interface IStudentManager
    {
        List<Student> Students { get; }
        void AddStudent(string name);
        void RemoveStudent(int studentId);
        void FindStudentById(int studentId);
        void FindStudentByName(string name);
        void ListStudents();
    }
}
