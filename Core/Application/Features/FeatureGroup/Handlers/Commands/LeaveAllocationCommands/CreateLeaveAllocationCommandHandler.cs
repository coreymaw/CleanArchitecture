using Application.DTOs.LeaveAllocation.Validator;
using Application.DTOs.LeaveRequest.Validators;
using Application.Exceptions;
using Application.Features.FeatureGroup.Requests.CommandRequests.LeaveAllocationCommands;
using Application.Models.Infrastructure;
using Application.Persistence.Contracts;
using Application.Persistence.Infrastructure;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Commands.LeaveAllocationCommands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CLeaveAllocationRequest, BaseCommandResponse>
{
    private readonly ILeaveAllocationRepository _repository;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository repository, IMapper mapper , IEmailSender emailSender)
    {
        _repository = repository;
        _mapper = mapper;
        _emailSender = emailSender;
    }
    public async Task<BaseCommandResponse> Handle(CLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new BaseCommandResponse();
        var validator = new CreateLeaveAllocationValidator(_repository);
        
        var ValidationResult = await validator.ValidateAsync(request.LeaveAllocation);
        if (!ValidationResult.IsValid)
        {
            response.IsSuccess = false;
            response.Message = "Transaction Failed, please try again later.";
            response.Errors = ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }

        var leaveAllocation =  _mapper.Map<LeaveAllocation>(request);
        await _repository.CreateAsync(leaveAllocation);
        response.IsSuccess = true;
        response.Message = "Transaction Successful";
        response.CreatedEntityId = leaveAllocation.Id;

        var email = Email.Create(
            "Ianebdao890@gmail.com", 
            "New Leave Allocation", 
            "This is a notification");
        try
        {
            await _emailSender.SendEmailAsync(email);
        }
        catch (Exception ex)
        {
            //// log
        }

        return response;
    }
}