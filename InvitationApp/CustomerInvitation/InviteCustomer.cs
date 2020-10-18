namespace InvitationApp.FileLoader
{
    using InvitationApp.Formulae;
    using InvitationApp.Models;
    using InvitationApp.Shared;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InviteCustomer : IInviteCustomer
    {
        private IDataLoader dataLoader;
        private IDistance greatCircleDistance;
        private IConvertUtility convertUtility;

        public InviteCustomer(IDataLoader dataLoader, IDistance greatCircleDistance, IConvertUtility convertUtility)
        {
            this.dataLoader = dataLoader;
            this.greatCircleDistance = greatCircleDistance;
            this.convertUtility = convertUtility;
        }

        public IList<Customer> FindCustomersWithinDistance(string gpsCoordinates, int maximumDistance)
        {
            if (string.IsNullOrEmpty(gpsCoordinates)) {
                throw new ArgumentNullException("GPS Coordinates are mandatory");
            }

            if (maximumDistance <= 0) {
                throw new ArgumentException("Maximum distance should be greater than zero");
            }

            var customerList = new List<Customer>();
            var filePath = Constants.InputFilePath;
            var customerDetailList = dataLoader.Read(filePath);
            var sourceCoordinates = gpsCoordinates.Split(",");

            customerDetailList.ToList().ForEach(x =>
            {
                var sourceLattitude = this.convertUtility.DegreesToRadian(Convert.ToDouble(sourceCoordinates[0]));
                var destinationLattitude = this.convertUtility.DegreesToRadian(x.Latitude);
                var sourceLongitude = this.convertUtility.DegreesToRadian(Convert.ToDouble(sourceCoordinates[1]));
                var destinationLongitude = this.convertUtility.DegreesToRadian(x.Longitude);
                var absoluteLongitudeDiff = Math.Abs(sourceLongitude - destinationLongitude);

                var distance = this.greatCircleDistance.CalculateDistance(
                    sourceLattitude,
                    destinationLattitude,
                    absoluteLongitudeDiff);

                if (distance <= maximumDistance)
                {
                    customerList.Add(new Customer() { UserId = x.UserId, Name = x.Name });
                }
            });

            customerList = customerList.OrderBy(x => x.UserId).ToList();

            return customerList;
        }

        public void GenerateResults(IList<Customer> customerList)
        {
            var jsonString = JsonConvert.SerializeObject(customerList);
            dataLoader.Write(jsonString, Constants.OutputFilePath);
        }
    }
}