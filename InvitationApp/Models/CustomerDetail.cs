namespace InvitationApp.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Class to hold customer details
    /// </summary>
    public class CustomerDetail : ICustomer
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
