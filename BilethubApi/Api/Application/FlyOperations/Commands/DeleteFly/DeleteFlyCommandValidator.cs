using FluentValidation;

namespace BilethubApi.Api.Application.ArtistOperations.Commands.DeleteArtist;

public class DeleteArtistCommandValidator : AbstractValidator<DeleteArtistCommand>
{
    public DeleteArtistCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}