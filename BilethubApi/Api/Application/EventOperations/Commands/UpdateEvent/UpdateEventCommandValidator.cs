using FluentValidation;

namespace BilethubApi.Api.Application.EventOperations.Commands.UpdateEvent;

public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>{
    public UpdateEventCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.Model.PlaceId).GreaterThan(0);
        RuleFor(command => command.Model.GenreId).GreaterThan(0);
        RuleFor(command => command.Model.EventCategoryId).GreaterThan(0);
        RuleFor(command => command.Model.Image).NotNull();
        RuleFor(command => command.Model.Title).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Description).MinimumLength(3).MaximumLength(255);
        RuleFor(command => command.Model.Start).NotEmpty().GreaterThan(DateTime.Now.Date);
        RuleFor(command => command.Model.Opening).GreaterThanOrEqualTo(DateTime.Now.Date);
        RuleFor(command => command.Model.End).NotEmpty().GreaterThan(DateTime.Now.Date);
        RuleFor(command => command.Model.HomePageVisibility).NotNull();
        RuleFor(command => command.Model.TicketTransfer).NotNull();
        RuleFor(command => command.Model.Artists).NotEmpty();

    }
}