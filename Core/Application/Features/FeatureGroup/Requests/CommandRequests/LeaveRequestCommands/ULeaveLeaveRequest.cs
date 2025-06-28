using Application.DTOs.LeaveRequest.Update;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.CommandRequests.LeaveRequestCommands;

public class ULeaveLeaveRequest : IRequest<Unit>
{
    public UpdateLeaveRequestDto LeaveRequest { get; set; }
    public UpdateLeaveRequestApprovalDto UpdateLeaveRequestApproval { get; set; }
}