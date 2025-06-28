using Application.DTOs.LeaveRequest;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.QueryRequests.LeaveRequestRequests;

public class QGetLeaveRequestsListRequests : IRequest<List<LeaveRequestDto>>
{
    
}