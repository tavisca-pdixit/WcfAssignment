using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcgAssgn;
using ServerFixture.MyService;
using System.ServiceModel;
using System.Diagnostics;

namespace ServerFixture
{
    [TestClass]
    public class Tests
    {
        const string _dataSourcePath = @"D:\NewWcf\WcfAssignment\WcfAssgn\WcgAssgn\TestData.xml";
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        CreateEmployeeAddRemarksClient client = new CreateEmployeeAddRemarksClient();
        CreateEmployeeDetailsClient client1 = new CreateEmployeeDetailsClient();

        [TestMethod]
        [DeploymentItem(_dataSourcePath)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", _dataSourcePath, "Employee", DataAccessMethod.Sequential)]
        public void AddNewEmployee()
        {
            string id = testContextInstance.DataRow["EmpId"].ToString();
            string name = testContextInstance.DataRow["EmpName"].ToString(); 

            try
            {
                client.CreateEmployee(id,name);
                //client.CreateEmployee("2", "Vaish");
            }
            catch (FaultException ex)
            {
                Assert.AreEqual(2, client1.GetAllEmployees().Length);
            }
        }

        [TestMethod]
        public void EmployeeIdAlreadyExists()
        {
            try
            {
                client.CreateEmployee("3", "Shivangi");
                client.CreateEmployee("3", "Vaish");
            }
            catch (FaultException ex)
            {
                Assert.AreEqual(3, client1.GetAllEmployees().Length);
            }
        }

        [TestMethod]
        public void EmployeeIdShouldNotBeNull()
        {

            try
            {
                client.CreateEmployee("8", "Vaish");
                client.CreateEmployee("", "Shivangi");

            }
            catch (FaultException ex)
            {
                Assert.AreEqual(4, client1.GetAllEmployees().Length);
            }
        }

        [TestMethod]
        public void AddRemarkForExistingEmployee()
        {
            EmployeeRemarks remark;
            remark = client.EmployeeRemark("8", "Good");
            Assert.AreEqual("Good", remark.EmployeeRemark);
        }

        [TestMethod]
        public void AddRemarkForNonExistingEmployee()
        {
            EmployeeRemarks remark1;
            remark1=client.EmployeeRemark("7", "Good");
            Assert.AreEqual(null, remark1);
        }

        [TestMethod]
        public void AddBlankRemarkForExistingEmployee()
        {
            EmployeeRemarks remark;
            remark = client.EmployeeRemark("3", " ");
            Assert.AreEqual(null, remark);
        }

        [TestMethod]
        public void DeleteExistingEmployee()
        {
            int deleteEmployee;
            deleteEmployee=client.DeleteEmployee("1");
            Assert.AreEqual(1, deleteEmployee);
        }

        [TestMethod]
        public void DeleteNonExistingEmployee()
        {
            int deleteEmployee1;
            deleteEmployee1 = client.DeleteEmployee("5");
            Assert.AreEqual(0, deleteEmployee1);
        }

        [TestMethod]
        public void SearchExistingEmployeeById()
        {
            EmployeeData searchId = null;
            searchId = client1.SearchById("8");
            Assert.IsNotNull(searchId);
        }

        [TestMethod]
        public void SearchNonExistingEmployeeById()
        {
            EmployeeData searchId = null;
            try
            {
                searchId = client1.SearchById("9");
                Assert.IsNotNull(searchId);
            }
            catch (Exception ex)
            {
                Assert.IsNull(searchId);
            }
        }

        [TestMethod]
        public void SearchExistingEmployeeByName()
        {
            EmployeeData searchName = null;
            searchName = client1.SearchByName("Shivangi");
            Assert.IsNotNull(searchName);
        }

        [TestMethod]
        public void SearchNonExistingEmployeeByName()
        {
            EmployeeData searchName = null;
            try
            {
                searchName = client1.SearchById("Abhijeet");
                Assert.IsNotNull(searchName);
            }
            catch (Exception ex)
            {
                Assert.IsNull(searchName);
            }
        }
    }
}
