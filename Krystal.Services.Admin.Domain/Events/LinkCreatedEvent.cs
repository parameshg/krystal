using System;

namespace Krystal.Services.Admin.Domain.Events
{
    public class LinkCreatedEvent
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string Slug { get; set; }

        public string Url { get; set; }
    }
}