using System.Security.Claims;

namespace FirstAssignment.Entities
{
    public class Student : Person
    {
        public SchoolClass? Class { get; set; }

    }
}
