namespace DataStream.API.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
