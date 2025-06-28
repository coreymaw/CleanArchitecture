using Application.DTOs.LeaveType.Validators;
using Application.Features.FeatureGroup.Requests.CommandRequests.LeaveTypeCommands;
using Application.Persistence.Contracts;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Commands.LeaveTypeCommands;

public class CreateLeaveTypeCommandHandler: IRequestHandler<CLeaveTypeRequest, BaseCommandResponse> 
{
    private readonly ILeaveTypeRepository _repository;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<BaseCommandResponse> Handle(CLeaveTypeRequest request, CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new BaseCommandResponse();
        var validator = new CreateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.LeaveType);
        if (!validationResult.IsValid)
        {
            response.IsSuccess = false;
            response.Message = "Invalid Request";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        
        var leaveType = _mapper.Map<LeaveType>(request); 
        await _repository.CreateAsync(leaveType);
        response.IsSuccess = true;
        response.Message = "New leave type created";
        response.CreatedEntityId = leaveType.Id;
        return response;
    }

}