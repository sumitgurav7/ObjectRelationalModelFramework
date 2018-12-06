using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToSqlJoining.Interface;

namespace LinqToSqlJoining
{
    public class DepartmentInfo : CollegeDbConnect, IAllDepartments, ICrudDepartment
    {
        public void CreateData(Department department)
        {
            collegeDataContext.Departments.InsertOnSubmit(department);
            collegeDataContext.SubmitChanges();
        }

        public void DeleteData(int Id)
        {
            Department department = GetDepartmentById(Id);
            collegeDataContext.Departments.DeleteOnSubmit(department);
            collegeDataContext.SubmitChanges();
        }

        public List<Department> DisplayAllDepartment()
        {
            IEnumerable<Department> departments = from department in collegeDataContext.Departments
                                            select department;
            return departments.ToList<Department>();
        }

        public Department GetDepartmentById(int deptId)
        {
            IEnumerable<Department> departments = from department in collegeDataContext.Departments
                                                  where department.Dept_Id == deptId
                                                  select department;
            return departments.ToList<Department>().First();
        }

        public void UpdateData(Department department)
        {
            if (department.Dept_Id != 0 || department.Department_Name == "" || department.Department_Name == null )
            {
                Department retriveDepartment = collegeDataContext.Departments.FirstOrDefault(e => e.Dept_Id == department.Dept_Id);
                if (department.Department_Name != null)
                { retriveDepartment.Department_Name = department.Department_Name; }

                collegeDataContext.Departments.InsertOnSubmit(retriveDepartment);
                collegeDataContext.SubmitChanges(); 
            }
            else
            {
                Console.WriteLine("Id is wrong");
            }
        }
    }
}
