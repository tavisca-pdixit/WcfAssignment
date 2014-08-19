using Client.MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateEmployeeAddRemarksClient client = new CreateEmployeeAddRemarksClient();
            CreateEmployeeDetailsClient client1 = new CreateEmployeeDetailsClient();

            List<EmployeeData> employeeList = new List<EmployeeData>();
            List<EmployeeRemarks> employeeRemarksList = new List<EmployeeRemarks>();

            string ch, empId, empName, empRemark, search, details;
            int ch1;
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("Enter your choice : ");
                Console.WriteLine("1.Add Record");
                Console.WriteLine("2.Add Remark");
                Console.WriteLine("3.Delete Record");
                Console.WriteLine("4.Search a Record");
                Console.WriteLine("5.Display all Records");
                Console.WriteLine("6.Exit");
                
                ch = Console.ReadLine();
                bool parse = Int32.TryParse(ch, out ch1);

                switch (ch1)
                {
                    case 1:
                        EmployeeData employee2 = new EmployeeData();
                        Console.WriteLine("\n");
                        Console.WriteLine("*** Adding a Record ***");
                        Console.WriteLine("Enter Employee Id : ");
                        empId = Console.ReadLine();

                            Console.WriteLine("Enter Employee Name : ");
                            empName = Console.ReadLine();
                            int i = client.CreateEmployee(empId, empName);
                            if (i == 1)
                            {
                                Console.WriteLine("Record Added Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Error! Record not added!");
                            }
                        
                        Console.ReadKey();
                        break;

                    case 2:
                        EmployeeData employee1 = new EmployeeData();
                        EmployeeRemarks employeeRemarks = new EmployeeRemarks();
                        employeeRemarks.GetDateTime = DateTime.Now;
                        Console.WriteLine("\n");
                        Console.WriteLine("*** Adding Remark ***");
                        Console.WriteLine("Enter Employee Id : ");
                        empId = Console.ReadLine();

                        employee1 = client1.SearchById(empId);
                        if (employee1 == null)
                        {
                            Console.WriteLine("Record not found");
                        }
                        else
                        {
                            Console.WriteLine("Enter Employee Remark : ");
                            empRemark = Console.ReadLine();
                            EmployeeRemarks getRemark = client.EmployeeRemark(empId, empRemark);
                            if (getRemark!=null)
                            {
                                
                                Console.WriteLine("Remark Added Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Error! Remark not added!");
                            }
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("\n");
                        Console.WriteLine("*** Deleting a Record ***");
                        Console.WriteLine("Enter Employee Id : ");
                        empId = Console.ReadLine();
                        int k = client.DeleteEmployee(empId);
                        if (k == 1)
                        {
                            Console.WriteLine("Deleted Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Error! Record not deleted!");
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        EmployeeData employee = new EmployeeData();
                        Console.WriteLine("\n");
                        Console.WriteLine("*** Search for a Record ***");
                        Console.WriteLine("1.Search by ID");
                        Console.WriteLine("2.Search by Name");
                        search = Console.ReadLine();
                     
                        if (search == "1")
                        {
                            Console.WriteLine("Enter Employee Id : ");
                            empId = Console.ReadLine();
                            employee = client1.SearchById(empId);
                            if (employee == null)
                            {
                                Console.WriteLine("Record not found");
                            }
                            else
                            {
                                Console.WriteLine("*** Details ***");
                                Console.WriteLine("Employee ID : " + employee.EmployeeId);
                                Console.WriteLine("Employee Name : " + employee.EmployeeName);
                            }
                        }
                        else if (search == "2")
                        {
                            Console.WriteLine("Enter Employee Name : ");
                            empName = Console.ReadLine();
                            employee = client1.SearchByName(empName);
                            if (employee == null)
                            {
                                Console.WriteLine("Record not found");
                            }
                            else
                            {
                                Console.WriteLine("*** Details ***");
                                Console.WriteLine("Employee ID : " + employee.EmployeeId);
                                Console.WriteLine("Employee Name : " + employee.EmployeeName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        break;

                    case 5:
                        EmployeeRemarks employeeRemarks1 = new EmployeeRemarks();       
                        string employeeName;
                        Console.WriteLine("\n");
                        Console.WriteLine("1.Get all employee details");
                        Console.WriteLine("2.Get all empoyee details having remarks");
                        details = Console.ReadLine();
                        if (details == "1")
                        {
                            employeeList = client1.GetAllEmployees();
                            foreach (EmployeeData data in employeeList)
                            {
                                Console.WriteLine("\n");
                                Console.WriteLine("Employee ID : " + data.EmployeeId);
                                Console.WriteLine("Employee Name : " + data.EmployeeName);
                                List<EmployeeRemarks> list1 = client1.GetEmployeeRemarkFromId(data.EmployeeId);
                   
                                foreach (EmployeeRemarks emp in list1)
                                {
                                    Console.WriteLine("Employee Remark : " + emp.EmployeeRemark);
                                    Console.WriteLine("Remark added on : " + emp.GetDateTime);
                                }                              
                            }
                        }
                        else if (details == "2")
                        {
                            employeeRemarksList = client1.GetAllEmployeeRemarks();
                            foreach (EmployeeRemarks data in employeeRemarksList)
                            {
                                Console.WriteLine("\n");
                                Console.WriteLine("Employee ID : " + data.EmployeeId);
                                employeeName = client1.GetEmployeeNameFromId(data.EmployeeId);
                                Console.WriteLine("Employee Name : " + employeeName);
                                List<EmployeeRemarks> list1 = client1.GetEmployeeRemarkFromId(data.EmployeeId);

                                foreach (EmployeeRemarks emp in list1)
                                {
                                    Console.WriteLine("Employee Remark : " + emp.EmployeeRemark);
                                    Console.WriteLine("Remark added on : " + emp.GetDateTime);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        break;
                }
            } while (ch1 != 6);
        }
    }
}
