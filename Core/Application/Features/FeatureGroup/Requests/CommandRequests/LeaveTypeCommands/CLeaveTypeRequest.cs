using Application.DTOs.LeaveType.Create;
using Application.Responses;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.CommandRequests.LeaveTypeCommands;

public class CLeaveTypeRequest : IRequest<BaseCommandResponse>
{ 
    public CreateLeaveTypeDto LeaveType { get; set; }
}