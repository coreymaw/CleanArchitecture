using Application.DTOs.LeaveType;
using Application.Features.FeatureGroup.Requests.QueryRequests.LeaveTypeRequests;
using Application.Persistence.Contracts;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.FeatureGroup.Handlers.Queries.LeaveTypeQueries;

public class QGetLeaveTypeListHandler : IRequestHandler<QGetLeaveTypeListRequest, List<LeaveTypeDto>>
{
    private readonly ILeaveTypeRepository _repository;
    private readonly IMapper _mapper;

    public QGetLeaveTypeListHandler(ILeaveTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<LeaveTypeDto>> Handle(QGetLeaveTypeListRequest request, CancellationToken cancellationToken)
    {
        var LeaveTypes = await _repository.GetAllAsync();
        return _mapper.Map<List<LeaveTypeDto>>(LeaveTypes);
    }
}