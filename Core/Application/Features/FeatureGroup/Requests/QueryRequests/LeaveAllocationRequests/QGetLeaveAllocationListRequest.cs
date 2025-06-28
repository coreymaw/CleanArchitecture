using Application.DTOs.LeaveAllocation;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.QueryRequests.LeaveAllocationRequests;

public class QGetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
{
    
}