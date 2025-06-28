using MediatR;

namespace Application.Features.FeatureGroup.Requests.CommandRequests.LeaveTypeCommands;

public class DLeaveTypeRequest : IRequest<Unit>
{
    public int Id { get; set; }
}