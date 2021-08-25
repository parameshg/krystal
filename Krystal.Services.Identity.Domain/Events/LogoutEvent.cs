using System;

namespace Krystal.Services.Identity.Domain.Events
{
    public class LogoutEvent
    {
        public Guid User { get; set; }
    }
}