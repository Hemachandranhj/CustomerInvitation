using InvitationApp.CustomerInvitation;

namespace InvitationApp
{
    using InvitationApp.FileLoader;
    using InvitationApp.Formulae;
    using InvitationApp.Shared;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    /// <summary>
    /// Application start up class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method that executes first
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Customer Invitation Application!");
            Console.WriteLine("Please enter the GPS coordinates as {latitude},{longitude}. e.g. 53.339428,-6.257664");

            var gpsCoordinates = Console.ReadLine();
            
            Console.WriteLine("Please enter the distance in km..");
            
            var maximumDistance = Convert.ToInt32(Console.ReadLine());
            var serviceProvider = AddDependencyInjection();
            var calculateDistance = serviceProvider.GetService<ICustomerInvitationHelper>();

            // Find the customers within the given distance
            var customerList = calculateDistance.FindCustomersWithinDistance(gpsCoordinates, maximumDistance);
            
            // write results into the output file
            calculateDistance.GenerateResults(customerList);
            Console.ReadLine();
        }

        /// <summary>
        /// Register and configure all dependency classes
        /// </summary>
        /// <returns></returns>
        private static ServiceProvider AddDependencyInjection()
        {
            return new ServiceCollection()
                .AddSingleton<IDataLoader, DataLoader>()
                .AddSingleton<ICustomerInvitationHelper, CustomerInvitationHelper>()
                .AddSingleton<IDistance, GreatCircleDistance>()
                .AddSingleton<IConvertUtility, ConvertUtility>()
                .BuildServiceProvider();
        }
    }
}
