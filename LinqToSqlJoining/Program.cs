using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToSqlJoining.Interface;

namespace LinqToSqlJoining
{
    class Program
    {
        CollegeDbConnect dbConnect = new StudentInfo();
        
        public IAllDepartments allDepartments = new DepartmentInfo();
        public IAllStudent allStudent = new StudentInfo();
        public IStudentAndDepartment studentAndDepartment = new StudentInfo();
        public ICrudDepartment crudDepartment = new DepartmentInfo();
        public ICrudStudent crudStudent = new StudentInfo();
        

        static void Main(string[] args)
        {
            int choice;
            Program program = new Program();

            do
            {
                
                Console.WriteLine("welcome to college database");
                Console.WriteLine("Enter 1 to Show all Students");
                Console.WriteLine("Enter 2 to show students by id");
                Console.WriteLine("enter 3 to show all departments");
                Console.WriteLine("enter 4 to show student of particular department ");
                Console.WriteLine("enter 5 to show student by department");
                Console.WriteLine("enter 6 to get department by id");
                Console.WriteLine("Enter 7 to Do Update delete Operation on student");
                Console.WriteLine("Enter 8 to Do Update Delete operation on Departments");
                Console.WriteLine("enter 0 to exit"); 

                if(int.TryParse(Console.ReadLine(), out choice))
                {
                    program.StartApp(choice);
                }
                else
                {
                    choice = 9;
                }
            } while (choice !=0);
            
        }

        private void StartApp(int choice)
        {
            
            
            CollegeService collegeService = new CollegeService(allDepartments, allStudent, studentAndDepartment, crudStudent, crudDepartment);
            Console.WriteLine("Count of all student");
            Console.WriteLine(collegeService.CountStudents());
            Console.WriteLine("Count of all departments");
            Console.WriteLine(collegeService.CountDepartments());

            switch (choice)
            {
                case 1:
                    foreach(Student student in collegeService.DisplayAllStudent())
                    {
                        Console.WriteLine(student);
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter Id to be fetched");
                    int id;
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine(allStudent.GetStudentById(id));
                    }
                    else
                    {
                        Console.WriteLine("Enter Proper Id");
                    }

                    break;
                case 3:
                    foreach (Department department in allDepartments.DisplayAllDepartment())
                    {
                        Console.WriteLine(department);
                    }

                    break;

                case 4:

                    Console.WriteLine("Enter Department Id to be fetched");
                    int Dept_id;
                    if (int.TryParse(Console.ReadLine(), out Dept_id))
                    {
                        foreach(JoinedStudentDepartments student in studentAndDepartment.GetStudentsByDepartment(Dept_id))
                        {
                            Console.WriteLine(student);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter Proper Id");
                    }


                    break;

                case 5:
                    foreach(var obj in collegeService.GetStudentsByDepartment())
                    {
                        Console.WriteLine("Students of {0} Department" , obj.Key);
                        foreach(Student student in obj)
                        {
                            Console.WriteLine("               " + student);
                        }
                    }
                    break;

                case 6:
                    Console.WriteLine("Enter Department Id to be fetched");
                    
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine(collegeService.DisplayDepartmentById(id));
                    }
                    else
                    {
                        Console.WriteLine("Enter Proper Id");
                    }

                    break;

                case 7:
                    crudStudentOperations(collegeService);
                    break;

                case 8:
                    crudDepartmentOperations(collegeService);
                    break;

            }
        }

        private void crudDepartmentOperations(CollegeService collegeService)
        {
            Console.WriteLine("Enter 1 to create Department");
            Console.WriteLine("enter 2 to update Department");
            Console.WriteLine("Enter 3 to delete Department");
            int choice;
            if(int.TryParse(Console.ReadLine(),out choice))
            {
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter details of Department");
                        Console.WriteLine("Enter Dept Id");
                        Department department = new Department();
                        Console.WriteLine("Enter Id");
                        department.Dept_Id = int.TryParse(Console.ReadLine(),out int id)?id:0;
                        Console.WriteLine("Enter Department");
                        string name = Console.ReadLine();
                        department.Department_Name = name!=""?name:null;
                        
                        collegeService.createDepartment(department);
                        break;

                    case 2:
                        Console.WriteLine("Enter details of Department");
                        Console.WriteLine("Enter Dept Id");
                        Department department1 = new Department();
                        Console.WriteLine("Enter Id");
                        department1.Dept_Id = int.TryParse(Console.ReadLine(), out id) ? id : 0;
                        Console.WriteLine("Enter Department");
                        name = Console.ReadLine();
                        department1.Department_Name = name != "" ? name : null;

                        collegeService.updateDepartment(department1);

                        break;

                    case 3:
                        Console.WriteLine("Enter ID to delete");
                        int Id = int.TryParse(Console.ReadLine(), out id) ? id : 0;
                        collegeService.deleteDepartment(Id);
                        break;

                }
            }
        }

        private void crudStudentOperations(CollegeService collegeService)
        {
            Console.WriteLine("Enter 1 to create Student");
            Console.WriteLine("enter 2 to update student");
            Console.WriteLine("Enter 3 to delete student");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter details of student");
                        Console.WriteLine("Enter Id");
                        Student student = new Student();
                        Console.WriteLine("Enter Id");
                        student.Id = int.TryParse(Console.ReadLine(), out int id)?id:0;
                        Console.WriteLine("Enter NAme");
                        string name = Console.ReadLine();
                        
                        student.Name = name!=""?name:null;
                        Console.WriteLine("Enter department Id");
                        student.Department = int.TryParse(Console.ReadLine(), out int dept)? dept:0;
                        collegeService.CreateStudent(student);
                        break;

                    case 2:
                        Console.WriteLine("Enter details of student");
                        Console.WriteLine("Enter Id");
                        Student student1 = new Student();
                        Console.WriteLine("Enter Id");
                        student1.Id = int.TryParse(Console.ReadLine(), out id) ? id : 0;
                        Console.WriteLine("Enter NAme");
                        name = Console.ReadLine();
                        student1.Name = name != "" ? name : null;
                        Console.WriteLine("Enter department Id");
                        student1.Department = int.TryParse(Console.ReadLine(), out dept) ? dept : 0;
                        collegeService.updateStudent(student1);
                        break;

                    case 3:
                        Console.WriteLine("Enter ID to delete");
                        int Id = int.TryParse(Console.ReadLine(), out id) ? id : 0;
                        collegeService.deleteStudent(Id);
                        break;

                }
            }
        }
    }
}
