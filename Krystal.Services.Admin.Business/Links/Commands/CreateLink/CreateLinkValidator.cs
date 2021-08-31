using FluentValidation;

namespace Krystal.Services.Admin.Business.Links.Commands.CreateLink
{
    public class CreateLinkValidator : Validator<CreateLinkRequest>
    {
        public CreateLinkValidator()
        {
            RuleFor(i => i.Slug).NotEmpty();

            RuleFor(i => i.Url).NotEmpty();
        }
    }
}