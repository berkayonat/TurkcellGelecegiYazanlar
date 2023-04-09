using FirstAssignment.Entities;
using System.Security.Claims;

namespace FirstAssignment.Entities
{
    public class Teacher : Person
    {
        public List<SchoolClass>? Classes { get; set; }

    }
}
