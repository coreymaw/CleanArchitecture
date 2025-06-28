using Application.DTOs.LeaveRequest.Create;
using Application.Responses;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.CommandRequests.LeaveRequestCommands;

public class CLeaveRequestRequest : IRequest<BaseCommandResponse>
{
   public CreateLeaveRequestDto LeaveRequest { get; set; }
}