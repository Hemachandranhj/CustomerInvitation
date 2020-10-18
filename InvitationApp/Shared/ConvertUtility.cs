namespace InvitationApp.Shared
{
    using System;

    /// <summary>
    /// Convert utility classes to hold common conversion methods
    /// </summary>
    public class ConvertUtility : IConvertUtility
    {
        public double DegreesToRadian(double degree)
        {
            var radian = degree * (Math.PI / 180);

            return radian;
        }
    }
}
