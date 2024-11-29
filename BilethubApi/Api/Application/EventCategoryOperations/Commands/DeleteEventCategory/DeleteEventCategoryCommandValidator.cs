using FluentValidation;

namespace BilethubApi.Api.Application.EventCategoryOperations.Commands.DeleteEventCategory;

public class DeleteEventCategoryCommandValidator : AbstractValidator<DeleteEventCategoryCommand>
{
    public DeleteEventCategoryCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}