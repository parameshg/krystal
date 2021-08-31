using System;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using Krystal.Services.Admin.Business.Repositories;
using MediatR;

namespace Krystal.Services.Admin.Business.Links.Queries.GetLinkById
{
    public class GetLinkByIdHandler : Handler<GetLinkByIdRequest, GetLinkByIdResponse>
    {
        private ILinkRepository Repository { get; }

        public GetLinkByIdHandler(IMediator mediator, ILinkRepository repository)
            : base(mediator)
        {
            Repository = EnsureArg.IsNotNull(repository);
        }

        protected override async Task<GetLinkByIdResponse> Execute(GetLinkByIdRequest request, CancellationToken token)
        {
            var result = new GetLinkByIdResponse();

            result.Link = await Repository.GetLinkById(request.Id);

            return result;
        }
    }
}