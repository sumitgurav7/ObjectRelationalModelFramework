using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlJoining.Interface
{
    interface IAllDepartments
    {
        List<Department> DisplayAllDepartment();
        Department GetDepartmentById(int DeptId);
    }
}
