using System;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using Krystal.Services.Admin.Business.Repositories;
using MediatR;

namespace Krystal.Services.Admin.Business.Links.Commands.UpdateLink
{
    public class UpdateLinkHandler : Handler<UpdateLinkRequest, UpdateLinkResponse>
    {
        private ILinkRepository Repository { get; }

        public UpdateLinkHandler(IMediator mediator, ILinkRepository repository)
            : base(mediator)
        {
            Repository = EnsureArg.IsNotNull(repository);
        }

        protected override async Task<UpdateLinkResponse> Execute(UpdateLinkRequest request, CancellationToken token)
        {
            var result = new UpdateLinkResponse();

            result.Updated = await Repository.UpdateLink(request.Id, request.Enabled, request.Slug, request.Url, request.Expiry);

            return result;
        }
    }
}