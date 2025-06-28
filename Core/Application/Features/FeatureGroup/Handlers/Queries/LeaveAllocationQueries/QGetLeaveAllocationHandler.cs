
using Application.DTOs.LeaveAllocation;
using Application.Features.FeatureGroup.Requests.QueryRequests.LeaveAllocationRequests;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Queries.LeaveAllocationQueries;

public class QGetLeaveAllocationHandler : IRequestHandler<QGetLeaveAllocationRequest, LeaveAllocationDto>
{
    private readonly ILeaveAllocationRepository _repository;
    private readonly IMapper _mapper;

    public QGetLeaveAllocationHandler(ILeaveAllocationRepository  repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<LeaveAllocationDto> Handle(QGetLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _repository.GetLeaveAllocationWithDetailsById(request.Id);
        return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
    }
}