using System;

namespace Krystal.Services.Analytics.Domain
{
    public class Redirection
    {
        public Guid Id { get; set; }

        public Guid User { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}