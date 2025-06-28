using Application.DTOs.LeaveType.Validators;
using Application.Exceptions;
using Application.Features.FeatureGroup.Requests.CommandRequests.LeaveTypeCommands;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Commands.LeaveTypeCommands;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<ULeaveTypeRequest, Unit>
{
    private readonly ILeaveTypeRepository _repository;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository  repository , IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(ULeaveTypeRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.LeaveType);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }

        var leaveType = await _repository.GetByIdAsync(request.LeaveType.Id);
        _mapper.Map(request.LeaveType, leaveType);
        await _repository.UpdateAsync(leaveType);
        return Unit.Value;
    }
}