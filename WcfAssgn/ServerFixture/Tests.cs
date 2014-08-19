using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcgAssgn;
using ServerFixture.MyService;
using System.ServiceModel;

namespace ServerFixture
{
    [TestClass]
    public class Tests
    {
        CreateEmployeeAddRemarksClient client = new CreateEmployeeAddRemarksClient();
        CreateEmployeeDetailsClient client1 = new CreateEmployeeDetailsClient();

        [TestMethod]
        public void AddNewEmployee()
        {
            try
            {
                client.CreateEmployee("1", "Pratiksha");
                client.CreateEmployee("2", "Vaish");
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                Assert.AreEqual(4, client1.GetAllEmployees().Length);
            }
        }

        [TestMethod]
        public void AddRemarkForExistingEmployee()
        {
            int remark;
            remark = client.EmployeeRemark("8", "Good");
            Assert.AreEqual(1,remark);
        }

        [TestMethod]
        public void AddRemarkForNonExistingEmployee()
        {
            int remark1;
            remark1=client.EmployeeRemark("7", "Good");
            Assert.AreEqual(0, remark1);
        }

        [TestMethod]
        public void AddBlankRemarkForExistingEmployee()
        {
            int remark;
            remark = client.EmployeeRemark("3", " ");
            Assert.AreEqual(0, remark);
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
