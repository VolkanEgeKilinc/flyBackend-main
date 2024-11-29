using FluentValidation;

namespace BilethubApi.Api.Application.ArtistFollowerOperations.Commands.CreateArtistFollower;

public class CreateArtistFollowerCommandValidator : AbstractValidator<CreateArtistFollowerCommand>
{
    public CreateArtistFollowerCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.UserId).GreaterThan(0);
    }
}