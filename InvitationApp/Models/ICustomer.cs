namespace InvitationApp.Models
{
    /// <summary>
    /// Interface for customer model
    /// </summary>
    public interface ICustomer
    {
        public int UserId { get; set; }

        public string Name { get; set; }
    }
}
