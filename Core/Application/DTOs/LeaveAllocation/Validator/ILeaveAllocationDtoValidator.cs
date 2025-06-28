using Application.DTOs.LeaveType;
using Application.Persistence.Contracts;
using FluentValidation;

namespace Application.DTOs.LeaveAllocation.Validator;

public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
{
    private readonly ILeaveAllocationRepository _repository;

    public ILeaveAllocationDtoValidator(ILeaveAllocationRepository repository)
    {
        _repository = repository;
        
        RuleFor(x=>x.NumberOfDays)
            .NotEmpty()
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero");
        RuleFor(x=>x.LeaveTypeId)
            .NotEmpty()
            .MustAsync(async (id, token) =>
            {
                var LeaveTypeExists = await _repository.CheckIfExists(id);
                return LeaveTypeExists;
            })
            .WithMessage("{PropertyName} does not exist");
        RuleFor(x=>x.Period)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero")
            .NotEmpty().WithMessage("{PropertyName} must be greater than zero or empty")
            .LessThan(100).WithMessage("{PropertyName} must be less than or equal to 100");
    }
}
  
