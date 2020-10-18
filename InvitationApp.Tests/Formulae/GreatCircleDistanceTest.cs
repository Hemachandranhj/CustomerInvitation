namespace InvitationApp.Tests.Formulae
{
    using InvitationApp.Formulae;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    /// <summary>
    /// Validate the great circle distance between two points
    /// I have used https://www.nhc.noaa.gov/gccalc.shtml to validate my test results
    /// Remember you have to pass the latitude and longitude in degrees in the above link but the test method requires radians
    /// </summary>
    [TestClass]
    public class GreatCircleDistanceTest
    {
        [TestMethod]
        public void CalculateDistanceWithValidValueReturnsResponse()
        {
            var greatCircleDistance = new GreatCircleDistance();
            var distance = greatCircleDistance.CalculateDistance(
                0.93094863973045394, 
                0.92478670244641048, 
                0.00373435882744462);

            Assert.AreEqual(42.0, Math.Round(distance));
        }

        [TestMethod]
        public void CalculateDistanceWithValidValueTestCaseTwoReturnsResponse()
        {
            var greatCircleDistance = new GreatCircleDistance();
            var distance = greatCircleDistance.CalculateDistance(
                0.8363973045394,
                0.8244244641048,
                0.0025882744462);

            Assert.AreEqual(77.0, Math.Round(distance));
        }

        [TestMethod]
        public void CalculateDistanceWithValidValueTestCaseThreeReturnsResponse()
        {
            var greatCircleDistance = new GreatCircleDistance();
            var distance = greatCircleDistance.CalculateDistance(
                -0.8363973045394,
                -0.8244244641048,
                -0.0085882744462);

            Assert.AreEqual(85.0, Math.Round(distance));
        }
    }
}
