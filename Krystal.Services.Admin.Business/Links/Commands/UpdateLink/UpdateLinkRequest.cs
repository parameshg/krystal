using System;

namespace Krystal.Services.Admin.Business.Links.Commands.UpdateLink
{
    public class UpdateLinkRequest : Request<UpdateLinkResponse>
    {
        public Guid Id { get; set; }

        public bool Enabled { get; set; }

        public string Slug { get; set; }

        public string Url { get; set; }

        public DateTime? Expiry { get; set; }
    }
}