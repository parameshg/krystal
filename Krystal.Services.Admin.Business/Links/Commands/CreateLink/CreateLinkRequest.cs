using System;

namespace Krystal.Services.Admin.Business.Links.Commands.CreateLink
{
    public class CreateLinkRequest : Request<CreateLinkResponse>
    {
        public bool Enabled { get; set; }

        public string Slug { get; set; }

        public string Url { get; set; }

        public DateTime? Expiry { get; set; }
    }
}