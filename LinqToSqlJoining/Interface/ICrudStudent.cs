using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlJoining.Interface
{
    interface ICrudStudent
    {
        void CreateData(Student student);
        void UpdateData(Student student);
        void DeleteData(int Id);
    }
}
