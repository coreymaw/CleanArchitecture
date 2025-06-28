using Application.DTOs.LeaveRequest.Update;
using Application.Persistence.Contracts;
using FluentValidation;

namespace Application.DTOs.LeaveRequest.Validators;

public class UpdateLeaveRequestApprovalDtoValidator : AbstractValidator<UpdateLeaveRequestApprovalDto>
{
    private readonly ILeaveRequestRepository _repository;

    public UpdateLeaveRequestApprovalDtoValidator(ILeaveRequestRepository repository)
    {
        _repository = repository;
        RuleFor(x=>x.Id).NotNull().WithMessage("{PropertyName} should not be null")
            .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0")
            .MustAsync(async (id, token) =>
            {
                return await _repository.CheckIfExists(id);
            }).WithMessage("{PropertyName} can not be found}");
        
    }
}