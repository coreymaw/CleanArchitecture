using Application.DTOs.LeaveAllocation.Create;
using Application.Persistence.Contracts;
using FluentValidation;

namespace Application.DTOs.LeaveAllocation.Validator;

public class CreateLeaveAllocationValidator :  AbstractValidator<CreateLeaveAllocationDto>
{
    private readonly ILeaveAllocationRepository _repository;

    public CreateLeaveAllocationValidator(ILeaveAllocationRepository repository)
    {
        _repository = repository;
        
        Include(new ILeaveAllocationDtoValidator(_repository));
    }
    
}