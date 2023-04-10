using FirstAssignment.Entities;
using FirstAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FirstAssignment
{
    public class AssignmentService : IAssignmentService
    {
        private List<Assignment> _assignments;
        private IStudentManager _studentManager;
        public AssignmentService(IStudentManager studentManager) 
        {
            _assignments = new List<Assignment>();
            _studentManager = studentManager;
        }
        public void SubmitAssignment(int studentId, string assignmentName)
        {
            var student = _studentManager.Students.FirstOrDefault(t => t.Id == studentId);
            if (student == null)
            {
                Console.WriteLine($"Student with ID {studentId} could not be found.");
                return;
            }

            var assignment = new Assignment { Id = _assignments.Count + 1, Name = assignmentName };

            if (student.Class != null && student.Class.Teacher != null)
            {
                assignment.Teacher = student.Class.Teacher;
                student.Class.Teacher.Assignments?.Add(assignment);
            }

            assignment.Student = student;
            _assignments.Add(assignment);
            student.Assignments?.Add(assignment);
            Console.WriteLine($"{assignment.Name} has been submitted with ID: {assignment.Id}");
        }
    }
}
