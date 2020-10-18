namespace InvitationApp.Models
{
    using Newtonsoft.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Customer model
    /// </summary>
    public class Customer : ICustomer
    {
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}