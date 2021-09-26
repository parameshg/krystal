using EnsureThat;
using Krystal.Services.Admin.Business.Links.Commands.CreateLink;
using Krystal.Services.Admin.Business.Links.Commands.DeleteLink;
using Krystal.Services.Admin.Business.Links.Commands.UpdateLink;
using Krystal.Services.Admin.Business.Links.Queries.GetLinkById;
using Krystal.Services.Admin.Business.Links.Queries.GetLinks;
using Krystal.Services.Admin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Krystal.Services.Admin.Controllers
{
    public class LinkController : ControllerBase
    {
        private IMediator Mediator { get; }

        public LinkController(IMediator mediator)
        {
            Mediator = EnsureArg.IsNotNull(mediator);
        }

        [HttpGet("links")]
        public async Task<List<Link>> GetLinks()
        {
            var result = new List<Link>();

            var response = await Mediator.Send(new GetLinksRequest { UserId = Guid.Empty });

            result.AddRange(response.Links);

            return result;
        }

        [HttpGet("links/{id}")]
        public async Task<Link> GetById(Guid id)
        {
            Link result = null;

            var response = await Mediator.Send(new GetLinkByIdRequest { Id = id });

            result = response.Link;

            return result;
        }

        [HttpPost("links")]
        public async Task<IActionResult> Create([FromBody] Link model)
        {
            IActionResult result = null;

            var response = await Mediator.Send(new CreateLinkRequest { UserId = Guid.Empty, Enabled = model.Enabled, Slug = model.Slug, Url = model.Url, Expiry = model.Expiry });

            if (response.Created)
            {
                var entity = await Mediator.Send(new GetLinkByIdRequest { Id = response.LinkId });

                result = new OkObjectResult(entity.Link);
            }

            if (response.Error)
            {
                result = new BadRequestObjectResult(response.Exception?.Message);
            }

            return result;
        }

        [HttpPut("links/{id}")]
        public async Task<Link> Update(Guid id, [FromBody] Link model)
        {
            Link result = null;

            var response = await Mediator.Send(new UpdateLinkRequest {  Id = model.Id, Enabled = model.Enabled, Slug = model.Slug, Url = model.Url, Expiry = model.Expiry });

            if (response.Updated)
            {
                var entity = await Mediator.Send(new GetLinkByIdRequest { Id = id });

                result = entity.Link;
            }

            return result;
        }

        [HttpDelete("links/{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var result = false;

            var response = await Mediator.Send(new DeleteLinkRequest { LinkId = id });

            result = response.Deleted;

            return result;
        }
    }
}