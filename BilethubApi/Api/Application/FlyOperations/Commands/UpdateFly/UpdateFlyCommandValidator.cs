using FluentValidation;

namespace BilethubApi.Api.Application.ArtistOperations.Commands.UpdateArtist;

public class UpdateArtistCommandValidator : AbstractValidator<UpdateArtistCommand>
{
    public UpdateArtistCommandValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.Model.Image).NotNull();
        RuleFor(command => command.Model.Name).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Surname).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Description).MinimumLength(3).MaximumLength(255);
    }
}