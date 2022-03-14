using System;
using System.Collections.Generic;

namespace EmployeePayrollService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to Employee PayRoll Service!!!");

            Console.WriteLine("\nChoose Database Operations:" +
             "\n1. Show All Employees record Present in database table" +
             "\n2. Add new employee record" +
             "\n3. Delete existing employee" +
             "\n4. Update Employee data" +
             "\n5. Update Employee Basic Pay By Employee name" +
             "\n6. Get All Employees data In Perticular DateRange" +
             "\n7. ShowSumOfSalaryGroupByGender" +
             "\n8. Get all data using ER diagram Implementation" +
             "\n9. Exit\n");

            EmpDataMain empData = new EmpDataMain();
            EmpData_Model model = new EmpData_Model();

            bool flag = true;

            while (flag)
            {
                int empId =0;
                string ename = ""; string ephone = ""; string eaddress = ""; string egender = "";
                decimal esalary = 0; decimal basicpay = 0; decimal deduction = 0; decimal taxablepay = 0; decimal incometax = 0; decimal netpay = 0;
                DateTime jdate = Convert.ToDateTime(DateTime.Now), jdate1, jdate2 ;
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        empData.GetAllEmployee();
                        break;

                    case 2:
                        Console.WriteLine("\nEnter Employee Name :");
                        ename = Console.ReadLine();
                        Console.WriteLine("\nEnter Employee Salary :");
                        esalary = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee Gender(M/F) :");
                        egender = Console.ReadLine();
                        Console.WriteLine("\nEnter Employee Phone number :");
                        ephone = Console.ReadLine();
                        Console.WriteLine("\nEnter Employee Address as City Name :");
                        eaddress = Console.ReadLine();
                        Console.WriteLine("\nEnter Employee basic pay :");
                        basicpay = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee deduction: " );
                        deduction = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee taxable pay amount :");
                        taxablepay = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee Income tax amount :");
                        incometax = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee Net Pay amount :");
                        netpay = Convert.ToDecimal(Console.ReadLine());
                        jdate = Convert.ToDateTime(DateTime.Now);

                        model.name = ename;
                        model.salary = esalary;
                        model.gender = egender;
                        model.phone = ephone;
                        model.address = eaddress;
                        model.basic_pay = basicpay;
                        model.deduction = deduction;
                        model.taxable_pay = taxablepay;
                        model.income_tax = incometax;
                        model.net_pay = netpay;
                        model.startDate = jdate;
                        empData.AddEmployee(model);
                        break;

                    case 3:
                        Console.WriteLine("\nEnter Employee id to delete the record:");
                        empId = Convert.ToInt32(Console.ReadLine());
                        empData.DeleteEmployee(empId);
                        break;

                    case 4:
                        Console.WriteLine("\nEnter Employee id to change the Employee details");
                        empId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee Name :");
                        ename = Console.ReadLine();
                        Console.WriteLine("\nEnter Employee Salary :");
                        esalary = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee Gender(M/F) :");
                        egender = Console.ReadLine();
                        Console.WriteLine("\nEnter Employee Phone number :");
                        ephone = Console.ReadLine();
                        Console.WriteLine("\nEnter Employee Address as City Name :");
                        eaddress = Console.ReadLine();
                        Console.WriteLine("\nEnter Employee basic pay :");
                        basicpay = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee deduction: ");
                        deduction = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee taxable pay amount :");
                        taxablepay = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee Income tax amount :");
                        incometax = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee Net Pay amount :");
                        netpay = Convert.ToDecimal(Console.ReadLine());
                        jdate = Convert.ToDateTime(DateTime.Now);
                        model.id = empId;
                        model.name = ename;
                        model.salary = esalary;
                        model.gender = egender;
                        model.phone = ephone;
                        model.address = eaddress;
                        model.basic_pay = basicpay;
                        model.deduction = deduction;
                        model.taxable_pay = taxablepay;
                        model.income_tax = incometax;
                        model.net_pay = netpay;
                        model.startDate = jdate;
                        empData.UpdateEmployee(model);
                        break;

                    case 5:
                        Console.WriteLine("Please Enter name of Empoyee");
                        ename = Console.ReadLine();
                        Console.WriteLine("Enter New Basic pay amount:");
                        basicpay = Convert.ToDecimal(Console.ReadLine());
                        empData.UpdateEmployeeBasicPayByEmpName(ename,basicpay);
                        break;

                    case 6:
                        Console.WriteLine("Enter From date :");
                        jdate1 = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter To date :");
                        jdate2 = DateTime.Parse(Console.ReadLine());
                        empData.GetAllEmployeesdataInPerticularDateRange(jdate1, jdate2);
                        break;

                    case 7:
                        Console.WriteLine("Enter Gender of employee in format (M/F) :");
                        egender = Console.ReadLine();
                        empData.ShowSumOfSalaryGroupByGender(egender);
                        break;

                    case 8:
                        empData.ErDiagramImplementation();
                        break;

                    case 9:
                        break;

                    default:
                        Console.WriteLine("Choose valid operation!!!");
                        break;
                }

                Console.ReadKey();
            }
        }


    }
}
