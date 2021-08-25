using System;

namespace Krystal.Services.Admin.Domain.Events
{
    public class LinkExpiredEvent
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string Slug { get; set; }
    }
}