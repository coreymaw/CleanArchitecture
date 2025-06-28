using Application.DTOs.LeaveRequest.Validators;
using Application.Exceptions;
using Application.Features.FeatureGroup.Requests.CommandRequests.LeaveRequestCommands;
using Application.Persistence.Contracts;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Commands.LeaveRequestCommands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CLeaveRequestRequest, BaseCommandResponse>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository repository , IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse> Handle(CLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        
        BaseCommandResponse response = new BaseCommandResponse();
        var validator = new CreateLeaveRequestDtoValidator(_repository);
        var validationResult = await validator.ValidateAsync(request.LeaveRequest, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.IsSuccess = false;
            response.Message = "Invalid Request";
            response.Errors = validationResult.Errors.Select(x=>x.ErrorMessage).ToList();
        }
        var LeaveRequest = _mapper.Map<LeaveRequest>(request);
        await _repository.CreateAsync(LeaveRequest);
        response.IsSuccess = true;
        response.Message = "Leave request created";
        response.CreatedEntityId = LeaveRequest.Id;
        return response;
        
    }
}