using System;

namespace Krystal.Services.Admin.Domain.Events
{
    public class LinkDeletedEvent
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string Slug { get; set; }
    }
}