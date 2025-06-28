using Application.Persistence.Contracts;
using FluentValidation;

namespace Application.DTOs.LeaveRequest.Validators;

public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
{
    private readonly ILeaveRequestRepository _repository;

    public ILeaveRequestDtoValidator(ILeaveRequestRepository repository)
    {
        RuleFor(x=>x.StartDate)
            .NotNull().WithMessage("{PropertyName} cannot be empty")
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .LessThan(DateTime.Now).WithMessage("{PropertyName} must be less than or equal to {ComparisonValue}")
            .GreaterThan(x=>x.EndDate).WithMessage("{PropertyName} must be less than or equal to {ComparisonValue}");
        
        RuleFor(x=>x.EndDate)
            .NotNull().WithMessage("{PropertyName} cannot be empty")
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .GreaterThan(x=>x.StartDate)
            .WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}");

        RuleFor(x => x.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                return await _repository.CheckIfExists(id);;
            }).WithMessage("{PropertyName} does not exists") ;
    }
    
}