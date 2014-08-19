using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcgAssgn
{
    [ServiceContract]
    public interface ICreateEmployeeAddRemarks
    {
        [OperationContract]
        int CreateEmployee(string empId, string empName);

        [OperationContract]
        int EmployeeRemark(string empId,string remark);

        [OperationContract]
        int DeleteEmployee(string empId);
    }


    [ServiceContract]
    public interface ICreateEmployeeDetails
    {
        [OperationContract]
        IEnumerable<EmployeeData> GetAllEmployees();

        [OperationContract]
        EmployeeData SearchById(string empId);

        [OperationContract]
        EmployeeData SearchByName(string empName);
    }



    [DataContract]
    public class EmployeeData
    {
        [DataMember]
        public string employeeName { get; set; }

        [DataMember]
        public string employeeRemark { get; set; }

        [DataMember]
        public string employeeId { get; set; }

        [DataMember]
        public DateTime getDateTime {  get; set; }
    }
}
