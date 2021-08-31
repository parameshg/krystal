using MediatR;

namespace Krystal.Services.Admin.Business
{
    public interface IRequest
    {
    }

    public abstract class Request : IRequest, MediatR.IRequest, INotification
    {
    }

    public abstract class Request<T> : IRequest, IRequest<T>
    {
    }
}