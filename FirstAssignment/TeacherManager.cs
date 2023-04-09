using FirstAssignment.Entities;
using FirstAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment
{
    public class TeacherManager : ITeacherManager
    {
        private List<Teacher> _teachers;

        public TeacherManager()
        {
            _teachers = new List<Teacher>();
        }

        public List<Teacher> Teachers
        {
            get { return _teachers; }
        }

        public void AddTeacher(string name)
        {
            var teacher = new Teacher { Id = _teachers.Count + 1, Name = name };
            _teachers.Add(teacher);
            Console.WriteLine($"{teacher.Name} has been added with ID: {teacher.Id}");
        }

        public void ListTeachers()
        {
            Console.WriteLine("List of Teachers:");
            foreach (var teacher in _teachers)
            {
                string classes = teacher.Classes != null ? string.Join(", ", teacher.Classes.Select(c => c.Name)) : "N/A";
                Console.WriteLine($"{teacher.Id} - {teacher.Name} Classes: {classes}");
            }
        }

        public void RemoveTeacher(int teacherId)
        {
            var teacher = _teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacher == null)
            {
                Console.WriteLine($"Teacher with ID {teacherId} could not be found.");
                return;
            }

            if (teacher.Classes != null)
            {
                foreach (var cls in teacher.Classes)
                {
                    cls.Teacher = null;
                }
            }

            _teachers.Remove(teacher);
            Console.WriteLine($"{teacher.Name} has been removed.");
        }
    }
}
