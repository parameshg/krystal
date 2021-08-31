using System;

namespace Krystal.Services.Admin.Business.Links.Commands.DeleteLink
{
    public class DeleteLinkRequest : Request<DeleteLinkResponse>
    {
        public Guid LinkId { get; set; }
    }
}