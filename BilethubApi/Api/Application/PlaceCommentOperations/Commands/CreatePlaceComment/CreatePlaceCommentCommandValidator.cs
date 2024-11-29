using FluentValidation;

namespace BilethubApi.Api.Application.PlaceCommentOperations.Commands.CreatePlaceComment;

public class CreatePlaceCommentCommandValidator : AbstractValidator<CreatePlaceCommentCommand>
{
    public CreatePlaceCommentCommandValidator()
    {
        RuleFor(command => command.Model.UserId).GreaterThan(0);
        RuleFor(command => command.Model.PlaceId).GreaterThan(0);
        RuleFor(command => command.Model.Content).MinimumLength(2).MaximumLength(255);
    }
}