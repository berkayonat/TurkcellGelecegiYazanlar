using FirstAssignment.Entities;
using FirstAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment
{
    public class SchoolClassManager : ISchoolClassManager
    {
        private List<SchoolClass> _classes;
        private ITeacherManager _teacherManager;
        private IStudentManager _studentManager;
        public SchoolClassManager(ITeacherManager teacherManager, IStudentManager studentManager)
        {
            _classes = new List<SchoolClass>();
            _teacherManager = teacherManager;
            _studentManager = studentManager;

        }
        public void AddClass(string name, int teacherId)
        {
            var teacher = _teacherManager.Teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacher == null)
            {
                Console.WriteLine($"Teacher with ID {teacherId} could not be found.");
                return;
            }

            var newClass = new SchoolClass { Id = _classes.Count + 1, Name = name, Teacher = teacher };
            _classes.Add(newClass);
            teacher.Classes?.Add(newClass);
            Console.WriteLine($"{newClass.Name} has been added with ID: {newClass.Id}");
        }

        public void AddStudentToClass(int studentId, int classId)
        {
            var student = _studentManager.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                Console.WriteLine($"Student with ID {studentId} could not be found.");
                return;
            }

            var schoolClass = _classes.FirstOrDefault(c => c.Id == classId);
            if (schoolClass == null)
            {
                Console.WriteLine($"Class with ID {classId} could not be found.");
                return;
            }

            if (schoolClass.Students == null)
            {
                schoolClass.Students = new List<Student>();
            }         

            student.Class = schoolClass;
            schoolClass.Students?.Add(student);
            Console.WriteLine($"{student.Name} has been added to class {schoolClass.Name}.");
        }
        public void RemoveStudentFromClass(int studentId, int classId)
        {
            var student = _studentManager.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                Console.WriteLine($"Student with ID {studentId} could not be found.");
                return;
            }

            var schoolClass = _classes.FirstOrDefault(c => c.Id == classId);
            if (schoolClass == null)
            {
                Console.WriteLine($"Class with ID {classId} could not be found.");
                return;
            }
            if (!schoolClass.Students.Contains(student))
            {
                Console.WriteLine($"Student '{student.Name}' is not in class '{schoolClass.Name}'");
                return;
            }

            student.Class = null;
            schoolClass.Students?.Remove(student);
            Console.WriteLine($"{student.Name} has been removed to class {schoolClass.Name}.");
        }

        public SchoolClass GetClassById(int classIdForList)
        {
            var schoolClass = _classes.FirstOrDefault(c => c.Id == classIdForList);

            if (schoolClass == null)
            {
                Console.WriteLine($"Class with ID {classIdForList} could not be found.");
            }
            return schoolClass;
        }

        public void ListSchoolClasses()
        {
            Console.WriteLine("List of Classes:");
            foreach (var schoolClass in _classes)
            {
                Console.WriteLine($"{schoolClass.Id} - {schoolClass.Name} - Teacher: {schoolClass.Teacher?.Name ?? "N/A"}");
            }
        }

        public void ListStudentsInClass(SchoolClass schoolClass)
        {
            Console.WriteLine($"Students in {schoolClass.Name} class:");
            if (schoolClass.Students == null)
            {
                Console.WriteLine("No students found.");
                return;
            }
            foreach (var student in schoolClass.Students)
            {
                Console.WriteLine($"{student.Id} - {student.Name}");
            }
        }
        public void RemoveClass(int classId)
        {
            var schoolClass = _classes.FirstOrDefault(t => t.Id == classId);
            if (schoolClass == null)
            {
                Console.WriteLine($"Class with ID {classId} could not be found.");
                return;
            }

            foreach (var student in schoolClass.Students)
            {
                student.Class = null;
            }

            if (schoolClass.Teacher != null)
            {
                schoolClass.Teacher.Classes?.Remove(schoolClass);
            }
            _classes.Remove(schoolClass);
            Console.WriteLine($"Class {schoolClass.Name} has been removed.");
        }
    }
}
