using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
