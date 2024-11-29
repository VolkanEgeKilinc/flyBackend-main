using FluentValidation;

namespace BilethubApi.Api.Application.ArtistCommentOperations.Commands.DeleteArtistComment;

public class DeleteArtistCommentCommandValidator : AbstractValidator<DeleteArtistCommentCommand>
{
    public DeleteArtistCommentCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}