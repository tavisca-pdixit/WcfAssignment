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
        List<EmployeeRemarks> employeeRemarksList = new List<EmployeeRemarks>();
        static int i = 0;
        string id,empRemark;

        public int CreateEmployee(string empId, string empName)
        {
            EmployeeData employee = new EmployeeData();
            id = empId.Trim();

            if (employeeList.Find(item => item.EmployeeId == empId)==null)
            {
                employee.EmployeeId = empId;
                employee.EmployeeName = empName;
                employeeList.Add(employee);
                i++;
                if (employeeList.Count == i)
                {
                    return 1;
                }
            }
            throw new FaultException(new FaultReason("Employee Id already exist or Employee Id should not be Null"), new FaultCode("102"));
        }

        public EmployeeRemarks EmployeeRemark(string empId, string remark)
        {
            EmployeeData employee = new EmployeeData();
            EmployeeRemarks employeeRemark = new EmployeeRemarks();
            empRemark = remark.Trim();
            if (empRemark != "")
            {
                employee = employeeList.Find(item => item.EmployeeId == empId);
                if (employee != null)
                {
                    employeeRemark.EmployeeId = empId;
                    employeeRemark.EmployeeRemark = remark;
                    employeeRemark.GetDateTime = DateTime.Now;
                    employeeRemarksList.Add(employeeRemark);
                    return employeeRemark;
                }
            }
            //throw new FaultException(new FaultReason("Employee Id does not exist"), new FaultCode("103"));
            return null;
        }


        public string GetEmployeeNameFromId(string empId)
        {
            EmployeeData employeeData = new EmployeeData();
            foreach (EmployeeData emp in employeeList)
            {
                if (emp.EmployeeId.Equals(empId))
                    return emp.EmployeeName;
            }
            return null;
        }

        public IEnumerable<EmployeeRemarks> GetEmployeeRemarkFromId(string empId)
        {
            return employeeRemarksList.Where(remark => remark.EmployeeId == empId).ToList();
        }

        public int DeleteEmployee(string empId)
        {
            EmployeeData employee = new EmployeeData();
            employee = employeeList.Find(item => item.EmployeeId == empId);
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

        public IEnumerable<EmployeeRemarks> GetAllEmployeeRemarks()
        {
            return employeeRemarksList;
            //throw new NotImplementedException();
        }

        public EmployeeData SearchById(string empId)
        {
            EmployeeData employee = new EmployeeData();
            employee = employeeList.Find(item => item.EmployeeId == empId);
            if (employee != null)
            {
                return employee;
            }
            throw new FaultException(new FaultReason("Employee Id does not exist"), new FaultCode("103"));
        }

        public EmployeeData SearchByName(string empName)
        {
            EmployeeData employee = new EmployeeData();
            employee = employeeList.Find(item => item.EmployeeName == empName);
            if (employee != null)
            {
                return employee;
            }
            throw new FaultException(new FaultReason("Employee Name does not exist"), new FaultCode("104"));
        }
    }
}
