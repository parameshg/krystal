using System;

namespace Krystal.Services.Admin.Models
{
    public class Link
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public DateTime? Expiry { get; set; }
    }
}