using System;

namespace Krystal.Services.Admin.Business.Links.Queries.GetLinks
{
    public class GetLinksRequest : Request<GetLinksResponse>
    {
        public Guid UserId { get; set; }
    }
}