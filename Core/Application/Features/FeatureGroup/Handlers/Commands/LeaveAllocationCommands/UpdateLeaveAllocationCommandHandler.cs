using Application.DTOs.LeaveAllocation.Validator;
using Application.Exceptions;
using Application.Features.FeatureGroup.Requests.CommandRequests.LeaveAllocationCommands;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Commands.LeaveAllocationCommands;

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<ULeaveAllocationRequest, Unit>
{
    private readonly ILeaveAllocationRepository _repository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository  repository , IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(ULeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationValidator(_repository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocation);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }

        var leaveType = await _repository.GetByIdAsync(request.LeaveAllocation.Id);
        _mapper.Map(request.LeaveAllocation, leaveType);
        await _repository.UpdateAsync(leaveType);
        return Unit.Value;
    }
}