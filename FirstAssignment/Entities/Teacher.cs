using FirstAssignment.Entities;
using System.Security.Claims;

namespace FirstAssignment.Entities
{
    public class Teacher : Person
    {
        public List<SchoolClass>? Classes { get; set; } = new List<SchoolClass>();
        public List<Assignment>? Assignments { get; set; } = new List<Assignment>();

        //public Teacher() 
        //{
        //    Classes = new List<SchoolClass>();
        //    Assignments = new List<Assignment>();
        //}

    }
}
