using FluentValidation;

namespace BilethubApi.Api.Application.TicketCategoryOperations.Commands.UpdateTicketCategory;

public class UpdateTicketCategoryCommandValidator : AbstractValidator<UpdateTicketCategoryCommand>
{
    public UpdateTicketCategoryCommandValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.Model.Title).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Quota).GreaterThan(0);
        RuleFor(command => command.Model.Price).GreaterThan(0);
    }
}