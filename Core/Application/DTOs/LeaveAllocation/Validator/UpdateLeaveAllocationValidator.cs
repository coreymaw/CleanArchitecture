using Application.DTOs.LeaveAllocation.Update;
using Application.Persistence.Contracts;
using FluentValidation;

namespace Application.DTOs.LeaveAllocation.Validator;

public class UpdateLeaveAllocationValidator : AbstractValidator<UpdateLeaveAllocationDto>
{
    private readonly ILeaveAllocationRepository _repository;

    public UpdateLeaveAllocationValidator(ILeaveAllocationRepository repository)
    {
        _repository = repository;
        
        Include(new ILeaveAllocationDtoValidator(_repository));
        
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id field is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
    
}