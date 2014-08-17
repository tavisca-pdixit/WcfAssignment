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

            string ch,empId,empName,empRemark,search;
            int ch1;
            do
            {
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
                        Console.WriteLine("*** Adding a Record ***");
                        Console.WriteLine("Enter Employee Id : ");
                        empId = Console.ReadLine();

                         employee2 = client1.SearchById(empId);
                         if (employee2 != null)
                         {
                             Console.WriteLine("Employee with the entered ID already exists");
                         }
                         else
                         {
                             Console.WriteLine("Enter Employee Name : ");
                             empName = Console.ReadLine();
                             int i = client.CreateEmployee(empId, empName);
                             if (i == 1)
                             {
                                 Console.WriteLine("Record Added Successfully");
                             }
                             else
                             {
                                 Console.WriteLine("Error!");
                             }
                        }
                        Console.ReadKey();
                        break;

                    case 2:
                        EmployeeData employee1 = new EmployeeData();
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
                            int j = client.EmployeeRemark(empId, empRemark);
                            if (j == 1)
                            {
                                Console.WriteLine("Remark Added Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Error!");
                            }
                        }
                        Console.ReadKey();
                        break;

                    case 3:
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
                            Console.WriteLine("Error!");
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        EmployeeData employee = new EmployeeData();
                        Console.WriteLine("*** Search for a Record ***");
                        Console.WriteLine("1.Search by ID");
                        Console.WriteLine("2.Search by Name");
                        search = Console.ReadLine();
                        //bool parseSearch = Int32.TryParse(ch, out search1);
                        //Console.WriteLine(search1);
                        //switch (search1)
                        if(search=="1")
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
                                Console.WriteLine("Employee ID : " + employee.employeeId);
                                Console.WriteLine("Employee Name : " + employee.employeeName);
                            }
                        }
                        else if(search=="2")
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
                                Console.WriteLine("Employee ID : " + employee.employeeId);
                                Console.WriteLine("Employee Name : " + employee.employeeName);
                            }
                            break;
                        }
                        break;

                    case 5:
                        employeeList = client1.GetAllEmployees();
                        foreach (EmployeeData data in employeeList)
                        {
                            Console.WriteLine(employeeList);
                        }
                        Console.ReadKey();
                        break;
                }
            } while (ch1 != 6);
        }
    }
}
