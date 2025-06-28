using Application.DTOs.LeaveRequest.Update;
using Application.Persistence.Contracts;
using FluentValidation;

namespace Application.DTOs.LeaveRequest.Validators;

public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
{
    private readonly ILeaveRequestRepository _repository;

    public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository repository)
    {
        _repository = repository;
        
        Include(new ILeaveRequestDtoValidator(_repository));
        
        RuleFor(x=>x.Id).NotEmpty()
            .WithMessage("{PropertyName} should not be empty")
            .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0");
        
    }
}