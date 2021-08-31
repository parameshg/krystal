using FluentValidation;

namespace Krystal.Services.Admin.Business
{
    public abstract class Validator<T> : AbstractValidator<T>
    {
        protected Validator()
        {
        }
    }
}