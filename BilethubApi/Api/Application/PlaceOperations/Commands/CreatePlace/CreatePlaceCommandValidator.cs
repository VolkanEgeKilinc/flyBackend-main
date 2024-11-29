using FluentValidation;

namespace BilethubApi.Api.Application.PlaceOperations.Commands.CreatePlace;

public class CreatePlaceCommandValidator : AbstractValidator<CreatePlaceCommand>{

    public CreatePlaceCommandValidator(){
        RuleFor(command => command.Model.PlaceTypeId).GreaterThan(0);
        RuleFor(command => command.Model.Image).NotNull();
        RuleFor(command => command.Model.Title).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Description).MinimumLength(3).MaximumLength(255);
        RuleFor(command => command.Model.Address).NotEmpty();
        RuleFor(command => command.Model.DistrictId).GreaterThan(0);
        RuleFor(command => command.Model.CityId).GreaterThan(0);
        RuleFor(command => command.Model.CountryId).GreaterThan(0);
        RuleFor(command => command.Model.Location).NotNull();
    }
}