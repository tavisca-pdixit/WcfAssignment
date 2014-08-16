using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcgAssgn
{
    public class Service1 : ICreateEmployeeAddRemarks, ICreateEmployeeDetails
    {
        static List<EmployeeData> employeeList = new List<EmployeeData>();
        static int i = 0;
        
        public int CreateEmployee(string empId,string empName)
        {
            EmployeeData employee = new EmployeeData();
            employee.employeeId = empId;
            employee.employeeName = empName;
            employeeList.Add(employee);
            i++;
            if(employeeList.Count==i)
            {
                return 1;
            }
            else
            {
                return 0;
            }

            throw new FaultException(new FaultReason("Employee Record Not Found For Inserting Remarks"), new FaultCode("102"));
        }

        public int EmployeeRemark(string empId, string remark)
        {
            EmployeeData employee = new EmployeeData();

            employee = employeeList.Find(item => item.employeeId == empId);
            if (employee != null)
            {
                employee.employeeRemark = remark;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int DeleteEmployee(string empId)
        {
            EmployeeData employee = new EmployeeData();
            employee = employeeList.Find(item => item.employeeId == empId);
            if (employee != null)
            {
                employeeList.Remove(employee);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<EmployeeData> GetAllEmployees()
        {
            return employeeList;
            //throw new NotImplementedException();
        }

        public EmployeeData Search(string empId)
        {
            EmployeeData employee = new EmployeeData();
            employee = employeeList.Find(item => item.employeeId == empId);
            return employee;

        }
    }
}
