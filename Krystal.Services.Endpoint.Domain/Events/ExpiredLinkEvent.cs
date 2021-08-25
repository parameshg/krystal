using System;

namespace Krystal.Services.Endpoint.Domain.Events
{
    public class ExpiredLinkEvent
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string Slug { get; set; }
    }
}