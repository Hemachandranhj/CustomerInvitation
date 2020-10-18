namespace InvitationApp.Tests.FileLoader
{
    using InvitationApp.FileLoader;
    using Microsoft.VisualBasic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class DataLoaderTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadWithInvalidValueReturnsException()
        {
            var dataLoader = new DataLoader();
            dataLoader.Read(null);
        }

        [TestMethod]
        public void ReadWithValidValueReturnsResponse()
        {
            var filePath = Shared.Constants.InputFilePath;
            var dataLoader = new DataLoader();
            var customerDetailList = dataLoader.Read(filePath);

            // Assert all the lines are loaded in the list
            Assert.IsNotNull(customerDetailList);
            Assert.AreEqual(32, customerDetailList.Count);
        }
    }
}
