using Application.DTOs.LeaveRequest;
using Application.Features.FeatureGroup.Requests.QueryRequests.LeaveRequestRequests;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Queries.LeaveRequestsQueries;

public class QGetLeaveRequestHandler : IRequestHandler<QGetLeaveRequestRequest, LeaveRequestDto>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;

    public QGetLeaveRequestHandler(ILeaveRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<LeaveRequestDto> Handle(QGetLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        var LeaveRequest = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<LeaveRequestDto>(LeaveRequest);
    }
}