namespace InvitationApp.CustomerInvitation
{
    using System.Collections.Generic;
    using InvitationApp.Models;

    /// <summary>
    /// Interface to hold Invite customer methods
    /// </summary>
    public interface ICustomerInvitationHelper
    {
        IList<Customer> FindCustomersWithinDistance(string gpsCoordinates, int maximumDistance);

        void GenerateResults(IList<Customer> customerList);
    }
}
