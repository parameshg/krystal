using System;

namespace Krystal.Services.Admin.Business.Links.Commands.CreateLink
{
    public class CreateLinkResponse : Response
    {
        public Guid LinkId { get; set; }

        public bool Created { get; set; }
    }
}