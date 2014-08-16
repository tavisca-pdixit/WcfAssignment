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

            string ch;
            int ch1;

            Console.WriteLine("Enter your choice : ");
            Console.WriteLine("1.Add Record");
            Console.WriteLine("2.Add Remark");
            Console.WriteLine("3.Delete Record");
            Console.WriteLine("4.Search a Record");
            Console.WriteLine("5.Display all Records");
            ch = Console.ReadLine();
            bool parse=Int32.TryParse(ch,out ch1);

            switch (ch1)
            { }

                int i = client.CreateEmployee("1","Pratiksha");
                if (i == 1)
                {
                    Console.WriteLine("Record Added Successfully");
                }
                else
                {
                    Console.WriteLine("Error!");
                }

                int j=client.EmployeeRemark("2","Good");
                if (j == 1)
                {
                    Console.WriteLine("Remark Added Successfully");
                }
                else
                {
                    Console.WriteLine("Error!");
                }

                int k = client.DeleteEmployee("2");
                if (k == 1)
                {
                    Console.WriteLine("Deleted Added Successfully");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
               // employeeList = client1.GetAllEmployees();

                Console.ReadKey();
            
        }
    }
}
