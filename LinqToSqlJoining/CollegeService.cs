
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LinqToSqlJoining.Interface;
using LinqToSqlJoining.Extension;

namespace LinqToSqlJoining
{
    class CollegeService
    {
        private IAllDepartments allDepartments;
        private IAllStudent allStudent;
        private IStudentAndDepartment studentAndDepartment;
        private ICrudStudent crudStudent;
        private ICrudDepartment crudDepartment;

        public CollegeService(IAllDepartments allDepartments, IAllStudent allStudent, IStudentAndDepartment studentAndDepartment, ICrudStudent crudStudent, ICrudDepartment crudDepartment)
        {
            this.allDepartments = allDepartments;
            this.allStudent = allStudent;
            this.studentAndDepartment = studentAndDepartment;
            this.crudStudent = crudStudent;
            this.crudDepartment = crudDepartment;
        }

        public IAllDepartments AllDepartments { get => allDepartments; set => allDepartments = value; }
        public IAllStudent AllStudent { get => allStudent; set => allStudent = value; }
        public IStudentAndDepartment StudentAndDepartment { get => studentAndDepartment; set => studentAndDepartment = value; }
        internal ICrudStudent CrudStudent { get => crudStudent; set => crudStudent = value; }
        internal ICrudDepartment CrudDepartment { get => crudDepartment; set => crudDepartment = value; }

        public List<Department> DisplayAllDepartments()
        {
            return AllDepartments.DisplayAllDepartment();
        }

        public Department DisplayDepartmentById(int dept)
        {
            return allDepartments.GetDepartmentById(dept);
        }

        public List<Student> DisplayAllStudent()
        {
            return AllStudent.DisplayAllStudent();
        }

        public Student GetStudentById(int Id)
        {
            return AllStudent.GetStudentById(Id);
        }

        public List<JoinedStudentDepartments> GetStudentsByDepartment(int DeptId)
        {
            return StudentAndDepartment.GetStudentsByDepartment(DeptId);
        }

        public IQueryable<IGrouping<int?, Student>> GetStudentsByDepartment()
        {
            return StudentAndDepartment.GetStudentsByDepartment();
        }

        public void CreateStudent(Student student)
        {
            crudStudent.CreateData(student);
        }

        public void updateStudent(Student student)
        {
            crudStudent.UpdateData(student);
        }

        public void deleteStudent(int id)
        {
            crudStudent.DeleteData(id);
        }

        public void createDepartment(Department department)
        {
            CrudDepartment.CreateData(department);

        }

        public void updateDepartment(Department department)
        {
            CrudDepartment.UpdateData(department);

        }

        public void deleteDepartment(int id)
        {
            CrudDepartment.DeleteData(id);
        }

        public int CountStudents()
        {
            return allStudent.Count();
        }

        public int CountDepartments()
        {
            return allDepartments.Count();
        }
    }
}