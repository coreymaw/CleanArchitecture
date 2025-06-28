using Application.DTOs.LeaveAllocation;
using Application.Features.FeatureGroup.Requests.QueryRequests.LeaveAllocationRequests;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Queries.LeaveAllocationQueries;

public class QGetLeaveAllocationListHandler : IRequestHandler<QGetLeaveAllocationListRequest, List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository _repository;
    private readonly IMapper _mapper;

    public QGetLeaveAllocationListHandler(ILeaveAllocationRepository  repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<LeaveAllocationDto>> Handle(QGetLeaveAllocationListRequest request, CancellationToken cancellationToken)
    {
        var LeaveAllccations = await _repository.GetLeaveAllocationLisWithDetails();
        return _mapper.Map<List<LeaveAllocationDto>>(LeaveAllccations);
    }
}