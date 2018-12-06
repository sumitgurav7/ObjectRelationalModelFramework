using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToSqlJoining.Interface;

namespace LinqToSqlJoining
{
    public class StudentInfo : CollegeDbConnect, IAllStudent, IStudentAndDepartment, ICrudStudent
    {
        public void CreateData(Student student)
        {
            collegeDataContext.Students.InsertOnSubmit(student);
            collegeDataContext.SubmitChanges();


        }

        public void DeleteData(int Id)
        {
            Student student = GetStudentById(Id);
            collegeDataContext.Students.DeleteOnSubmit(student);
            collegeDataContext.SubmitChanges();
        }

        public List<Student> DisplayAllStudent()
        {
            IEnumerable<Student> students = from student in collegeDataContext.Students
                                            select student;
            return students.ToList<Student>();
        }

        public Student GetStudentById(int Id)
        {
            IEnumerable<Student> students = from student in collegeDataContext.Students
                                            where student.Id == Id
                                            select student;
            return students.ToList<Student>().First<Student>();
        }

        public List<JoinedStudentDepartments> GetStudentsByDepartment(int DeptId)
        {
            IEnumerable<JoinedStudentDepartments> students = from student in collegeDataContext.Students
                                            join department in collegeDataContext.Departments
                                            on student.Department equals department.Dept_Id 
                                            into t
                                            from n in t
                                            where n.Dept_Id == DeptId
                                            select new JoinedStudentDepartments {
                                                Id = student.Id,
                                                Name = student.Name,
                                                Dept_Id = n.Dept_Id,
                                                Department_Name = n.Department_Name


                                            };
                                            
        
            
                                            
            return students.ToList();
        }

        public IQueryable<IGrouping<int?, Student>> GetStudentsByDepartment()
        {
            IQueryable<IGrouping<int?, Student>> students = from student in collegeDataContext.Students
                                                  group student by student.Department
                                                  into bydept
                                                  select bydept;
            return students;

        }

        public void UpdateData(Student student)
        {
            Student retriveStudent = collegeDataContext.Students.FirstOrDefault(e => e.Id == student.Id);
            if (student.Name != null)
            { retriveStudent.Name = student.Name; }
            if (student.Department != null)
            { retriveStudent.Department = student.Department; }
            collegeDataContext.Students.InsertOnSubmit(retriveStudent);
            collegeDataContext.SubmitChanges();
        }

       
    }
}
