using System.Collections.Generic;
using Krystal.Services.Admin.Domain.Entities;

namespace Krystal.Services.Admin.Business.Links.Queries.GetLinks
{
    public class GetLinksResponse : Response
    {
        public List<Link> Links { get; set; } = new List<Link>();
    }
}