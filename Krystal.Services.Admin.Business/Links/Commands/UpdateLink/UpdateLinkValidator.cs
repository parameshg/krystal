using FluentValidation;

namespace Krystal.Services.Admin.Business.Links.Commands.UpdateLink
{
    public class UpdateLinkValidator : Validator<UpdateLinkRequest>
    {
        public UpdateLinkValidator()
        {
            RuleFor(i => i.Id).NotEmpty();

            RuleFor(i => i.Slug).NotEmpty();

            RuleFor(i => i.Url).NotEmpty();
        }
    }
}