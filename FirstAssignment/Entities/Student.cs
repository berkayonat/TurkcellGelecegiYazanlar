using System.Security.Claims;

namespace FirstAssignment.Entities
{
    public class Student : Person
    {
        public SchoolClass? Class { get; set; }
        public List<Assignment>? Assignments { get; set; }
        public Student() 
        {
            Assignments = new List<Assignment>();   
        }
    }
}
