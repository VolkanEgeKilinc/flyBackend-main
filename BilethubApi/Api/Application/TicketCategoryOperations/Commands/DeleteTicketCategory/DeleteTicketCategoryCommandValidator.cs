using FluentValidation;

namespace BilethubApi.Api.Application.TicketCategoryOperations.Commands.DeleteTicketCategory;

public class DeleteTicketCategoryCommandValidator : AbstractValidator<DeleteTicketCategoryCommand>
{
    public DeleteTicketCategoryCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}