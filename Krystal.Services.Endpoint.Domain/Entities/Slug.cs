namespace Krystal.Services.Endpoint.Domain.Entities
{
    public class Slug
    {
        public string Id { get; set; }

        public bool Enabled { get; set; }

        public string Url { get; set; }

        public bool Expired { get; set; }
    }
}