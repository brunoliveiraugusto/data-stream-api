namespace DataStream.API.Infra.Settings
{
    public record ConnectionStringSetting
    {
        public required string DefaultConnection { get; set; }
    }
}
