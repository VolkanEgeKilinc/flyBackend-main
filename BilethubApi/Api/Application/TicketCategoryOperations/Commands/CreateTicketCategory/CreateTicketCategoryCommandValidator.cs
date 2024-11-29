using FluentValidation;

namespace BilethubApi.Api.Application.TicketCategoryOperations.Commands.CreateTicketCategory;

public class CreateTicketCategoryCommandValidator : AbstractValidator<CreateTicketCategoryCommand>
{
    public CreateTicketCategoryCommandValidator()
    {
        RuleFor(command => command.Model.EventId).GreaterThan(0);
        RuleFor(command => command.Model.Title).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Quota).GreaterThan(0);
        RuleFor(command => command.Model.Price).GreaterThan(0);
    }
}