using Application.DTOs.LeaveAllocation;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.QueryRequests.LeaveAllocationRequests;

public class QGetLeaveAllocationRequest : IRequest<LeaveAllocationDto>
{
    public int Id { get; set; }
}