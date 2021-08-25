using System;

namespace Krystal.Services.Endpoint.Domain.Events
{
    public class RedirectionEvent
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string Slug { get; set; }

        public string Url { get; set; }

        public string IpAddress { get; set; }
    }
}