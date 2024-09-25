using FluentValidation;

namespace Application.Users.Commands;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Course name is required.");

        RuleFor(command => command.StartAt)
            .NotEmpty()
            .WithMessage("Start date is required.")
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Start date must be in the future.");

        RuleFor(command => command.FinishAt)
            .NotEmpty()
            .WithMessage("Finish date is required.")
            .GreaterThan(command => command.StartAt)
            .WithMessage("Finish date must be after the start date.");

        RuleFor(command => command.MaxStudents)
            .GreaterThan(0)
            .WithMessage("Max students must be greater than zero.");
    }
}