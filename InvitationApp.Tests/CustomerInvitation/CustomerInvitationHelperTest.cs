namespace InvitationApp.Tests.CustomerInvitation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using InvitationApp.CustomerInvitation;
    using InvitationApp.FileLoader;
    using InvitationApp.Formulae;
    using InvitationApp.Models;
    using InvitationApp.Shared;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CustomerInvitationHelperTest
    {
        private Mock<IDataLoader> dataLoader;
        private Mock<IDistance> greatCircleDistance;
        private Mock<IConvertUtility> convertUtility;
        private CustomerInvitationHelper underTest;

        [TestInitialize]
        public void TestInitialize() 
        {
            this.dataLoader = new Mock<IDataLoader>();
            this.greatCircleDistance = new Mock<IDistance>();
            this.convertUtility = new Mock<IConvertUtility>();
            this.underTest = new CustomerInvitationHelper(dataLoader.Object, greatCircleDistance.Object, convertUtility.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindCustomersWithinDistanceWithInvalidCoordinatesReturnsException()
        {
            this.underTest.FindCustomersWithinDistance(null, 300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindCustomersWithinDistanceWithInvalidDistanceReturnsException()
        {
            this.underTest.FindCustomersWithinDistance("53.339428, -6.257664", -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindCustomersWithinDistanceWithInvalidEdgeCaseDistanceReturnsException()
        {
            this.underTest.FindCustomersWithinDistance("53.339428, -6.257664", 0);
        }

        [TestMethod]
        public void FindCustomersWithinDistanceWithValidInputReturnsResponse()
        {
            this.MockTestData();
            var actualResponse = this.underTest.FindCustomersWithinDistance("53.339428, -6.257664", 80);

            // Validate the response and the order of the customer list based on user id
            Assert.IsNotNull(actualResponse);
            Assert.AreEqual(3, actualResponse.Count);
            Assert.AreEqual(10, actualResponse.First().UserId);
            Assert.AreEqual(14, actualResponse.Last().UserId);
        }

        private void MockTestData()
        {
            this.dataLoader.Setup(x => x.Read(It.IsAny<string>())).Returns(CreateCustomerDetailList());
            this.greatCircleDistance.Setup(x => x.CalculateDistance(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<double>())).Returns(49);
            this.convertUtility.Setup(x => x.DegreesToRadian(It.IsAny<double>())).Returns(0.9090909);
        }

        private IList<CustomerDetail> CreateCustomerDetailList()
        {
            var customerDetailList = new List<CustomerDetail>
            {
                new CustomerDetail()
                {
                    UserId = 14, Latitude = 53.222333, Longitude = -0.622323, Name = "TestCustomerOne"
                },
                new CustomerDetail()
                {
                    UserId = 10, Latitude = 50.522333, Longitude = -0.842323, Name = "TestCustomerTwo"
                },
                new CustomerDetail()
                {
                    UserId = 12, Latitude = 55.122333, Longitude = -0.321323, Name = "TestCustomerThree"
                }
            };

            return customerDetailList;
        }
    }
}
