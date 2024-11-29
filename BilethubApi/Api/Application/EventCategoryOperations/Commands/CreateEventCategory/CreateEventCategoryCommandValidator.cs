using FluentValidation;

namespace BilethubApi.Api.Application.EventCategoryOperations.Commands.CreateEventCategory;

public class CreateEventCategoryCommandValidator : AbstractValidator<CreateEventCategoryCommand>{

    public CreateEventCategoryCommandValidator(){
        RuleFor(command => command.Model.Title).MinimumLength(3).MaximumLength(50);
    }
}