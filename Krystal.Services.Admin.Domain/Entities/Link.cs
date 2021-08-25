using System;

namespace Krystal.Services.Admin.Domain.Entities
{
    public class Link
    {
        public Guid Id { get; set; }

        public bool Enabled { get; set; }

        public string Slug { get; set; }

        public string Url { get; set; }

        public DateTime? Expiry { get; set; }
    }
}