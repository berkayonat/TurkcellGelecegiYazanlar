using FirstAssignment.Entities;
using System.Security.Claims;

namespace FirstAssignment.Entities
{
    public class Teacher : Person
    {
        public List<SchoolClass>? Classes { get; set; }
        public List<Assignment>? Assignments { get; set; }

        public Teacher()
        {
            Classes = new List<SchoolClass>();
            Assignments = new List<Assignment>();
        }

    }
}
