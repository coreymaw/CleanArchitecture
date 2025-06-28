using FluentValidation;

namespace Application.DTOs.LeaveType.Validators;

public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
{
    public ILeaveTypeDtoValidator()
    {
        RuleFor(x=>x.Name)
            .NotNull().WithMessage("{PropertyName} cannot be empty")
            .MinimumLength(1).WithMessage("{PropertyName} must have less than {MinLength}")
            .MaximumLength(30).WithMessage("{PropertyName} must have more than {MaxLength}");
        RuleFor(x =>x.DefaultDays)
            .NotNull().WithMessage("{PropertyName} cannot be empty")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
            .LessThan(100).WithMessage("{PropertyName} must be less than 100");;
    }
    
}