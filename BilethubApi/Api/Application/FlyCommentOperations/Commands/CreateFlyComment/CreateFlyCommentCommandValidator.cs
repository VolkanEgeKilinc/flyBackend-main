using FluentValidation;

namespace BilethubApi.Api.Application.ArtistCommentOperations.Commands.CreateArtistComment;

public class CreateArtistCommentCommandValidator : AbstractValidator<CreateArtistCommentCommand>
{
    public CreateArtistCommentCommandValidator()
    {
        RuleFor(command => command.Model.UserId).GreaterThan(0);
        RuleFor(command => command.Model.ArtistId).GreaterThan(0);
        RuleFor(command => command.Model.Content).MinimumLength(2).MaximumLength(255);
    }
}