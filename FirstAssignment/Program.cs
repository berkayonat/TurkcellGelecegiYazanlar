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
        IAssignmentService assignmentService = new AssignmentService(studentManager);

        while (true)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add teacher");
            Console.WriteLine("2. Add student");
            Console.WriteLine("3. Add class");
            Console.WriteLine("4. Add student to class");
            Console.WriteLine("5. Remove student from class");
            Console.WriteLine("6. List students in class");
            Console.WriteLine("7. Find student by ID");
            Console.WriteLine("8. Find student by name");
            Console.WriteLine("9. List students");
            Console.WriteLine("10. List classes");
            Console.WriteLine("11. List teachers");
            Console.WriteLine("12. Remove teacher");
            Console.WriteLine("13. Remove student");
            Console.WriteLine("14. Remove class");
            Console.WriteLine("15. Submit assignment");
            Console.WriteLine("16. Exit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddTeacher(teacherManager);
                    break;
                case "2":
                    AddStudent(studentManager);
                    break;
                case "3":
                    AddClass(schoolClassManager);
                    break;
                case "4":
                    AddStudentToClass(schoolClassManager);
                    break;
                case "5":
                    RemoveStudentFromClass(schoolClassManager);
                    break;
                case "6":
                    ListStudentsInClass(schoolClassManager);
                    break;
                case "7":
                    FindStudentById(studentManager);
                    break;
                case "8":
                    FindStudentByName(studentManager);
                    break;
                case "9":
                    studentManager.ListStudents();
                    break;
                case "10":
                    schoolClassManager.ListSchoolClasses();
                    break;
                case "11":
                    teacherManager.ListTeachers();
                    break;
                case "12":
                    RemoveTeacher(teacherManager);
                    break;
                case "13":
                    RemoveStudent(studentManager);
                    break;
                case "14":
                    RemoveClass(schoolClassManager);
                    break;
                case "15":
                    SubmitAssignment(assignmentService);
                    break;
                case "16":
                    Console.WriteLine("Exiting the application...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }

    private static void SubmitAssignment(IAssignmentService assignmentService)
    {
        Console.WriteLine("Please enter the ID of the student:");
        int studentId;
        if (!int.TryParse(Console.ReadLine(), out studentId) || studentId < 0)
        {
            Console.WriteLine("Invalid student ID.");
            return;
        }
        Console.WriteLine("Please enter the name of the assignment:");
        string assignmentName = Console.ReadLine();
        if (string.IsNullOrEmpty(assignmentName))
        {
            Console.WriteLine("Assignment name cannot be null or empty.");
            return;
        }
        assignmentService.SubmitAssignment(studentId, assignmentName);
    }

    static void AddTeacher(ITeacherManager teacherManager)
    {
        Console.WriteLine("Please enter the name of the teacher:");
        string teacherName = Console.ReadLine();
        if (string.IsNullOrEmpty(teacherName))
        {
            Console.WriteLine("Teacher name cannot be null or empty.");
            return;
        }
        if (!Regex.IsMatch(teacherName, @"^[a-zA-Z]+$"))
        {
            Console.WriteLine("Invalid input. Name should only contain letters.");
            return;
        }
        teacherManager.AddTeacher(teacherName);
    }

    static void AddStudent(IStudentManager studentManager)
    {
        Console.WriteLine("Please enter the name of the student:");
        string studentName = Console.ReadLine();
        if (string.IsNullOrEmpty(studentName))
        {
            Console.WriteLine("Student name cannot be null or empty.");
            return;
        }
        if (!Regex.IsMatch(studentName, @"^[a-zA-Z]+$"))
        {
            Console.WriteLine("Invalid input. Name should only contain letters.");
            return;
        }
        studentManager.AddStudent(studentName);
    }

    static void AddClass(ISchoolClassManager schoolClassManager)
    {
        Console.WriteLine("Please enter the name of the class:");
        string className = Console.ReadLine();
        if (string.IsNullOrEmpty(className))
        {
            Console.WriteLine("Class name cannot be null or empty.");
            return;
        }
        Console.WriteLine("Please enter the ID of the teacher:");
        int teacherId;
        if (!int.TryParse(Console.ReadLine(), out teacherId) || teacherId < 0)
        {
            Console.WriteLine("Invalid teacher ID.");
            return;
        }
        schoolClassManager.AddClass(className, teacherId);
    }

    static void AddStudentToClass(ISchoolClassManager schoolClassManager)
    {
        Console.WriteLine("Please enter the ID of the student:");
        int studentId;
        if (!int.TryParse(Console.ReadLine(), out studentId) || studentId < 0)
        {
            Console.WriteLine("Invalid student ID.");
            return;
        }
        Console.WriteLine("Please enter the ID of the class:");
        int classId;
        if (!int.TryParse(Console.ReadLine(), out classId) || classId < 0)
        {
            Console.WriteLine("Invalid class ID.");
            return;
        }
        schoolClassManager.AddStudentToClass(studentId, classId);
        
    }

    static void RemoveStudentFromClass(ISchoolClassManager schoolClassManager)
    {
        Console.WriteLine("Please enter the ID of the student:");
        int studentIdToRemove;
        if (!int.TryParse(Console.ReadLine(), out studentIdToRemove) || studentIdToRemove < 0)
        {
            Console.WriteLine("Invalid student ID.");
            return;
        }
        Console.WriteLine("Please enter the ID of the class:");
        int classIdToRemove;
        if (!int.TryParse(Console.ReadLine(), out classIdToRemove) || classIdToRemove < 0)
        {
            Console.WriteLine("Invalid class ID.");
            return;
        }
        schoolClassManager.RemoveStudentFromClass(studentIdToRemove, classIdToRemove);
    }

    static void ListStudentsInClass(ISchoolClassManager schoolClassManager)
    {
        Console.WriteLine("Please enter the ID of the class:");
        int classIdForList;
        if (!int.TryParse(Console.ReadLine(), out classIdForList) || classIdForList < 0)
        {
            Console.WriteLine("Invalid class ID.");
            return;
        }
        SchoolClass schoolClass = schoolClassManager.GetClassById(classIdForList);
        if (schoolClass != null)
        {
            schoolClassManager.ListStudentsInClass(schoolClass);
        }
    }

    static void FindStudentById(IStudentManager studentManager)
    {
        Console.WriteLine("Please enter the ID of the student:");
        int studentIdForFind;
        if (!int.TryParse(Console.ReadLine(), out studentIdForFind) || studentIdForFind < 0)
        {
            Console.WriteLine("Invalid student ID.");
            return;
        }
        studentManager.FindStudentById(studentIdForFind);
    }

    static void FindStudentByName(IStudentManager studentManager)
    {
        Console.WriteLine("Please enter the name of the student:");
        string studentNameForFind = Console.ReadLine();
        studentManager.FindStudentByName(studentNameForFind);
    }

    static void RemoveTeacher(ITeacherManager teacherManager)
    {
        Console.WriteLine("Please enter the ID of the teacher:");
        int teacherIdForRemove;
        if (!int.TryParse(Console.ReadLine(), out teacherIdForRemove) || teacherIdForRemove < 0)
        {
            Console.WriteLine("Invalid teacher ID.");
            return;
        }
        teacherManager.RemoveTeacher(teacherIdForRemove);
    }

    static void RemoveStudent(IStudentManager studentManager)
    {
        Console.WriteLine("Please enter the ID of the student:");
        int studentIdForRemove;
        if (!int.TryParse(Console.ReadLine(), out studentIdForRemove) || studentIdForRemove < 0)
        {
            Console.WriteLine("Invalid student ID.");
            return;
        }
        studentManager.RemoveStudent(studentIdForRemove);
    }

    static void RemoveClass(ISchoolClassManager schoolClassManager)
    {
        Console.WriteLine("Please enter the ID of the class:");
        int classIdForRemove;
        if (!int.TryParse(Console.ReadLine(), out classIdForRemove) || classIdForRemove < 0)
        {
            Console.WriteLine("Invalid class ID.");
            return;
        }
        schoolClassManager.RemoveClass(classIdForRemove);
    }
}