namespace InvitationApp.FileLoader
{
    using InvitationApp.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Interface to hold data loader methods
    /// </summary>
    public interface IDataLoader
    {
        IList<CustomerDetail> Read(string inputFilePath);

        void Write(string data, string outputFilePath);
    }
}
