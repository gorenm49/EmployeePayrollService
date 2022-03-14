using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class EmpDataMain
    {
        public static string connectionstr = "Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=Payroll_Service_DB;Integrated Security=True;";
        SqlConnection connection = new SqlConnection(connectionstr);

        public void GetAllEmployee()
        {
            try
            {
                EmpData_Model empModel = new EmpData_Model();

                using (this.connection)
                {

                    SqlCommand command = new SqlCommand("ShowEmpdata", this.connection);

                    this.connection.Open();

                    SqlDataReader dataReader = command.ExecuteReader();
                    Console.WriteLine("\nAll Empoyees record is:\n");
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            empModel.id = dataReader.GetInt32(0);
                            empModel.name = dataReader.GetString(1);
                            empModel.salary = dataReader.GetDecimal(2);
                            empModel.startDate = dataReader.GetDateTime(3);
                            empModel.phone = dataReader.GetString(4);
                            empModel.gender = dataReader.GetString(5);
                            empModel.address = dataReader.GetString(6);
                            empModel.basic_pay = dataReader.GetDecimal(7);
                            empModel.deduction = dataReader.GetDecimal(8);
                            empModel.taxable_pay = dataReader.GetDecimal(9);
                            empModel.income_tax = dataReader.GetDecimal(10);
                            empModel.net_pay = dataReader.GetDecimal(11);

                            
                            Console.WriteLine("id :"+empModel.id+
                                "\nName :"+empModel.name+
                                "\nSalary :"+empModel.salary+
                                "\nStart date :"+empModel.startDate+
                                "\nPhone number :"+empModel.phone+
                                "\nGender :"+empModel.gender+
                                "\nAddress  :" + empModel.address+
                                "\nBasic pay :" + empModel.basic_pay +
                                "\nDeduction :" + empModel.deduction +
                                "\nTaxable Pay:" + empModel.taxable_pay+
                                "\nIncome Tax:" + empModel.income_tax +
                                "\nNet Pay:" + empModel.net_pay +
                                "\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records found!!");
                    }

                    dataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public bool AddEmployee(EmpData_Model obj)
        {
            
                SqlCommand com = new SqlCommand("InsertEmpData", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@name", obj.name);
                com.Parameters.AddWithValue("@salary", obj.salary);
                com.Parameters.AddWithValue("@startDate", obj.startDate);
                com.Parameters.AddWithValue("@phone", obj.phone);
                com.Parameters.AddWithValue("@gender", obj.gender);
                com.Parameters.AddWithValue("@address", obj.address);
                com.Parameters.AddWithValue("@basicpay", obj.basic_pay);
                com.Parameters.AddWithValue("@deduction", obj.deduction);
                com.Parameters.AddWithValue("@taxablepay", obj.taxable_pay);
                com.Parameters.AddWithValue("@incometax", obj.income_tax);
                com.Parameters.AddWithValue("@netpay", obj.net_pay);

                connection.Open();
                int i = com.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                {
                    Console.WriteLine("Record has bees added");
                    return true;

                }
                else
                {
                    
                    return false;
                }
        }

        public bool DeleteEmployee(int Id)
        {

            SqlCommand com = new SqlCommand("DeleteEmpByid", connection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", Id);

            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                Console.WriteLine("Record deleted!!!");
                return true;
            }
            else
            {
                Console.WriteLine("No such a Record found to delete");
                return false;
            }
        }

        public bool UpdateEmployee(EmpData_Model obj)
        {


            SqlCommand com = new SqlCommand("UpdateEmployeeData", connection);

            com.CommandType = CommandType.StoredProcedure;
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@id", obj.id);
            com.Parameters.AddWithValue("@name", obj.name);
            com.Parameters.AddWithValue("@salary", obj.salary);
            com.Parameters.AddWithValue("@startDate", obj.startDate);
            com.Parameters.AddWithValue("@phone", obj.phone);
            com.Parameters.AddWithValue("@gender", obj.gender);
            com.Parameters.AddWithValue("@address", obj.address);
            com.Parameters.AddWithValue("@basicpay", obj.basic_pay);
            com.Parameters.AddWithValue("@deduction", obj.deduction);
            com.Parameters.AddWithValue("@taxablepay", obj.taxable_pay);
            com.Parameters.AddWithValue("@incometax", obj.income_tax);
            com.Parameters.AddWithValue("@netpay", obj.net_pay);
            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                Console.WriteLine("Record updated Successfully!!");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateEmployeeBasicPayByEmpName(string name, decimal basicpay)
        {


            SqlCommand com = new SqlCommand("UpdateEMPBasicPayByEmpName", connection);

            
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@name", name);
            com.Parameters.AddWithValue("@basicpay", basicpay);

            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                Console.WriteLine("Record updated Successfully!!");
                return true;
            }
            else
            {
                Console.WriteLine("No such record available");
                return false;
            }
        }

        public void GetAllEmployeesdataInPerticularDateRange(DateTime jdate1, DateTime jdate2)
        {
            try
            {
                EmpData_Model empModel = new EmpData_Model();
                

                using (this.connection)
                {

                    SqlCommand command = new SqlCommand("ShowEmpdataInPerticularDateRange", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@startdate1", jdate1);
                    command.Parameters.AddWithValue("@startdate2", jdate2);

                    this.connection.Open();

                    SqlDataReader dataReader = command.ExecuteReader();
                    Console.WriteLine("\nAll Empoyees record is between date "+jdate1+" and "+jdate2+" Are:");
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            empModel.id = dataReader.GetInt32(0);
                            empModel.name = dataReader.GetString(1);
                            empModel.salary = dataReader.GetDecimal(2);
                            empModel.startDate = dataReader.GetDateTime(3);
                            empModel.phone = dataReader.GetString(4);
                            empModel.gender = dataReader.GetString(5);
                            empModel.address = dataReader.GetString(6);
                            empModel.basic_pay = dataReader.GetDecimal(7);
                            empModel.deduction = dataReader.GetDecimal(8);
                            empModel.taxable_pay = dataReader.GetDecimal(9);
                            empModel.income_tax = dataReader.GetDecimal(10);
                            empModel.net_pay = dataReader.GetDecimal(11);


                            Console.WriteLine("id :" + empModel.id +
                                "\nName :" + empModel.name +
                                "\nSalary :" + empModel.salary +
                                "\nStart date :" + empModel.startDate +
                                "\nPhone number :" + empModel.phone +
                                "\nGender :" + empModel.gender +
                                "\nAddress  :" + empModel.address +
                                "\nBasic pay :" + empModel.basic_pay +
                                "\nDeduction :" + empModel.deduction +
                                "\nTaxable Pay:" + empModel.taxable_pay +
                                "\nIncome Tax:" + empModel.income_tax +
                                "\nNet Pay:" + empModel.net_pay +
                                "\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records found!!");
                    }

                    dataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public void ShowSumOfSalaryGroupByGender(string gender)
        {
            try
            {
                EmpData_Model empModel = new EmpData_Model();

                using (this.connection)
                {

                    SqlCommand command = new SqlCommand("ShowSumOfSalaryGroupByGender", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@gender", gender);

                    this.connection.Open();

                    SqlDataReader  dataReader = command.ExecuteReader(); 

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            empModel.salary = dataReader.GetDecimal(0);
                        }
                        Console.WriteLine("\nSum of Salary By Employee Gender " + gender + " is : "+empModel.salary);
                    }

                    dataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void ErDiagramImplementation()
        {
            try
            {
                EmpData_Model empModel = new EmpData_Model();
                EmpServiceModel empServiceModel = new EmpServiceModel();

                using (this.connection)
                {

                    SqlCommand command = new SqlCommand("ErDiagramRepresentation", this.connection);

                    this.connection.Open();

                    SqlDataReader dataReader = command.ExecuteReader();
                    Console.WriteLine("\nAll Empoyees records is:\n");
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            empModel.id = dataReader.GetInt32(0);
                            empModel.name = dataReader.GetString(1);
                            empModel.salary = dataReader.GetDecimal(2);
                            empModel.startDate = dataReader.GetDateTime(3);
                            empModel.phone = dataReader.GetString(4);
                            empModel.gender = dataReader.GetString(5);
                            empModel.address = dataReader.GetString(6);
                            empModel.basic_pay = dataReader.GetDecimal(7);
                            empModel.deduction = dataReader.GetDecimal(8);
                            empModel.taxable_pay = dataReader.GetDecimal(9);
                            empModel.income_tax = dataReader.GetDecimal(10);
                            empModel.net_pay = dataReader.GetDecimal(11);
                            empServiceModel.service_id = dataReader.GetInt32(12);
                            empServiceModel.id = dataReader.GetInt32(13);
                            empServiceModel.dept_id = dataReader.GetInt32(14);


                            Console.WriteLine("id :" + empModel.id +
                                "\nName :" + empModel.name +
                                "\nSalary :" + empModel.salary +
                                "\nStart date :" + empModel.startDate +
                                "\nPhone number :" + empModel.phone +
                                "\nGender :" + empModel.gender +
                                "\nAddress  :" + empModel.address +
                                "\nBasic pay :" + empModel.basic_pay +
                                "\nDeduction :" + empModel.deduction +
                                "\nTaxable Pay:" + empModel.taxable_pay +
                                "\nIncome Tax:" + empModel.income_tax +
                                "\nNet Pay:" + empModel.net_pay +
                                "\nService id :" + empServiceModel.service_id +
                                "\nEmp id:" + empServiceModel.id +
                                "\nDepartment id:" + empServiceModel.dept_id +
                                "\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records found!!");
                    }

                    dataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
