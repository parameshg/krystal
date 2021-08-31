using FluentValidation;

namespace Krystal.Services.Admin.Business.Links.Commands.DeleteLink
{
    public class DeleteLinkValidator : Validator<DeleteLinkRequest>
    {
        public DeleteLinkValidator()
        {
            RuleFor(i => i.LinkId).NotEmpty();
        }
    }
}