using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToSqlJoining.Interface;

namespace LinqToSqlJoining.Extension
{
    static class ExtendingMethods
    {

        public static int Count(this IAllDepartments allDepartments)
        {
            return allDepartments.DisplayAllDepartment().Count;
        }

        public static int Count(this IAllStudent allStudent)
        {
            return allStudent.DisplayAllStudent().Count;
        }
    }
}
