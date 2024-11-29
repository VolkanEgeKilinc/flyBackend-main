using FluentValidation;

namespace BilethubApi.Api.Application.ArtistFollowerOperations.Commands.DeleteArtistFollower;

public class DeleteArtistFollowerCommandValidator : AbstractValidator<DeleteArtistFollowerCommand>
{
    public DeleteArtistFollowerCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.UserId).GreaterThan(0);
    }
}