using Application.DTOs.LeaveRequest;
using Application.Features.FeatureGroup.Requests.QueryRequests.LeaveRequestRequests;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Queries.LeaveRequestsQueries;

public class QGetLeaveRequestsListHandler : IRequestHandler<QGetLeaveRequestsListRequests, List<LeaveRequestDto>>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;

    public QGetLeaveRequestsListHandler(ILeaveRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<LeaveRequestDto>> Handle(QGetLeaveRequestsListRequests request, CancellationToken cancellationToken)
    {
        var LeaveRequests = await _repository.GetAllAsync();
        return _mapper.Map<List<LeaveRequestDto>>(LeaveRequests);
    }
}