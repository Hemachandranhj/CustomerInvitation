namespace InvitationApp.FileLoader
{
    using InvitationApp.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Interface to hold Invite customer methods
    /// </summary>
    public interface IInviteCustomer
    {
        IList<Customer> FindCustomersWithinDistance(string gpsCoordinates, int maximumDistane);

        void GenerateResults(IList<Customer> customerList);
    }
}
