using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlJoining
{
    public class JoinedStudentDepartments
    {
        private int _Id;

        private string _Name;

        private int _Dept_Id;

        private string _Department_Name;

        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public int Dept_Id { get => _Dept_Id; set => _Dept_Id = value; }
        public string Department_Name { get => _Department_Name; set => _Department_Name = value; }

        public override string ToString()
        {
            return " Name : " + Name + " Student Id: " + Id + " Department : " + Department_Name;
        }
    }
}
