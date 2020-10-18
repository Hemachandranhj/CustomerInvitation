namespace InvitationApp.Formulae
{
    /// <summary>
    /// Common interface to hold calculate distance method
    /// </summary>
    public interface IDistance
    {
        double CalculateDistance(double sourceLattitude, double destinationLattitude, double absoluteLongitudeDiff);
    }
}
