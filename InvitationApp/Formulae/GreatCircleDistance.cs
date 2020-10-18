namespace InvitationApp.Formulae
{
    using System;

    /// <summary>
    /// Great-circle distance class to calculate distance between two points
    /// </summary>
    public class GreatCircleDistance : IDistance
    {
        private readonly double earthRadius = 6371; // radius of the earth in km

        public double CalculateDistance(
            double sourceLatitude,
            double destinationLatitude,
            double absoluteLongitudeDiff)
        {
            var centralAngle = Math.Acos((Math.Sin(sourceLatitude) * Math.Sin(destinationLatitude))
                    + (Math.Cos(sourceLatitude) * Math.Cos(destinationLatitude) * Math.Cos(absoluteLongitudeDiff)));

            var distance = earthRadius * centralAngle;

            return distance;
        }
    }
}
