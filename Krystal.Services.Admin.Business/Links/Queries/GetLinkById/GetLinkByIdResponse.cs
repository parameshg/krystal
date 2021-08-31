using Krystal.Services.Admin.Domain.Entities;

namespace Krystal.Services.Admin.Business.Links.Queries.GetLinkById
{
    public class GetLinkByIdResponse : Response
    {
        public Link Link { get; set; }
    }
}