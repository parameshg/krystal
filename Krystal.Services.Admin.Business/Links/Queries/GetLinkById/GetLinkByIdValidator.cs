using FluentValidation;

namespace Krystal.Services.Admin.Business.Links.Queries.GetLinkById
{
    public class GetLinkByIdValidator : Validator<GetLinkByIdRequest>
    {
        public GetLinkByIdValidator()
        {
            RuleFor(i => i.Id).NotEmpty();
        }
    }
}