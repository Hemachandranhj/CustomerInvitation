namespace InvitationApp.Formulae
{
    using System;

    /// <summary>
    /// Great cirlce distance class to calculate distance between two points
    /// </summary>
    public class GreatCircleDistance : IDistance
    {
        private readonly double earthRadius = 6371; // radius of the earth in km

        public double CalculateDistance(
            double sourceLattitude,
            double destinationLattitude,
            double absoluteLongitudeDiff)
        {
            var centralAngle = Math.Acos((Math.Sin(sourceLattitude) * Math.Sin(destinationLattitude))
                    + (Math.Cos(sourceLattitude) * Math.Cos(destinationLattitude) * Math.Cos(absoluteLongitudeDiff)));

            var distance = earthRadius * centralAngle;

            return distance;
        }
    }
}
