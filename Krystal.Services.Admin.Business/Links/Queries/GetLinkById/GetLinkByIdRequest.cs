using System;

namespace Krystal.Services.Admin.Business.Links.Queries.GetLinkById
{
    public class GetLinkByIdRequest : Request<GetLinkByIdResponse>
    {
        public Guid Id { get; set; }
    }
}