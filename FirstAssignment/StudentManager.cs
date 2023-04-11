using FirstAssignment.Entities;
using FirstAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment
{
    public class StudentManager : IStudentManager
    {
        private List<Student> _students;
        private int _studentIdCounter;
        public StudentManager()
        {
            _students = new List<Student>();
            _studentIdCounter = 0;
        }
        public List<Student> Students
        {
            get { return _students; }
        }

        public void AddStudent(string name)
        {
            var student = new Student { Id = ++_studentIdCounter, Name = name };
            _students.Add(student);
            Console.WriteLine($"{student.Name} has been added with ID: {student.Id}");
        }

        public void FindStudentById(int studentId)
        {
            var student = _students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.WriteLine($"Student with id {studentId} is {student.Name}.");
            }
            else
            {
                Console.WriteLine($"Student with id {studentId} does not exist.");
            }
        }

        public void FindStudentByName(string name)
        {
            var students = _students.Where(s => s.Name.ToLower().Contains(name.ToLower()));
            if (students.Any())
            {
                Console.WriteLine($"Students with name {name}:");
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Id} - {student.Name}");
                }
            }
            else
            {
                Console.WriteLine($"No student found with name {name}.");
            }
        }

        public void ListStudents()
        {
            Console.WriteLine("List of Students:");
            foreach (var student in _students)
            {
                Console.WriteLine($"{student.Id} - {student.Name} Class: {student.Class?.Name ?? "N/A"}");
            }
        }

        public void RemoveStudent(int studentId)
        {
            var student = _students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                Console.WriteLine($"Student with ID {studentId} could not be found.");
                return;
            }

            if (student.Class != null)
            {
                student.Class.Students?.Remove(student);
            }

            _students.Remove(student);
            Console.WriteLine($"{student.Name} has been removed.");
        }
    }
}
