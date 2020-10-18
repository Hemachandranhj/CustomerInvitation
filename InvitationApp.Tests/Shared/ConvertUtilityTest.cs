namespace InvitationApp.Tests
{
    using InvitationApp.Shared;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Validate degree to radian test method class
    /// I have used https://www.rapidtables.com/convert/number/degrees-to-radians.html to validate expected results
    /// </summary>
    [TestClass]
    public class ConvertUtilityTest
    {
        [TestMethod]
        public void DegreesToRadianTestZeroDegreeReturnsResponse()
        {
            var convertUtility = new ConvertUtility();
            var response = convertUtility.DegreesToRadian(0);

            Assert.AreEqual(0, response);
        }

        [TestMethod]
        public void DegreesToRadianTestWithPositiveDegreeReturnsResponse()
        {
            var convertUtility = new ConvertUtility();
            var response = convertUtility.DegreesToRadian(53.43333);

            Assert.AreEqual(0.9325875388046616, response);
        }

        [TestMethod]
        public void DegreesToRadianTestWithNegativeDegreeReturnsResponse()
        {
            var convertUtility = new ConvertUtility();
            var response = convertUtility.DegreesToRadian(-6.12333);

            Assert.AreEqual(-0.10687226968614438, response);
        }
    }
}
