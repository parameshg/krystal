using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using MediatR;

namespace Krystal.Services.Admin.Business
{
    public interface IHandler
    {
    }

    public abstract class Handler : IHandler
    {
        protected IMediator Mediator { get; private set; }

        public Handler(IMediator mediator)
        {
            Mediator = EnsureArg.IsNotNull(mediator);
        }
    }

    public abstract class Handler<T> : INotificationHandler<T>, IHandler where T : INotification
    {
        protected IMediator Mediator { get; private set; }

        public Handler(IMediator mediator)
        {
            Mediator = EnsureArg.IsNotNull(mediator);
        }

        protected abstract Task Execute(T request, CancellationToken token);

        async Task INotificationHandler<T>.Handle(T request, CancellationToken token)
        {
            await Execute(request, token);
        }
    }

    public abstract class Handler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>, IHandler where TRequest : IRequest<TResponse>
    {
        protected IMediator Mediator { get; private set; }

        public Handler(IMediator mediator)
        {
            Mediator = EnsureArg.IsNotNull(mediator);
        }

        protected abstract Task<TResponse> Execute(TRequest request, CancellationToken token);

        public async Task<TResponse> Handle(TRequest request, CancellationToken token)
        {
            return await Execute(request, token);
        }
    }
}