using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlJoining.Interface
{
    interface ICrudDepartment
    {
        void CreateData(Department department);
        void UpdateData(Department department);
        void DeleteData(int Id);
    }
}
