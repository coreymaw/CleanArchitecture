using Application.DTOs.LeaveRequest;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.QueryRequests.LeaveRequestRequests;

public class QGetLeaveRequestRequest : IRequest<LeaveRequestDto>
{
    public int Id { get; set; }
}