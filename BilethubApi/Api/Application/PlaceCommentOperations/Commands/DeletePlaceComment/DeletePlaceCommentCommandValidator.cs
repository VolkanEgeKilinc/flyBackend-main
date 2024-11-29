using FluentValidation;

namespace BilethubApi.Api.Application.PlaceCommentOperations.Commands.DeletePlaceComment;

public class DeletePlaceCommentCommandValidator : AbstractValidator<DeletePlaceCommentCommand>
{
    public DeletePlaceCommentCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}