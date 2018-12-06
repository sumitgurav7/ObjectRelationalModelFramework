using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlJoining.Interface
{
    interface IAllStudent
    {
        List<Student> DisplayAllStudent();
        Student GetStudentById(int Id);
    }
}
