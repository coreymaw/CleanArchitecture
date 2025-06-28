using Application.DTOs.LeaveType.Update;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.CommandRequests.LeaveTypeCommands;

public class ULeaveTypeRequest : IRequest<Unit>
{
   public UpdateLeaveTypeDto LeaveType { get; set; }
}