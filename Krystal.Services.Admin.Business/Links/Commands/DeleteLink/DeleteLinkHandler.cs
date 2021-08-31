using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using Krystal.Services.Admin.Business.Repositories;
using MediatR;

namespace Krystal.Services.Admin.Business.Links.Commands.DeleteLink
{
    public class DeleteLinkHandler : Handler<DeleteLinkRequest, DeleteLinkResponse>
    {
        private ILinkRepository Repository { get; }

        public DeleteLinkHandler(IMediator mediator, ILinkRepository repository)
            : base(mediator)
        {
            Repository = EnsureArg.IsNotNull(repository);
        }

        protected override async Task<DeleteLinkResponse> Execute(DeleteLinkRequest request, CancellationToken token)
        {
            var result = new DeleteLinkResponse();

            result.Deleted = await Repository.DeleteLink(request.LinkId);

            return result;
        }
    }
}