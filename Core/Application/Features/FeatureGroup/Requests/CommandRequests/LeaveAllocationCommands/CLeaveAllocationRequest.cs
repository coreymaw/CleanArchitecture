using Application.DTOs.LeaveAllocation.Create;
using Application.Responses;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.CommandRequests.LeaveAllocationCommands;

public class CLeaveAllocationRequest : IRequest<BaseCommandResponse>
{
    public CreateLeaveAllocationDto  LeaveAllocation { get; set; }
}