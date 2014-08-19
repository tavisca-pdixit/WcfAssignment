using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcgAssgn
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]

    public class Service1 : ICreateEmployeeAddRemarks, ICreateEmployeeDetails
    {
        List<EmployeeData> employeeList = new List<EmployeeData>();
        static int i = 0;
        string id,empRemark;

        public int CreateEmployee(string empId, string empName)
        {
            EmployeeData employee = new EmployeeData();
            id = empId.Trim();

            if ((id != null || id != "") && (employeeList.Find(item => item.employeeId == empId)==null))
            {
                employee.employeeId = empId;
                employee.employeeName = empName;
                employeeList.Add(employee);
                i++;
                if (employeeList.Count == i)
                {
                    return 1;
                }
            }
            throw new FaultException(new FaultReason("Employee Id already exist or Employee Id should not be Null"), new FaultCode("102"));
        }

        public int EmployeeRemark(string empId, string remark)
        {
            EmployeeData employee = new EmployeeData();
            empRemark = remark.Trim();
            if (empRemark != "")
            {
                employee = employeeList.Find(item => item.employeeId == empId);
                if (employee != null)
                {
                    employee.employeeRemark = remark;
                    return 1;
                }
            }
            //throw new FaultException(new FaultReason("Employee Id does not exist"), new FaultCode("103"));
            return 0;
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
            return 0;
        }

        public IEnumerable<EmployeeData> GetAllEmployees()
        {
            return employeeList;
            //throw new NotImplementedException();
        }

        public EmployeeData SearchById(string empId)
        {
            EmployeeData employee = new EmployeeData();
            employee = employeeList.Find(item => item.employeeId == empId);
            if (employee != null)
            {
                return employee;
            }
            throw new FaultException(new FaultReason("Employee Id does not exist"), new FaultCode("103"));
        }

        public EmployeeData SearchByName(string empName)
        {
            EmployeeData employee = new EmployeeData();
            employee = employeeList.Find(item => item.employeeName == empName);
            if (employee != null)
            {
                return employee;
            }
            throw new FaultException(new FaultReason("Employee Name does not exist"), new FaultCode("104"));
        }
    }
}
