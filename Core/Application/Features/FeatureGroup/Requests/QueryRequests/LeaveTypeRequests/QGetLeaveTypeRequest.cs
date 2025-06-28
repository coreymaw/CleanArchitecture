using Application.DTOs.LeaveType;
using MediatR;

namespace Application.Features.FeatureGroup.Requests.QueryRequests.LeaveTypeRequests;

public class QGetLeaveTypeRequest : IRequest<LeaveTypeDto>
{
    public int Id { get; set; }
}