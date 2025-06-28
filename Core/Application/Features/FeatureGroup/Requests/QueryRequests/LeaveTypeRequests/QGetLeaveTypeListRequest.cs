using Application.DTOs.LeaveType;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.QueryRequests.LeaveTypeRequests;

public class QGetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
{
    
}