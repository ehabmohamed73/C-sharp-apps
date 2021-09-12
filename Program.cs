using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminstrationAPI;
using System.Windows.Forms;
using System.Drawing;

namespace schoolHRMangement
{
   
    public enum EmployeeType
    {
        techer,
        headOfDepartment,
        headMaster
    };
    class Program
    {
        //public static List<IEmployee> employees = new List<IEmployee>();
        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.Run(new ControlInput());
            //Console.WriteLine($"the total salary ancluding bouns : {employees.Sum(e => e.Salary)}");
            //Console.WriteLine("the Name of the Employees : ");
            //foreach(IEmployee emp in employees)
            //{
            //    Console.WriteLine(emp.Name);
            //}

            //foreach(string names in employees.ForEach(e=>e.Name))
            //{

            //}
            //Console.ReadKey();

        }

  
    }
        public class Techer : Employee
        {
        public override decimal Salary { get => base.Salary + (base.Salary * .03m); }
    }
        public class HeadOfDepartment : Employee
        {
        public override decimal Salary { get => base.Salary + (base.Salary * .05m);  }
    }
        public class HeadMaster : Employee
        {
        public override decimal Salary { get => base.Salary+ (base.Salary *.08m);}
    }
        public static class EmployeeFactor
        {
            public static IEmployee GetEmployeeInstanase(EmployeeType employee, int id, string name, decimal salary)
            {
                IEmployee employeeTemp = null;

                switch (employee)
                {
                    case EmployeeType.techer:
                        employeeTemp = new Techer();
                        employeeTemp.Id = id;
                        employeeTemp.Name = name;
                        employeeTemp.Salary = salary;
                        break;
                    case EmployeeType.headMaster:
                        employeeTemp = new HeadMaster();
                      
                        employeeTemp.Id = id;
                        employeeTemp.Name = name;
                        employeeTemp.Salary = salary;
                        break;
                    case EmployeeType.headOfDepartment:
                        employeeTemp = new HeadOfDepartment();
                       
                        employeeTemp.Id = id;
                        employeeTemp.Name = name;
                        employeeTemp.Salary = salary;
                        break;
                    default:
                        break;


                }
                return employeeTemp;
            }
        }
    }

//void setData()
//{

//    IEmployee headm = EmployeeFactor.GetEmployeeInstanase(EmployeeType.headMaster, 2, "Ehab", 20);

//    IEmployee headOfDe = EmployeeFactor.GetEmployeeInstanase(EmployeeType.headOfDepartment, 3, "Ali Doe", 10);
//    employees.Add(headOfDe);
//    IEmployee tech = EmployeeFactor.GetEmployeeInstanase(EmployeeType.techer, 1, "Hanie Ali", 5);
//    employees.Add(tech);
//}