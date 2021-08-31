using System;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using Krystal.Services.Admin.Business.Repositories;
using MediatR;

namespace Krystal.Services.Admin.Business.Links.Queries.GetLinks
{
    public class GetLinksHandler : Handler<GetLinksRequest, GetLinksResponse>
    {
        private ILinkRepository Repository { get; }

        public GetLinksHandler(IMediator mediator, ILinkRepository repository)
            : base(mediator)
        {
            Repository = EnsureArg.IsNotNull(repository);
        }

        protected override async Task<GetLinksResponse> Execute(GetLinksRequest request, CancellationToken token)
        {
            var result = new GetLinksResponse();

            result.Links.AddRange(await Repository.GetLinks(request.UserId));

            return result;
        }
    }
}