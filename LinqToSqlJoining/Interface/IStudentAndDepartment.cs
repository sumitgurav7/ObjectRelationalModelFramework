using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlJoining.Interface
{
    interface IStudentAndDepartment
    {
        List<JoinedStudentDepartments> GetStudentsByDepartment(int DeptId);
        IQueryable<IGrouping<int?, Student>> GetStudentsByDepartment();
    }
}
