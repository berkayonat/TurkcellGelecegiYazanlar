using FirstAssignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment.Interfaces
{
    public interface IAssignmentService
    {
        void SubmitAssignment(int studentId, string assignmentName);
    }
}
