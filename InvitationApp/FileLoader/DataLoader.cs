namespace InvitationApp.FileLoader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using InvitationApp.Models;
    using InvitationApp.Shared;
    using Newtonsoft.Json;

    /// <summary>
    /// DataLoader class to read and write results into the file
    /// </summary>
    public class DataLoader : IDataLoader
    {
        /// <summary>
        /// Reads the data from the file
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <returns></returns>
        public IList<CustomerDetail> Read(string inputFilePath)
        {
            if (string.IsNullOrEmpty(inputFilePath))
            {
                throw new ArgumentNullException("File path not provided");
            }

            var customerDetailList = new List<CustomerDetail>();
            var lines = File.ReadAllLines(inputFilePath);
            
            foreach(var line in lines)
            {
                var customerDetail = JsonConvert.DeserializeObject<CustomerDetail>(line);
                customerDetailList.Add(customerDetail);
            }

            return customerDetailList;
        }

        /// <summary>
        /// Writes the data into the file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="outputFilePath"></param>
        public void Write(string data, string outputFilePath)
        {
            if (string.IsNullOrEmpty(outputFilePath))
            {
                throw new Exception("File path not provided");
            }

            File.WriteAllText(outputFilePath, data.FormatJson());
        }
    }
}
