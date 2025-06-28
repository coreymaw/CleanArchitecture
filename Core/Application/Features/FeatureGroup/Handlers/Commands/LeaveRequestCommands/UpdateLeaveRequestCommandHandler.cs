using Application.DTOs.LeaveRequest.Validators;
using Application.Exceptions;
using Application.Features.FeatureGroup.Requests.CommandRequests.LeaveRequestCommands;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Commands.LeaveRequestCommands;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<ULeaveLeaveRequest , Unit>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository  repository , IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(ULeaveLeaveRequest request, CancellationToken cancellationToken)
    {
    
        var LeaveRequest = await _repository.GetByIdAsync(request.LeaveRequest.Id);
        if (request?.LeaveRequest != null)
        {
            var validator = new UpdateLeaveRequestDtoValidator(_repository);
            var validationResult =  await validator.ValidateAsync(request.LeaveRequest, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request.LeaveRequest, LeaveRequest);
            await _repository.UpdateAsync(LeaveRequest);
     
        }
        else if (request?.UpdateLeaveRequestApproval != null) 
        {
            var validator = new UpdateLeaveRequestApprovalDtoValidator(_repository);
            var validationResult =  await validator.ValidateAsync(request.UpdateLeaveRequestApproval, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            _mapper.Map(request.UpdateLeaveRequestApproval, LeaveRequest);
            await _repository.UpdateLeaveRequestApproval(LeaveRequest, request.UpdateLeaveRequestApproval.Approved);
        }
        
        return Unit.Value;

    }
}