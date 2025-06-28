using Application.DTOs.LeaveAllocation;
using Application.DTOs.LeaveAllocation.Update;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.CommandRequests.LeaveAllocationCommands;

public class ULeaveAllocationRequest : IRequest<Unit>
{
  public UpdateLeaveAllocationDto  LeaveAllocation { get; set; }
}