using FirstAssignment.Entities;
using FirstAssignment;
using FirstAssignment.Interfaces;
using System.Xml.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        IStudentManager studentManager = new StudentManager();
        ITeacherManager teacherManager = new TeacherManager();
        ISchoolClassManager schoolClassManager = new SchoolClassManager(teacherManager,studentManager);
        
        while (true)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add teacher");
            Console.WriteLine("2. Add student");
            Console.WriteLine("3. Add class");
            Console.WriteLine("4. Add student to class");
            Console.WriteLine("5. List students in class");
            Console.WriteLine("6. Find student by ID");
            Console.WriteLine("7. Find student by name");
            Console.WriteLine("8. List students");
            Console.WriteLine("9. List classes");
            Console.WriteLine("10. List teachers");
            Console.WriteLine("11. Remove teacher");
            Console.WriteLine("12. Remove student");
            Console.WriteLine("13. Remove class");
            Console.WriteLine("14. Exit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Please enter the name of the teacher:");
                    string teacherName = Console.ReadLine();
                    if (string.IsNullOrEmpty(teacherName))
                    {
                        Console.WriteLine("Teacher name cannot be null or empty.");
                        break;
                    }
                    if (!Regex.IsMatch(teacherName, @"^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("Invalid input. Name should only contain letters.");
                        break;
                    }
                    teacherManager.AddTeacher(teacherName);
                    break;
                case "2":
                    Console.WriteLine("Please enter the name of the student:");
                    string studentName = Console.ReadLine();
                    if (string.IsNullOrEmpty(studentName))
                    {
                        Console.WriteLine("Student name cannot be null or empty.");
                        break;
                    }
                    if (!Regex.IsMatch(studentName, @"^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("Invalid input. Name should only contain letters.");
                        break;
                    }
                    studentManager.AddStudent(studentName);
                    break;
                case "3":
                    Console.WriteLine("Please enter the name of the class:");
                    string className = Console.ReadLine();
                    if (string.IsNullOrEmpty(className))
                    {
                        Console.WriteLine("Class name cannot be null or empty.");
                        break;
                    }
                    Console.WriteLine("Please enter the ID of the teacher:");
                    int teacherId;
                    if (!int.TryParse(Console.ReadLine(), out teacherId) || teacherId < 0)
                    {
                        Console.WriteLine("Invalid teacher ID.");
                        break;
                    }
                    schoolClassManager.AddClass(className, teacherId);
                    break;
                case "4":
                    Console.WriteLine("Please enter the ID of the student:");
                    int studentId;
                    if (!int.TryParse(Console.ReadLine(), out studentId) || studentId < 0)
                    {
                        Console.WriteLine("Invalid student ID.");
                        break;
                    }
                    Console.WriteLine("Please enter the ID of the class:");
                    int classId;
                    if (!int.TryParse(Console.ReadLine(), out classId) || classId < 0)
                    {
                        Console.WriteLine("Invalid class ID.");
                        break;
                    }
                    schoolClassManager.AddStudentToClass(studentId, classId);
                    break;
                case "5":
                    Console.WriteLine("Please enter the ID of the class:");
                    int classIdForList;
                    if (!int.TryParse(Console.ReadLine(), out classIdForList) || classIdForList < 0)
                    {
                        Console.WriteLine("Invalid class ID.");
                        break;
                    }
                    SchoolClass schoolClass = schoolClassManager.GetClassById(classIdForList);
                    if (schoolClass != null) 
                    {
                        schoolClassManager.ListStudentsInClass(schoolClass);
                    }
                    break;
                case "6":
                    Console.WriteLine("Please enter the ID of the student:");
                    int studentIdForFind;
                    if (!int.TryParse(Console.ReadLine(), out studentIdForFind) || studentIdForFind < 0)
                    {
                        Console.WriteLine("Invalid student ID.");
                        break;
                    }
                    studentManager.FindStudentById(studentIdForFind);
                    break;
                case "7":
                    Console.WriteLine("Please enter the name of the student:");
                    string studentNameForFind = Console.ReadLine();
                    studentManager.FindStudentByName(studentNameForFind);
                    break;
                case "8":
                    studentManager.ListStudents();
                    break;
                case "9":
                    schoolClassManager.ListSchoolClasses();
                    break;
                case "10":
                    teacherManager.ListTeachers();
                    break;
                case "11":
                    Console.WriteLine("Please enter the ID of the teacher:");
                    int teacherIdForRemove;
                    if (!int.TryParse(Console.ReadLine(), out teacherIdForRemove) || teacherIdForRemove < 0)
                    {
                        Console.WriteLine("Invalid teacher ID.");
                        break;
                    }
                    teacherManager.RemoveTeacher(teacherIdForRemove);
                    break;
                case "12":
                    Console.WriteLine("Please enter the ID of the student:");
                    int studentIdForRemove;
                    if (!int.TryParse(Console.ReadLine(), out studentIdForRemove) || studentIdForRemove < 0)
                    {
                        Console.WriteLine("Invalid student ID.");
                        break;
                    }
                    studentManager.RemoveStudent(studentIdForRemove);
                    break;
                case "13":
                    Console.WriteLine("Please enter the ID of the class:");
                    int classIdForRemove;
                    if (!int.TryParse(Console.ReadLine(), out classIdForRemove) || classIdForRemove < 0)
                    {
                        Console.WriteLine("Invalid class ID.");
                        break;
                    }
                    schoolClassManager.RemoveClass(classIdForRemove);
                    break;
                case "14":
                    Console.WriteLine("Exiting the application...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
}