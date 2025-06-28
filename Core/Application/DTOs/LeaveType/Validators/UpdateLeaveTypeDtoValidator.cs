using Application.DTOs.LeaveType.Update;
using FluentValidation;

namespace Application.DTOs.LeaveType.Validators;

public class UpdateLeaveTypeDtoValidator: AbstractValidator<UpdateLeaveTypeDto>
{
    public UpdateLeaveTypeDtoValidator()
    {
        Include(new ILeaveTypeDtoValidator());
        
        RuleFor(x=>x.Id)
            .NotNull().WithMessage("{PropertyName} cannot be empty")
            .GreaterThan(0).WithMessage("{PropertyName} must have more than 0");
    }
}