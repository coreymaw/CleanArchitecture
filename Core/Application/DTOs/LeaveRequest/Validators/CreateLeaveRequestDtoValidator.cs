using Application.DTOs.LeaveRequest.Create;
using Application.Persistence.Contracts;
using FluentValidation;

namespace Application.DTOs.LeaveRequest.Validators;

public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
{
    private readonly ILeaveRequestRepository _repository;

    public CreateLeaveRequestDtoValidator(ILeaveRequestRepository repository)
    {
        _repository = repository;

        Include(new ILeaveRequestDtoValidator(_repository));
    }
}