using System;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using Krystal.Services.Admin.Business.Repositories;
using MediatR;

namespace Krystal.Services.Admin.Business.Links.Commands.CreateLink
{
    public class CreateLinkHandler : Handler<CreateLinkRequest, CreateLinkResponse>
    {
        private ILinkRepository Repository { get; }

        public CreateLinkHandler(IMediator mediator, ILinkRepository repository)
            : base(mediator)
        {
            Repository = EnsureArg.IsNotNull(repository);
        }

        protected override async Task<CreateLinkResponse> Execute(CreateLinkRequest request, CancellationToken token)
        {
            var result = new CreateLinkResponse();

            if (request.UserId.HasValue)
            {
                var id = await Repository.CreateLink(request.UserId.Value, request.Enabled, request.Slug, request.Url, request.Expiry);

                result.LinkId = id;

                result.Created = id != Guid.NewGuid();
            }

            return result;
        }
    }
}