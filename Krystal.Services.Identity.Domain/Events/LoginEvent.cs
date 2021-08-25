using System;

namespace Krystal.Services.Identity.Domain.Events
{
    public class LoginEvent
    {
        public Guid User { get; set; }
    }
}