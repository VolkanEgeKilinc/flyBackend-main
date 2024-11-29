using FluentValidation;

namespace BilethubApi.Api.Application.ArtistOperations.Commands.CreateArtist;

public class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommand>{

    public CreateArtistCommandValidator(){
        RuleFor(command => command.Model.Image).NotNull();
        RuleFor(command => command.Model.Name).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Surname).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Description).MinimumLength(3).MaximumLength(255);
    }
}