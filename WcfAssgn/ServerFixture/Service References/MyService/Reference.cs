﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerFixture.MyService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyService.ICreateEmployeeAddRemarks")]
    public interface ICreateEmployeeAddRemarks {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeAddRemarks/CreateEmployee", ReplyAction="http://tempuri.org/ICreateEmployeeAddRemarks/CreateEmployeeResponse")]
        int CreateEmployee(string empId, string empName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeAddRemarks/CreateEmployee", ReplyAction="http://tempuri.org/ICreateEmployeeAddRemarks/CreateEmployeeResponse")]
        System.Threading.Tasks.Task<int> CreateEmployeeAsync(string empId, string empName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeAddRemarks/EmployeeRemark", ReplyAction="http://tempuri.org/ICreateEmployeeAddRemarks/EmployeeRemarkResponse")]
        WcgAssgn.EmployeeRemarks EmployeeRemark(string empId, string remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeAddRemarks/EmployeeRemark", ReplyAction="http://tempuri.org/ICreateEmployeeAddRemarks/EmployeeRemarkResponse")]
        System.Threading.Tasks.Task<WcgAssgn.EmployeeRemarks> EmployeeRemarkAsync(string empId, string remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeAddRemarks/DeleteEmployee", ReplyAction="http://tempuri.org/ICreateEmployeeAddRemarks/DeleteEmployeeResponse")]
        int DeleteEmployee(string empId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeAddRemarks/DeleteEmployee", ReplyAction="http://tempuri.org/ICreateEmployeeAddRemarks/DeleteEmployeeResponse")]
        System.Threading.Tasks.Task<int> DeleteEmployeeAsync(string empId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICreateEmployeeAddRemarksChannel : ServerFixture.MyService.ICreateEmployeeAddRemarks, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateEmployeeAddRemarksClient : System.ServiceModel.ClientBase<ServerFixture.MyService.ICreateEmployeeAddRemarks>, ServerFixture.MyService.ICreateEmployeeAddRemarks {
        
        public CreateEmployeeAddRemarksClient() {
        }
        
        public CreateEmployeeAddRemarksClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CreateEmployeeAddRemarksClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateEmployeeAddRemarksClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateEmployeeAddRemarksClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CreateEmployee(string empId, string empName) {
            return base.Channel.CreateEmployee(empId, empName);
        }
        
        public System.Threading.Tasks.Task<int> CreateEmployeeAsync(string empId, string empName) {
            return base.Channel.CreateEmployeeAsync(empId, empName);
        }
        
        public WcgAssgn.EmployeeRemarks EmployeeRemark(string empId, string remark) {
            return base.Channel.EmployeeRemark(empId, remark);
        }
        
        public System.Threading.Tasks.Task<WcgAssgn.EmployeeRemarks> EmployeeRemarkAsync(string empId, string remark) {
            return base.Channel.EmployeeRemarkAsync(empId, remark);
        }
        
        public int DeleteEmployee(string empId) {
            return base.Channel.DeleteEmployee(empId);
        }
        
        public System.Threading.Tasks.Task<int> DeleteEmployeeAsync(string empId) {
            return base.Channel.DeleteEmployeeAsync(empId);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyService.ICreateEmployeeDetails")]
    public interface ICreateEmployeeDetails {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/GetAllEmployees", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/GetAllEmployeesResponse")]
        WcgAssgn.EmployeeData[] GetAllEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/GetAllEmployees", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/GetAllEmployeesResponse")]
        System.Threading.Tasks.Task<WcgAssgn.EmployeeData[]> GetAllEmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/GetEmployeeNameFromId", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/GetEmployeeNameFromIdResponse")]
        string GetEmployeeNameFromId(string empId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/GetEmployeeNameFromId", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/GetEmployeeNameFromIdResponse")]
        System.Threading.Tasks.Task<string> GetEmployeeNameFromIdAsync(string empId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/GetEmployeeRemarkFromId", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/GetEmployeeRemarkFromIdResponse")]
        WcgAssgn.EmployeeRemarks[] GetEmployeeRemarkFromId(string empId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/GetEmployeeRemarkFromId", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/GetEmployeeRemarkFromIdResponse")]
        System.Threading.Tasks.Task<WcgAssgn.EmployeeRemarks[]> GetEmployeeRemarkFromIdAsync(string empId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/GetAllEmployeeRemarks", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/GetAllEmployeeRemarksResponse")]
        WcgAssgn.EmployeeRemarks[] GetAllEmployeeRemarks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/GetAllEmployeeRemarks", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/GetAllEmployeeRemarksResponse")]
        System.Threading.Tasks.Task<WcgAssgn.EmployeeRemarks[]> GetAllEmployeeRemarksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/SearchById", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/SearchByIdResponse")]
        WcgAssgn.EmployeeData SearchById(string empId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/SearchById", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/SearchByIdResponse")]
        System.Threading.Tasks.Task<WcgAssgn.EmployeeData> SearchByIdAsync(string empId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/SearchByName", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/SearchByNameResponse")]
        WcgAssgn.EmployeeData SearchByName(string empName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployeeDetails/SearchByName", ReplyAction="http://tempuri.org/ICreateEmployeeDetails/SearchByNameResponse")]
        System.Threading.Tasks.Task<WcgAssgn.EmployeeData> SearchByNameAsync(string empName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICreateEmployeeDetailsChannel : ServerFixture.MyService.ICreateEmployeeDetails, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateEmployeeDetailsClient : System.ServiceModel.ClientBase<ServerFixture.MyService.ICreateEmployeeDetails>, ServerFixture.MyService.ICreateEmployeeDetails {
        
        public CreateEmployeeDetailsClient() {
        }
        
        public CreateEmployeeDetailsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CreateEmployeeDetailsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateEmployeeDetailsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateEmployeeDetailsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WcgAssgn.EmployeeData[] GetAllEmployees() {
            return base.Channel.GetAllEmployees();
        }
        
        public System.Threading.Tasks.Task<WcgAssgn.EmployeeData[]> GetAllEmployeesAsync() {
            return base.Channel.GetAllEmployeesAsync();
        }
        
        public string GetEmployeeNameFromId(string empId) {
            return base.Channel.GetEmployeeNameFromId(empId);
        }
        
        public System.Threading.Tasks.Task<string> GetEmployeeNameFromIdAsync(string empId) {
            return base.Channel.GetEmployeeNameFromIdAsync(empId);
        }
        
        public WcgAssgn.EmployeeRemarks[] GetEmployeeRemarkFromId(string empId) {
            return base.Channel.GetEmployeeRemarkFromId(empId);
        }
        
        public System.Threading.Tasks.Task<WcgAssgn.EmployeeRemarks[]> GetEmployeeRemarkFromIdAsync(string empId) {
            return base.Channel.GetEmployeeRemarkFromIdAsync(empId);
        }
        
        public WcgAssgn.EmployeeRemarks[] GetAllEmployeeRemarks() {
            return base.Channel.GetAllEmployeeRemarks();
        }
        
        public System.Threading.Tasks.Task<WcgAssgn.EmployeeRemarks[]> GetAllEmployeeRemarksAsync() {
            return base.Channel.GetAllEmployeeRemarksAsync();
        }
        
        public WcgAssgn.EmployeeData SearchById(string empId) {
            return base.Channel.SearchById(empId);
        }
        
        public System.Threading.Tasks.Task<WcgAssgn.EmployeeData> SearchByIdAsync(string empId) {
            return base.Channel.SearchByIdAsync(empId);
        }
        
        public WcgAssgn.EmployeeData SearchByName(string empName) {
            return base.Channel.SearchByName(empName);
        }
        
        public System.Threading.Tasks.Task<WcgAssgn.EmployeeData> SearchByNameAsync(string empName) {
            return base.Channel.SearchByNameAsync(empName);
        }
    }
}
